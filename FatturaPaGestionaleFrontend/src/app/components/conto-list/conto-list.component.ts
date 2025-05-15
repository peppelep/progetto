import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { GridComponent, FilterSettingsModel, ToolbarItems, EditSettingsModel, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { ClickEventArgs } from '@syncfusion/ej2-angular-navigations';
import { ToastComponent, ToastPositionModel } from '@syncfusion/ej2-angular-notifications';
import { Cf04ContoDto } from 'src/app/models/dto/cf/cf04-conto.dto';
import { Cf04ContoService } from 'src/app/services/cf/cf04-conto.service';
import { FieldFilter, PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Component({
  selector: 'app-conto-list',
  templateUrl: './conto-list.component.html',
  styleUrls: ['./conto-list.component.css'],
  standalone:false
})
export class ContoListComponent implements OnInit {
  @ViewChild('grid') public grid!: GridComponent;
  @ViewChild('contoDialog') public contoDialog!: DialogComponent;
  @ViewChild('toast') public toast!: ToastComponent;
  public locale: string = 'it-IT';
  constructor(private contoService: Cf04ContoService) {}

  public conti: Cf04ContoDto[] = [];
  public error: string | null = null;
  public selectedConto: Cf04ContoDto = {} as Cf04ContoDto;
  public dialogHeader: string = '';
  public filter: PaginatedRequest = {
    pageIndex: 1,
    pageSize: 10,
    fieldFilters: []
  };
  public pageSettings!: PageSettingsModel;

  // Configurazione della griglia Syncfusion
  public filterSettings: FilterSettingsModel = { type: 'Menu' };
  public toolbar: ToolbarItems[] = ['Add', 'Search'];
  public editSettings: EditSettingsModel = { allowEditing: true, allowAdding: true, allowDeleting: true, mode: 'Dialog' };

  // Configurazione del toast
  public toastPosition: ToastPositionModel = { X: 'Right', Y: 'Top' };

  // Configurazione dei pulsanti del dialog
  public dialogButtons: Object[] = [];
  tipiAnagraficaOptions = [
    { value: 'S', text: 'Standard' },
    { value: 'B', text: 'Bancario' }
  ];
  ngOnInit(): void {
    this.pageSettings = { pageSize: 10};
    this.filter = {
      pageIndex: 1,
      pageSize: this.pageSettings.pageSize,
    }
    this.loadConti();
  }

  loadConti(): void {
    this.error = null;
    console.log('Request:', this.filter);
    this.contoService.getAll(this.filter).subscribe({
      next: (result: PaginatedResult<Cf04ContoDto>) => {
        this.conti = result.items;
      },
      error: (err: { message: string; }) => {
        this.error = err.message || 'Si è verificato un errore durante il caricamento dei conti';
        this.showToast(this.error, 'error');
      }
    });
  }

  // Gestione filtri
  onFiltering(args: any): void {



    this.loadConti();
  }
  getTipoAnagraficaLabel(value: string): string {
    const tipo = this.tipiAnagraficaOptions.find(x => x.value === value);
    return tipo ? tipo.text : 'N/D';
  }

  onActionBegin(args: any): void {
    const filters = args.currentFilterObject;
    if (args.action === 'filter') {
      if (filters) {
        let payload : FieldFilter = {
            field: filters!.field!,
            operator: filters!.operator,
            value: filters!.value?.toString()!
            }

        this.filter.fieldFilters?.push(payload)
        this.loadConti();
      }
      else if (args.action === 'clearFilter') {
        let colums= filters!.field;
        if(colums){
          this.filter.fieldFilters = this.filter.fieldFilters?.filter(f => f.field !== colums);
          console.log(this.filter);
          // Fai la chiamata manuale al backend
          this.loadConti();
        }
        // Previeni l'esecuzione automatica del filtro da parte della griglia
        //args.cancel = true;
      }
      else if (args.requestType === 'paging') {
        console.log(this.pageSettings);
          this.filter = {
              pageIndex: args.currentPage,
              pageSize: this.pageSettings.pageSize,
            }
            this.loadConti();
      }
      // Previeni l'esecuzione automatica del filtro da parte della griglia
      //args.cancel = true;
    }

  }

  openContoDialog(conto?: Cf04ContoDto): void {
    this.selectedConto = conto ? {...conto} : {} as Cf04ContoDto;
    console.log('Selected Conto:', this.selectedConto);
    this.dialogHeader = conto ? 'Modifica Conto' : 'Nuovo Conto';
    this.contoDialog.show();
  }

  dialogClose(): void {
    this.contoDialog.hide();
  }

  onSaveComplete(result?: Cf04ContoDto): void {
    if (result) {
      this.loadConti();
      this.showToast('Operazione completata con successo', 'success');
    }
    this.dialogClose();
  }

  deleteConto(conto: Cf04ContoDto): void {
    this.contoService.delete(conto.cf04Conto1!).subscribe({
      next: () => {
        // Rimuove il conto dalla lista locale
        this.conti = this.conti.filter(c => c.cf04Conto1 !== conto.cf04Conto1);
        this.showToast('Conto eliminato con successo', 'success');
      },
      error: (err: { message: string; }) => {
        this.error = err.message || 'Si è verificato un errore durante l\'eliminazione del conto';
        this.showToast(this.error, 'error');
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

  pulisciFiltri(): void {
    this.filter.fieldFilters = []
    this.loadConti();
    this.grid.clearFiltering();

  }
}
