import { Component, OnInit, ViewChild, AfterViewInit, Query } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ConfigurazioneService } from '../../services/configurazione.service';
import { Ge08ProvinciaDto } from '../../models/dto/ge/ge08-provincia.dto';
import { Ge05CassaProfDto } from 'src/app/models/dto/ge/ge05-cassa-prof.dto';
import { Ge03IvaDto } from 'src/app/models/dto/ge/ge03-iva.dto';
import { Ge04RegimeFiscaleDto } from 'src/app/models/dto/ge/ge04-regime-fiscale.dto';
import { Ge06TipoRitenutumDto } from 'src/app/models/dto/ge/ge06-tipo-ritenutum.dto';
import { Ge07CausPagRitenutumDto } from 'src/app/models/dto/ge/ge07-caus-pag-ritenutum.dto';
import { Ge01ComuniDto } from 'src/app/models/dto/ge/ge01-comuni.dto';
import {  IRPEF_LIST } from 'src/app/consts/irpefTypes';
import { DropdownItem, DropdownItemString } from 'src/app/consts/dropDownItem';
import { COEFFFICENTE_REDDITIVITA } from 'src/app/consts/coefficenteRedditivita';
import { TIPO_DITTA } from 'src/app/consts/tipoDitta';
import { FORFETTARIO } from 'src/app/consts/forfettario';
import { AccordionComponent } from '@syncfusion/ej2-angular-navigations';
import { ActivatedRoute } from '@angular/router';
import { DittaService } from 'src/app/services/ditta.service';
import { An01DittumDTO } from 'src/app/models/dto/an/an01-dittum.dto';
import { Location } from '@angular/common';

import { STATO_LIQUIDAZIONE_LIST } from 'src/app/consts/statoLiquidazione';
import { ESIGIBILITA_IVA } from 'src/app/consts/esigibilitaIva';
import { ENASARCO, RITENUTA_ENASARCO } from 'src/app/consts/enasarco';
import { TIPOLOGIA_FATTURA_LIST } from 'src/app/consts/tipologiaFattura';
import { Observable, of, map, catchError } from 'rxjs';
import { codiceFiscaleOrPartitaIvaValidator, codiceFiscaleValidator } from 'src/app/validator/validatoreCf';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { partitaIvaValidator } from 'src/app/validator/validatorePIVA';
import { FilteringEventArgs } from '@syncfusion/ej2-angular-dropdowns';
import { EmitType } from '@syncfusion/ej2-base';
import { AziendaCommonResponse } from 'src/app/models/aziendaCommonResponse';
import { createSpinner, showSpinner, hideSpinner } from '@syncfusion/ej2-angular-popups';
import { CurrentTenantService } from 'src/app/services/current-tenant.service';
import { ToastComponent, ToastPositionModel } from '@syncfusion/ej2-angular-notifications';


@Component({
  selector: 'app-ditta-form',
  templateUrl: './ditta-form.component.html',
  styleUrls: ['./ditta-form.component.css', '../../../styles/accordion.css'],
  standalone: false
})
export class DittaFormComponent implements OnInit, AfterViewInit {
  dittumForm!: FormGroup;
  @ViewChild('accordion', { static: false }) accordion!: AccordionComponent;
  @ViewChild('toast') public toast!: ToastComponent;
    // Configurazione del toast
    public toastPosition: ToastPositionModel = { X: 'Right', Y: 'Top' };

  ditta: An01DittumDTO = {};
  isEditMode = false;
  dittaId: string | null = null;
  isExpanded = true;

  // Dati per i dropdown
  public yesNoData: any[] = [
    { text: 'Sì', value: 'S' },
    { text: 'No', value: 'N' }
  ];

  public socioUnicoData: any[] = [
    { text: 'Socio Unico', value: 'SU' },
    { text: 'Socio Multiplo', value: 'SM' }
  ];

  // Placeholder per altri dati dei dropdown (da popolare con dati reali)
  public provinceData: Ge08ProvinciaDto[] = [];
  public regimeFiscaleData: any[] = [];
  public codiceIvaData: Ge03IvaDto[] = [];
  public tipoDittaData: DropdownItem[] = TIPO_DITTA;
  public forfettarioData: DropdownItem[] = FORFETTARIO;
  public tipoForfettarioData: DropdownItem[] = IRPEF_LIST;
  public coefficienteRedditivitaData: DropdownItem[] = COEFFFICENTE_REDDITIVITA;
  public statoLiquidazioneData: DropdownItemString[] = STATO_LIQUIDAZIONE_LIST;
  public esigibilitaIvaData: DropdownItemString[] = ESIGIBILITA_IVA;
  public tipoRitenutaData: Ge06TipoRitenutumDto[] = [];
  public causPagRitenutaData: Ge07CausPagRitenutumDto[] = [];
  public tipologiaFatturaData: DropdownItemString[] = TIPOLOGIA_FATTURA_LIST;
  public cassaProfData: any[] = [];
  public showTipoForfettario: boolean = false;
  public ritenutaEnasarcoData: DropdownItemString[] = RITENUTA_ENASARCO;
  public enasarcoData: DropdownItemString[] = ENASARCO ;
  public comuniData: Ge01ComuniDto[] = [];
  constructor(
    private fb: FormBuilder,
    private configurazioneService: ConfigurazioneService,
    private dittaService: DittaService,
    private router: Router,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private location: Location,
    private currentTenantService: CurrentTenantService
  ) {
    this.createForm();
    this.setupForfettarioListener();
  }

  async ngOnInit(): Promise<void> {
    createSpinner({
      // Specify the target for the spinner to show
      target: document.getElementById('container') as any
    });

    // showSpinner() will make the spinner visible
    showSpinner((document as any).getElementById('container'));
    this.loadProvince();
    this.setupIscrittoAlboListener();
    this.setupCassa01Listener();
    this.setupRivalsaInpsListener();
    this.setupEnasarcoListener();
    this.setupComuneListener();
    this.configurazioneService.getGe05CassaProf().subscribe(response => {
      if (response && response.data) {
        this.cassaProfData = [
          { ge05Cassa: '', ge05Descrizione: '' },
          ...response.data
        ];
      }
    });

    this.configurazioneService.getGe03Iva().subscribe(response => {
      if (response && response.data) {
        this.codiceIvaData = [
          { ge03CodiceIva: undefined, ge03Descrizione: '' },
          ...response.data
        ];
        console.log(this.codiceIvaData);
      }
    });

    this.configurazioneService.getGe04RegimeFiscale().subscribe(response => {
      if (response && response.data) {
        this.regimeFiscaleData =  [
          { ge04RegimeFiscale1: undefined, ge04Descrizione: '' },
          ...response.data
        ];
      }
    });

    this.configurazioneService.getGe06TipoRitenuta().subscribe(response => {
      if (response && response.data) {
        this.tipoRitenutaData =  [
          { ge06TipoRitenuta: undefined, ge06Descrizione: '' },
          ...response.data
        ];
        console.log(this.tipoRitenutaData);
      }
    });

    this.configurazioneService.getGe07CausPagRitenuta().subscribe(response => {
      if (response && response.data) {
        this.causPagRitenutaData = [
          { ge07CauPagRit: '', ge07Descrizione: '' },
          ...response.data
        ];
      }
    });
    await this.loadComuni();

    this.route.queryParams.subscribe(params => {
      console.log('Parametri della query:', params);
      if (params['id']) {
        this.dittaId = params['id'];

        console.log('ID trovato nei query parameters:', this.dittaId);
        this.loadDittaById(params['id']);
        hideSpinner((document as any).getElementById('container'));
      }
      else{
        this.loadMyDitta();
        hideSpinner((document as any).getElementById('container'));
      }


    });
  }

  async loadComuni() {
    try {
      const response = await this.configurazioneService.getGe01Comuni().toPromise();
      if (response && response.data) {
        this.comuniData = [
          {
            ge01Comune: 0, ge01Nome: ' ',
            ge01Codiceistat: '',
            ge01Provincia: '',
            ge01Regione: '',
            ge01Cap: '',
            ge01Stato: '',
            ge02CodiceStato: ''
          },
          ...response.data
        ];
      }
    } catch (error) {
      console.error('Errore nel caricamento dei comuni:', error);
    }
  }


  validateCodiceFiscale(): void {
    const cfControl = this.dittumForm.get('an01CodiceFiscale');
    if (cfControl) {
      cfControl.updateValueAndValidity();
    }
  }

  validatean01EmailContatto(): void {
    const emailControl = this.dittumForm.get('an01EmailContatto');
    if (emailControl) {
      emailControl.updateValueAndValidity();
    }
  }

  validatean01EmailFattura(): void {
    const emailControl = this.dittumForm.get('an01EmailFattura');
    if (emailControl) {
      emailControl.updateValueAndValidity();
    }
  }

  public onComuneFiltering: EmitType<FilteringEventArgs> = (e: FilteringEventArgs) => {
    // Only search when the user has typed at least 2 characters
    if (e.text.length < 2) {
      e.cancel = true;
      return;
    }
  }

  private setupIscrittoAlboListener(): void {
    this.dittumForm.get('an01IscrittoAlbo')?.valueChanges.subscribe(value => {
      if (value === 'N') {
        this.dittumForm.get('an01Albo')?.reset();
        this.dittumForm.get('an01ProvinciaAlboGe08')?.reset();
        this.dittumForm.get('an01NumeroIscrizioneAlbo')?.reset();
        this.dittumForm.get('an01DataIscrizioneAlbo')?.reset();
      }
    });
  }

  private setupCassa01Listener(): void {
    this.dittumForm.get('an01Cassa01Ge05')?.valueChanges.subscribe(value => {
      if (!value) {
        // Resetta i campi correlati quando la cassa è null
        this.dittumForm.get('an01Cassa01ConRitenuta')?.reset();
        this.dittumForm.get('an01RitenutaCassa01')?.reset();
        this.dittumForm.get('an01Codiceivacassa01Ge03')?.reset();
        this.dittumForm.get('an01Cassa02Ge05')?.reset();
        this.dittumForm.get('an01Cassa02ConRitenuta')?.reset();
        this.dittumForm.get('an01RitenutaCassa02')?.reset();
        this.dittumForm.get('an01Codiceivacassa02Ge03')?.reset();
      }
    });
  }

  private setupRivalsaInpsListener(): void {
    this.dittumForm.get('an01RivalsaInps')?.valueChanges.subscribe(value => {
      if (value === 'N') {
        // Resetta il campo della percentuale quando la rivalsa è N
        this.dittumForm.get('an01PercentualeRivalsaInps')?.reset();
      }
    });
  }

  private setupEnasarcoListener(): void {
    this.dittumForm.get('an01Enasarco')?.valueChanges.subscribe(value => {
      if (value === 'N') {
        // Resetta i campi correlati quando Enasarco è N
        this.dittumForm.get('an01PercEnasarco')?.reset();
        this.dittumForm.get('an01RitenutaEnasarco')?.reset();
      }
    });
  }

  private loadProvince(): void {
    this.configurazioneService.getGe08Provincia().subscribe({
      next: (response) => {
        if (response.data) {
          this.provinceData = response.data;
        }
      },
      error: (error) => {
        console.error('Errore nel caricamento delle province:', error);
      }
    });
  }

  private setupForfettarioListener(): void {
    this.dittumForm.get('an01Forfettario')?.valueChanges.subscribe(value => {
      this.showTipoForfettario = value === 'S';
      if (!this.showTipoForfettario) {
        this.dittumForm.get('an01TipoForfettario')?.reset();
      }
    });
  }

  private setupComuneListener(): void {
    this.dittumForm.get('an01ComuneGe01')?.valueChanges.subscribe(value => {
      if (value) {
        // Trova il comune selezionato nella lista
        const comuneSelezionato = this.comuniData.find(comune => comune.ge01Comune === value);
        if (comuneSelezionato) {
          // Imposta il CAP associato al comune
          this.dittumForm.get('an01CapDiverso')?.setValue(comuneSelezionato.ge01Cap);
        }
      }else{
          this.dittumForm.get('an01CapDiverso')?.reset();
      }
    });
  }

  createForm(): void {
    this.dittumForm = this.fb.group({
      an01TenantCf01: new FormControl(),
      an01Partitaiva: new FormControl(undefined,[ partitaIvaValidator()]),
      an01CodiceFiscale: new FormControl(undefined, [codiceFiscaleOrPartitaIvaValidator()]),
      an01IscrittoAlbo: new FormControl('N'),
      an01TipoDitta: new FormControl(),
      an01Forfettario: new FormControl(0),
      an01TipoForfettario: new FormControl(),
      an01CoefficienteRedditivita: new FormControl(),
      an01FatturaMedici: new FormControl('N'),
      an01Albo: new FormControl(),
      an01ProvinciaAlboGe08: new FormControl(),
      an01NumeroIscrizioneAlbo: new FormControl(),
      an01DataIscrizioneAlbo: new FormControl(),
      an01Nome: new FormControl(),
      an01Cognome: new FormControl(),
      an01Ragsoc: new FormControl(),
      an01Sottotitolo1: new FormControl(),
      an01Sottotitolo2: new FormControl(),
      an01IscrittoRea: new FormControl('N'),
      an01UfficioReaGe08: new FormControl(),
      an01NumeroRea: new FormControl(),
      an01CapitaleSociale: new FormControl(),
      an01SocioUnico: new FormControl(),
      an01StatoLiquidazione: new FormControl(),
      an01RegimeFiscaleGe04: new FormControl(),
      an01CodiceivaGe03: new FormControl(),
      an01Ivaagricola: new FormControl(),
      an01UtenteNotificheCf02: new FormControl(),
      an01Iban: new FormControl(),
      an01EsigibilitaIva: new FormControl(),
      an01Cassa01Ge05: new FormControl(),
      an01Cassa01ConRitenuta: new FormControl(),
      an01RitenutaCassa01: new FormControl(),
      an01Codiceivacassa01Ge03: new FormControl(),
      an01Cassa02Ge05: new FormControl(),
      an01Cassa02ConRitenuta: new FormControl(),
      an01RitenutaCassa02: new FormControl(),
      an01Codiceivacassa02Ge03: new FormControl(),
      an01TipoRitenutaGe06: new FormControl(),
      an01CausPagRitenutaGe07: new FormControl(),
      an01PercRitenuta: new FormControl(),
      an01RivalsaInps: new FormControl('N'),
      an01PercentualeRivalsaInps: new FormControl(),
      an01ComuneGe01: new FormControl(),
      an01Indirizzo: new FormControl(),
      an01NumeroCivico: new FormControl(),
      an01CapDiverso: new FormControl(),
      an01NoteIndirizzo: new FormControl(),
      an01NomeContatto: new FormControl(),
      an01EmailContatto: new FormControl(undefined, [Validators.email]),
      an01TelefonoContatto: new FormControl(),
      an01NoteContatto: new FormControl(),
      an01Sitoweb: new FormControl(),
      an01EmailFattura: new FormControl(undefined, [Validators.email]),
      an01Enasarco: new FormControl(),
      an01PercEnasarco: new FormControl(),
      an01RitenutaEnasarco: new FormControl(),
      an01TipologiaFatturaPredefinita: new FormControl(),
      an01PercContributi: new FormControl(),
      an01LogoBase641: new FormControl(),
      an01LogoBase642: new FormControl(),
      an01UserCreateCf02: new FormControl(),
      an01DataCreate: new FormControl(),
      an01UserUpdateCf02: new FormControl(),
      an01DataUpdate: new FormControl(),
      an01UserCreateCf02Email: new FormControl(),
      an01UserUpdateCf02Email: new FormControl(),
    });
  }

  ngAfterViewInit(): void {
    // Espandi tutti i pannelli dell'accordion dopo l'inizializzazione della vista
    if (this.accordion) {
      this.accordion.expandItem(true);
    }

        //disabilito campi
        this.dittumForm.get('an01UserCreateCf02Email')?.disable();
        this.dittumForm.get('an01DataCreate')?.disable();
        this.dittumForm.get('an01UserUpdateCf02Email')?.disable();
        this.dittumForm.get('an01DataUpdate')?.disable();
  }

  validatePartitaIva(): void {
    const pivaControl = this.dittumForm.get('an01Partitaiva');
    if (pivaControl) {
      pivaControl.updateValueAndValidity();
      if (pivaControl.valid && pivaControl.value) {
        console.log('Partita IVA valida:', pivaControl.value);
        // If no errors and value exists, call the service
        this.dittaService.getDatiPiva(pivaControl.value).subscribe({
          next: (aziendaData) => {
            // Update form with the received data
            this.updateFormWithAziendaData(aziendaData);
          },
          error: (err) => {
            console.error('Error fetching company data:', err);
            // Optionally show error to user
          }
        });
      }

    }
  }

  private updateFormWithAziendaData(data: AziendaCommonResponse): void {
    // Update form fields with the received data
    var comuneId= this.comuniData.find(comune => comune.ge01Nome.toUpperCase() === data.comune!.toUpperCase())?.ge01Comune;
    this.dittumForm.patchValue({
      // Mappatura diretta dei campi corrispondenti
      an01Partitaiva: data.piva,
      an01CodiceFiscale: data.codiceFiscale,
      an01Ragsoc: data.ragioneSociale,
      an01NumeroRea: data.nrea, // REA è mappato a nrea

      // Dati indirizzo
      an01Indirizzo: data.indirizzo,
      an01NumeroCivico: data.civico,

      //an01ComuneGe01: data.comune, // Assumendo che Ge01 sia il codice comune
      an01ProvinciaAlboGe08: data.provincia, // O potrebbe essere un campo separato per provincia

      // Altri campi potenzialmente correlati
      an01Sottotitolo1: data.descrizioneAteco, // Descrizione ATECO come sottotitolo
      an01Sottotitolo2: data.statoAttivitaDesc, // Stato attività come secondo sottotitolo

      // Se hai bisogno di mappare il CAP
      an01CapDiverso: data.cap, // Dipende dalla tua logica

      // Se vuoi salvare anche altre informazioni nei campi note
      // an01NoteContatto: `Codice ATECO: ${data.codiceAteco}`,

      // Eventuali altri campi che potrebbero essere derivati
      // an01TipoDitta: this.determinaTipoDitta(data.fasciaNumDipendentiISTAT),
    });
    if (comuneId!= undefined){
      this.dittumForm.get('an01ComuneGe01')?.setValue(comuneId);
    }

    // Eventuali logiche condizionali
    if (data.nrea) {
      this.dittumForm.patchValue({
        an01IscrittoRea: 'S' // Imposta automaticamente a "Sì" se c'è un numero REA
      });
    }
  }

  // Metodo per caricare i dati della ditta in base all'ID
  loadDittaById(id: string): void {
    console.log(this.comuniData)
    this.dittaService.getDittaById(id).subscribe({
      next: (ditta) => {
        this.ditta = ditta;
        // Popola il form con i dati della ditta
        this.dittumForm.patchValue(ditta);
        this.isEditMode = true;
        //this.showToast('Operazione completata con successo', 'success');

       // this.snackBar.open('Dati della ditta caricati con successo', 'Chiudi', { duration: 3000 });
      },
      error: (error) => {
        console.error('Errore durante il caricamento della ditta:', error);
        this.isEditMode = false;
        this.showToast('Crea la nuova ditta', 'error');

        //this.snackBar.open('Crea la nuova ditta', 'Chiudi', { duration: 3000 });
      }
    });
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

  loadMyDitta(): void {
    this.dittaService.getMyDitta().subscribe({
      next: (ditta) => {
        this.ditta = ditta;
        // Popola il form con i dati della ditta
        this.dittumForm.patchValue(ditta);
        this.isEditMode = true;
        //this.showToast('Operazione completata con successo', 'success');
        //this.snackBar.open('Dati della ditta caricati con successo', 'Chiudi', { duration: 3000 });
      },
      error: (error) => {
        console.error('Errore durante il caricamento della ditta:', error);
        this.isEditMode = false;
        this.showToast('Crea la nuova ditta', 'error');
        //this.snackBar.open('Crea la nuova ditta', 'Chiudi', { duration: 3000 });
      }
    });
  }

  saveForm(): void {
    if (this.dittumForm.valid) {
      // Qui andrà implementata la logica di salvataggio
      console.log('Form valido, pronto per il salvataggio:', this.dittumForm.value);
      Object.assign(this.ditta, this.dittumForm.value);
      console.log(this.ditta);
      var creazione = false;
      //this.ditta.an01TenantCf01 = this.currentTenantService.currentTenantValue!;

      // Salvataggio della ditta
      console.log(this.dittaId);
      console.log(this.isEditMode);
      if (this.dittaId){
        this.ditta.an01TenantCf01 = this.dittaId;
      }
      else{
        this.ditta.an01TenantCf01 = this.currentTenantService.currentTenantValue!;
      }
      if (this.isEditMode || this.dittaId) {
        // Aggiornamento di una ditta esistente
        this.dittaService.updateDitta( this.ditta.an01TenantCf01 , this.ditta).subscribe({
          next: (response) => {
            this.showToast('Operazione completata con successo', 'success');

            //this.snackBar.open('Ditta aggiornata con successo', 'Chiudi', { duration: 3000 });
            this.router.navigate(['/ditte']);
          },
          error: (error) => {
            console.error('Errore durante l\'aggiornamento della ditta:', error);
            this.showToast('Errore durante l\'operazione', 'error');

            //this.snackBar.open('Errore durante l\'aggiornamento della ditta', 'Chiudi', { duration: 3000 });
          }
        });
      } else {
        // Creazione di una nuova ditta
        console.log(this.dittaId);


        console.log(this.ditta);
        this.dittaService.createDitta(this.ditta).subscribe({
          next: (response) => {
            this.showToast('Operazione completata con successo', 'success');
           // this.snackBar.open('Ditta creata con successo', 'Chiudi', { duration: 3000 });
            this.router.navigate(['/ditte']);
          },
          error: (error) => {
            console.error('Errore durante la creazione della ditta:', error);
            this.showToast('Errore durante l\'operazione', 'error');

            //this.snackBar.open('Errore durante la creazione della ditta', 'Chiudi', { duration: 3000 });
          }
        });
      }
    } else {
      console.log('Form non valido, controllare i campi');
      this.showToast('Form non valido, controllare i campi obbligatori', 'error');
      //this.snackBar.open('Form non valido, controllare i campi obbligatori', 'Chiudi', { duration: 3000 });
    }
  }

  openAll(): void {
    this.isExpanded = true;
  }

  closeAll(): void {
    this.isExpanded = false;
  }

  back(): void {
    this.location.back();
  }
}
