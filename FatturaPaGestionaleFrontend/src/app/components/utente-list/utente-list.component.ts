import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { PageService, FilterService, SortService, PageSettingsModel, GridComponent, FilterSettingsModel, ActionEventArgs } from '@syncfusion/ej2-angular-grids';
import { Router } from '@angular/router';
import { FieldFilter, FilterSettings, PaginatedRequest } from 'src/app/models/filterSettings';
import { CurrentTenantService } from 'src/app/services/current-tenant.service';
import { RemoteResponse } from 'src/app/models/RemoteResponse';
import { Cf02UtenteDto } from 'src/app/models/dto/cf/cf02-utente.dto';
import { Cf02UtenteService } from 'src/app/services/cf/cf02-utente.service';

@Component({
  selector: 'app-utente-list',
  templateUrl: './utente-list.component.html',
  styleUrls: ['./utente-list.component.css'],
  standalone: false
})
export class UtenteListComponent implements OnInit {
  @ViewChild('dialog') dialog!: DialogComponent;
  @ViewChild('grid') grid!: GridComponent;

  public tenantId: string = '';
  public locale: string = 'it-IT';
  public dialogHeader: string = 'Nuovo Utente';
  public filterSettings: FilterSettingsModel = {
    type: 'Menu',
    enableCaseSensitivity: true,
    mode: 'Immediate'
  };

  public pageSettings!: PageSettingsModel;
  public filter : PaginatedRequest = {}
  public utenti: Cf02UtenteDto[] = [];
  public selectedUtente: Cf02UtenteDto | null = null;
  constructor(
    private router: Router,
    private currentTenantService: CurrentTenantService,
    private utenteService: Cf02UtenteService
  ) {}

  ngOnInit(): void {
    this.pageSettings = { pageSize: 10};
    this.filter = {
      pageIndex: 1,
      pageSize: this.pageSettings.pageSize,
    }
    this.tenantId = this.currentTenantService.currentTenantValue!;
    this.pageSettings = { pageSize: 1};
    this.filter = {
      pageIndex: 1,
      pageSize: this.pageSettings.pageSize,
    }
    this.loadUtenti();
  }

  async loadUtenti() {
    var ret = await this.utenteService.getAllFiltered(this.filter).toPromise();
    this.utenti = ret?.items || [];
    // Trasforma i valori in booleani
    this.utenti = this.utenti.map(utente => ({
      ...utente,
      cf02Fornitori: Boolean(utente.cf02Fornitori),
      cf02Clienti: Boolean(utente.cf02Clienti),
      cf02Primanota: Boolean(utente.cf02Primanota)
    }));
    console.log(this.utenti);
  }

  openUtenteDialog(): void {
    this.selectedUtente = null;
    this.dialog.header = 'Nuovo Utente';
    this.dialog.show();
  }

  openUtenteDialogEdit(utente: Cf02UtenteDto): void {
    this.selectedUtente = utente;
    console.log(this.selectedUtente);
    this.dialog.header = 'Modifica Utente';
    this.dialog.show();
  }

  closeUtenteDialog(): void {
    this.dialog.hide();
    this.selectedUtente = null;
    this.loadUtenti();
  }


  deleteUtente(utente: Cf02UtenteDto): void {
    if (confirm('Sei sicuro di voler eliminare questo utente?')) {
       this.utenteService.delete(utente.cf02Utente1!).subscribe({
         next: () => {
           this.loadUtenti();
         },
         error: (error) => {
           console.error('Errore durante l\'eliminazione dell\'utente:', error);
         }
       });
    }
  }

  onPageChange(event: any): void {
    this.loadUtenti();
  }



  onActionBegin(args: ActionEventArgs): void {
    console.log(args);
    const filters = args.currentFilterObject;
    if (args.action === 'filter') {
      if (filters) {
        let payload : FieldFilter = {
            field: filters!.field!,
            operator: filters!.operator,
            value: filters!.value?.toString()!
            }

        this.filter.fieldFilters?.push(payload)
        this.loadUtenti();
      }
      // Previeni l'esecuzione automatica del filtro da parte della griglia
      //args.cancel = true;
    }
    else if (args.action === 'clearFilter') {
      let colums= filters!.field;
      if(colums){
        this.filter.fieldFilters = this.filter.fieldFilters?.filter(f => f.field !== colums);
        console.log(this.filter);
        // Fai la chiamata manuale al backend
        this.loadUtenti();
      }
    }
    else if (args.requestType === 'paging') {
      console.log(this.pageSettings);
        this.filter = {
            pageIndex: args.currentPage,
            pageSize: this.pageSettings.pageSize,
          }
          this.loadUtenti();
    }
  }

  pulisciFiltri(): void {
    this.filter.fieldFilters = [];
    this.loadUtenti();
    this.grid.clearFiltering();
  }
}
