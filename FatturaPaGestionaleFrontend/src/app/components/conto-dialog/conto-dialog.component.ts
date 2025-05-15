import { Component, OnInit, Input, Output, EventEmitter, ViewChild, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { FormValidatorModel } from '@syncfusion/ej2-angular-inputs';
import { Cf04ContoDto } from 'src/app/models/dto/cf/cf04-conto.dto';
import { Cf04ContoService } from 'src/app/services/cf/cf04-conto.service';
import { CurrentTenantService } from 'src/app/services/current-tenant.service';

@Component({
  selector: 'app-conto-dialog',
  templateUrl: './conto-dialog.component.html',
  styleUrls: ['./conto-dialog.component.css', '../../../styles/dialog.css'],
  standalone: false
})
export class ContoDialogComponent implements OnInit {
  @Input() conto: Cf04ContoDto = {} as Cf04ContoDto;
  @Output() saveComplete = new EventEmitter<Cf04ContoDto>();

  public contoForm!: FormGroup;
  public error: string | null = null;
  public isEditMode = false;

  tipiAnagraficaOptions = [
    { value: 'S', text: 'Standard' },
    { value: 'B', text: 'Bancario' }
  ];

  // Configurazione del validatore Syncfusion
  public formValidator: FormValidatorModel = {
    rules: {
      'cf04Conto1': { required: false },
      'cf04Nome': { required: true },
      'cf04Tipo': { required: true },
      'cf04Iban': {
        required: false,
        regex: ['^[A-Z]{2}[0-9]{2}[A-Z0-9]{1,30}$', 'Formato IBAN non valido']
      },
      'cf04CodiceSia': {
        required: false,
        maxLength: 5
      }
    },
    customPlacement: (inputElement: HTMLElement, errorElement: HTMLElement) => {
      const formGroup = inputElement.closest('.e-input-group');
      if (formGroup) {
        formGroup.parentElement?.appendChild(errorElement);
      }
    }
  };

  constructor(
    private fb: FormBuilder,
    private contoService: Cf04ContoService,
    private currentTenantService: CurrentTenantService
  ) {}

  ngOnInit(): void {
    console.log('Conto:', this.conto);
    this.conto.cf04TenantCf01 = this.currentTenantService.currentTenantValue!;
    this.isEditMode = !!this.conto.cf04Conto1;
    if (!this.isEditMode) {
      this.conto={} as Cf04ContoDto;
    }
    this.initForm();
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.isEditMode = !!this.conto.cf04Conto1;
    if (!this.isEditMode) {
      this.conto={} as Cf04ContoDto;
    }
    this.initForm();
  }


  initForm(): void {
    this.contoForm = this.fb.group({
      cf04TenantCf01: [this.conto.cf04TenantCf01 || undefined],
      cf04Conto1: [
        {
          value: this.conto.cf04Conto1 || undefined,
          disabled: this.isEditMode
        }
      ],
      cf04Nome: [this.conto.cf04Nome || '', Validators.required],
      cf04Tipo: [this.conto.cf04Tipo || '', Validators.required],
      cf04Iban: [this.conto.cf04Iban || undefined, [
        Validators.pattern(/^[A-Z]{2}[0-9]{2}[A-Z0-9]{1,30}$/)
      ]],
      cf04CodiceSia: [this.conto.cf04CodiceSia || undefined, [
        Validators.maxLength(5)
      ]]
    });
  }

  onSubmit(): void {
    // console.log('Form submitted:', this.contoForm.value);
    // console.log('Form validation status:', this.contoForm.valid);
    // console.log('Form errors:', this.contoForm.errors);

    if (this.contoForm.invalid) {
      console.log('Form validation errors:', this.contoForm.errors);
      // Evidenzia tutti i campi con errori
      Object.keys(this.contoForm.controls).forEach(key => {
        const control = this.contoForm.get(key);
        if (control) {
          control.markAsTouched();
          console.log(`Control ${key} errors:`, control.errors);
        }
      });
      return;
    }
    console.log('Form submitted:', this.contoForm.value);
    this.error = null;

    // Prepara i dati per l'invio
    const formValue = this.contoForm.getRawValue();
    const conto: Cf04ContoDto = {
      cf04TenantCf01: formValue.cf04TenantCf01,
      cf04Conto1: formValue.cf04Conto1,
      cf04Nome: formValue.cf04Nome,
      cf04Tipo: formValue.cf04Tipo,
      cf04Iban: formValue.cf04Iban,
      cf04CodiceSia: formValue.cf04CodiceSia
    };
    conto.cf04TenantCf01= this.currentTenantService.currentTenantValue!;
    console.log('Conto:', conto);
    // Determina se è una creazione o un aggiornamento
    console.log('isEditMode:', this.isEditMode);
    const operation = this.isEditMode
      ? this.contoService.update(conto)
      : this.contoService.create(conto);
    console.log('Operation:', operation);
    operation.subscribe({
      next: (result) => {
        console.log('Result:', result);
        this.saveComplete.emit(result);
      },
      error: (err) => {
        this.error = err.message || 'Si è verificato un errore durante il salvataggio del conto';
      }
    });
  }

  getErrorMessage(controlName: string): string {
    const control = this.contoForm.get(controlName);

    if (!control || !control.errors || !control.touched) {
      return '';
    }

    if (control.errors['required']) {
      return 'Campo obbligatorio';
    }

    if (control.errors['pattern']) {
      if (controlName === 'cf04Iban') {
        return 'Formato IBAN non valido';
      }
      return 'Formato non valido';
    }

    if (control.errors['maxlength']) {
      return `Massimo ${control.errors['maxlength'].requiredLength} caratteri`;
    }

    return 'Campo non valido';
  }
}
