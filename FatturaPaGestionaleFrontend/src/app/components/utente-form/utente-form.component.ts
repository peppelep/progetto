import { Component, Input, OnInit, Output, EventEmitter, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Cf02UtenteDto } from '../../models/dto/cf/cf02-utente.dto';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router, ActivatedRoute } from '@angular/router';
import { ConfigurazioneService } from 'src/app/services/configurazione.service';
import { Ge02RuoliDto } from 'src/app/models/dto/ge/ge02-ruoli.dto';
import { Cf02UtenteService } from 'src/app/services/cf/cf02-utente.service';
import { CurrentTenantService } from 'src/app/services/current-tenant.service';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { ToastComponent, ToastPositionModel } from '@syncfusion/ej2-angular-notifications';

@Component({
  selector: 'app-utente-form',
  templateUrl: './utente-form.component.html',
  styleUrls: ['./utente-form.component.css', '../../../styles/dialog.css'],
  standalone: false
})

export class UtenteFormComponent implements OnInit {
  @ViewChild('dialog') dialog!: DialogComponent;
  @Input() utenteSelected: Cf02UtenteDto ={} as Cf02UtenteDto;
  @Output() closeDialog = new EventEmitter<void>();
  @ViewChild('toast') public toast!: ToastComponent;
  // Configurazione del toast
  public toastPosition: ToastPositionModel = { X: 'Right', Y: 'Top' };


  utenteForm!: FormGroup;
  utente: Cf02UtenteDto = {};
  isEditMode = false;
  utenteId: string | null = null;
  ruoli : Ge02RuoliDto[] = [];

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private configurazioneService: ConfigurazioneService,
    private utenteService: Cf02UtenteService,
    private currentTenantService: CurrentTenantService
  ) {
    this.createForm();
  }

  async ngOnInit(): Promise<void> {
    console.log("ngOnInit")
    console.log("utSelected",this.utenteSelected)
    await this.loadRuoli();
    if (this.utenteSelected!= null && Object.keys(this.utenteSelected).length === 0) {
      this.isEditMode = true;
      this.loadUtenteById(this.utenteSelected.cf02Utente1!);
    } else {
      this.utenteForm.reset();

    }
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (this.utenteSelected!= null && Object.keys(this.utenteSelected).length != 0) {
      this.isEditMode = true;
      this.loadUtenteById(this.utenteSelected.cf02Utente1!);
    } else {
      this.utenteForm.reset();
    }
    // if(this.newAccount){
    //   this.utenteForm.reset();
    //   this.utenteForm.get('cf02RuoloGe02')?.enable();
    //   this.utenteForm.get('cf02Utente1')?.disable();
    //   this.utenteForm.get('cf02Fornitori')?.enable();
    //   this.utenteForm.get('cf02Clienti')?.enable();
    //   this.utenteForm.get('cf02Primanota')?.enable();
    // }else{
    //   this.isEditMode = true;
    //   this.utenteForm.patchValue(this.utenteSelected!);
    //   this.utenteForm.get('cf02RuoloGe02')?.disable();
    //   this.utenteForm.get('cf02Utente1')?.disable();
    //   this.utenteForm.get('cf02Fornitori')?.disable();
    //   this.utenteForm.get('cf02Clienti')?.disable();
    //   this.utenteForm.get('cf02Primanota')?.disable();
    // }
  }

  createForm(): void {
    this.utenteForm = this.fb.group({
      cf02RuoloGe02: [''],
      cf02Password: [''],
      cf02Email: ['', [Validators.email]],
      cf02Telefono: [''],
      cf02Fornitori: [false],
      cf02Clienti: [false],
      cf02Primanota: [false]
    });
  }

  async loadRuoli(): Promise<void> {
    const response = await this.configurazioneService.getGe02RuoliFiltered().toPromise();
    if (response && response.data) {
      this.ruoli = response.data;
      console.log("ruoli",this.ruoli)
    }
  }

  loadUtenteById(id: string): void {
     this.utenteService.getUtenteById(id).subscribe({
       next: (utente) => {
         if (utente.data) {
           this.utente = utente.data;
           this.utenteForm.patchValue(this.utente);
           this.utenteForm.get('cf02Utente1')?.disable();
           //this.showToast('Operazione completata con successo', 'success');

           //this.snackBar.open('Dati dell\'utente caricati con successo', 'Chiudi', { duration: 3000 });
         } else {
           this.showToast('Nessun dato utente trovato', 'error');
           //this.snackBar.open('Nessun dato utente trovato', 'Chiudi', { duration: 3000 });
         }
       },
       error: (error) => {
         console.error('Errore durante il caricamento dell\'utente:', error);
         this.showToast('Errore durante l\'operazione', 'error');

         //this.snackBar.open('Errore durante il caricamento dell\'utente', 'Chiudi', { duration: 3000 });
       }
     });
  }

  loadMyAccount(): void {
    this.utenteService.getCurrent().subscribe({
      next: (response) => {
        this.utente = response;
        this.utenteForm.patchValue(this.utente);
        this.utenteForm.get('cf02RuoloGe02')?.disable();
        this.utenteForm.get('cf02Utente1')?.disable();
        this.utenteForm.get('cf02Fornitori')?.disable();
        this.utenteForm.get('cf02Clienti')?.disable();
        this.utenteForm.get('cf02Primanota')?.disable();
      },
      error: (error) => {
        console.error('Errore nel caricamento dell\'utente:', error);
      }
    });
  }

  saveForm(): void {
    if (this.utenteForm.valid) {
      Object.assign(this.utente, this.utenteForm.value);
     //console.log(this.utente);
      if ((this.utenteSelected!= null && Object.keys(this.utenteSelected).length === 0) || this.utente.cf02Utente1!=null) {
        this.utente.cf02Utente1 = this.utenteSelected.cf02Utente1;
         this.utenteService.update(this.utente).subscribe({
           next: (response) => {
             this.showToast('Utente aggiornato con successo', 'success');
             //this.snackBar.open('Utente aggiornato con successo', 'Chiudi', { duration: 3000 });
             if(this.utenteSelected!= null && Object.keys(this.utenteSelected).length === 0){
              this.closeDialog.emit();
             }else{
              this.loadMyAccount();
             }
           },
           error: (error) => {
             console.error('Errore durante l\'aggiornamento dell\'utente:', error);
             this.showToast('Errore durante l\'aggiornamento dell\'utente', 'error');
             //this.snackBar.open('Errore durante l\'aggiornamento dell\'utente', 'Chiudi', { duration: 3000 });
           }
         });
      } else {
        this.utente.cf02TenantCf01 = this.currentTenantService.currentTenantValue!;
        this.utente.cf02Utente1 = undefined;
         this.utenteService.create(this.utente).subscribe({
           next: (response) => {
             this.showToast('Utente creato con successo', 'success');
             this.snackBar.open('Utente creato con successo', 'Chiudi', { duration: 3000 });
             this.closeDialog.emit();
          },
           error: (error) => {
             this.showToast('Errore durante la creazione dell\'utente', 'error');
             console.error('Errore durante la creazione dell\'utente:', error);
             //this.snackBar.open('Errore durante la creazione dell\'utente', 'Chiudi', { duration: 3000 });
          }
         });
      }
    } else {
      this.showToast('Form non valido, controllare i campi obbligatori', 'error');
      //this.snackBar.open('Form non valido, controllare i campi obbligatori', 'Chiudi', { duration: 3000 });
    }
  }

  showToast(message: string, type: 'success' | 'error' | 'info' | 'warning'): void {
    let cssClass = '';

    switch (type) {
      case 'success':
        cssClass = 'e-toast-success';
        break;
      case 'error':
        cssClass = 'e-toast-danger';
        break;
      case 'info':
        cssClass = 'e-toast-info';
        break;
      case 'warning':
        cssClass = 'e-toast-warning';
        break;
    }

    this.toast.cssClass = cssClass;
    this.toast.content = message;
    this.toast.show();
  }

  annulla(): void {
    if (this.utenteSelected!=null) {
       this.utenteForm.patchValue(this.utenteSelected!);
    } else{
      this.closeDialog.emit();
    }
  }

  CambiaPassword(): void {
    //this.router.navigate(['/sign']);
    this.dialog.show();
  }
}

