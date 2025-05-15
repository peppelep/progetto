import { Component, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Cf02UtenteDto } from '../../models/dto/cf/cf02-utente.dto';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { ConfigurazioneService } from 'src/app/services/configurazione.service';
import { Ge02RuoliDto } from 'src/app/models/dto/ge/ge02-ruoli.dto';
import { Cf02UtenteService } from 'src/app/services/cf/cf02-utente.service';
import { CurrentTenantService } from 'src/app/services/current-tenant.service';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { ToastComponent, ToastPositionModel } from '@syncfusion/ej2-angular-notifications';

@Component({
  selector: 'app-profilo-utente',
  templateUrl: './profilo-utente.component.html',
  styleUrls: ['./profilo-utente.component.css', '../../../styles/dialog.css'],
  standalone: false
})

export class ProfiloUtenteComponent implements OnInit {

  @ViewChild('dialog') dialog!: DialogComponent;
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


  ngOnInit(): void {
    this.loadRuoli();
    this.loadMyAccount();
  }

  createForm(): void {
    this.utenteForm = this.fb.group({
      cf02UtenteCf01: [''],
      cf02Utente1: ['', Validators.required],
      cf02RuoloGe02: [''],
      cf02Email: ['', [Validators.email]],
      cf02Telefono: [''],
      cf02Fornitori: [false],
      cf02Clienti: [false],
      cf02Primanota: [false]
    });
  }

  loadRuoli(): void {
    this.configurazioneService.getGe02Ruoli().subscribe({
      next: (response) => {
        if (response.data) {
          this.ruoli = response.data;
        }
      },
      error: (error) => {
        console.error('Errore nel caricamento dei ruoli:', error);
      }
    });
  }

  loadMyAccount(): void {
    this.utenteService.getCurrent().subscribe({
      next: (response) => {
        this.utente = response;
        this.utenteForm.patchValue(this.utente);
        //ruolo
        this.utenteForm.get('cf02RuoloGe02')?.disable();
        //nome utente
        this.utenteForm.get('cf02Utente1')?.disable();
        //permessi
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
         this.utenteService.update(this.utente).subscribe({
           next: (response) => {
            this.showToast('Operazione completata con successo', 'success');
             //this.snackBar.open('Utente aggiornato con successo', 'Chiudi', { duration: 3000 });
              this.loadMyAccount();
           },
           error: (error) => {
             console.error('Errore durante l\'aggiornamento dell\'utente:', error);
             this.showToast('Errore durante l\'operazione', 'error');

             //this.snackBar.open('Errore durante l\'aggiornamento dell\'utente', 'Chiudi', { duration: 3000 });
           }
         });
      }else {
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
      this.loadMyAccount();
  }

  CambiaPassword(): void {
    //this.router.navigate(['/sign']);
    this.dialog.show();
  }
}
