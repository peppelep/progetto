import { Component, OnInit, ViewChild } from '@angular/core';
import { TenantService } from '../../services/cf/cf01-tenant.service';
import { Tenant } from '../../models/dto/cf/cf01-tenant.dto';
import { DialogComponent } from '@syncfusion/ej2-angular-popups';
import { PageService, FilterService, SortService, PageSettingsModel, GridComponent, FilterSettingsModel, ActionEventArgs } from '@syncfusion/ej2-angular-grids';
import { CommonModule } from '@angular/common';
import { ButtonModule } from '@syncfusion/ej2-angular-buttons';
import { TenantDialogComponent } from '../tenant-dialog/tenant-dialog.component';
import { Router } from '@angular/router';
import { FieldFilter, PaginatedRequest } from 'src/app/models/filterSettings';


@Component({
  selector: 'app-tenant-list',
  templateUrl: './tenant-list.component.html',
  styleUrls: ['./tenant-list.component.css'],
  standalone: false
})
export class TenantListComponent implements OnInit {
  @ViewChild('dialog') dialog!: DialogComponent;
  @ViewChild('grid') grid!: GridComponent;

  public locale: string = 'it-IT';
  public filterSettings: FilterSettingsModel = {
    type: 'Menu',
    enableCaseSensitivity: true,
    mode: 'Immediate'
  };

  public data: any[] = [];
  public selectedTenant: Tenant | null = null;
  public editSettings!: Object;
  public toolbar!: string[];

  public filter : PaginatedRequest = {}
  public pageSettings!: PageSettingsModel;

  constructor(
    private tenantService: TenantService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.editSettings = { allowEditing: true, allowAdding: true, allowDeleting: true };
    this.toolbar = ['Add', 'Edit', 'Delete', 'Update', 'Cancel'];
    this.pageSettings = { pageSize: 10 };
    this.filter = {
      pageIndex: 1,
      pageSize: this.pageSettings.pageSize,
      fieldFilters: []
    }
    this.loadTenants();
  }


  loadTenants(): void {
    this.tenantService.getTenants().subscribe({
      next: (tenants) => {
        this.data = tenants;
        console.log('Tenants loaded:', this.data);
        if (this.grid) {
          this.grid.refresh();
        }
      },
      error: (error) => {
        console.error('Errore durante il caricamento dei tenant:', error);
      }
    });
  }

  openTenantDialog(): void {
    this.selectedTenant = null;
    this.dialog.header = 'Nuovo Tenant';
    this.dialog.show();
  }

  closeTenantDialog(): void {
    this.dialog.hide();
    this.selectedTenant = null;
  }

  saveTenant(tenant: Tenant): void {
    if (this.selectedTenant) {
      // Aggiorna il tenant esistente
      this.tenantService.updateTenant(tenant).subscribe({
        next: (response) => {
          this.closeTenantDialog();
          this.loadTenants();
        },
        error: (error) => {
          console.error('Errore durante l\'aggiornamento del tenant:', error);
        }
      });
    } else {
      // Crea un nuovo tenant
      this.tenantService.createTenant(tenant).subscribe({
        next: (response) => {
          this.closeTenantDialog();
          this.loadTenants();
        },
        error: (error) => {
          console.error('Errore durante il salvataggio del tenant:', error);
        }
      });
    }
  }

  editTenant(tenant: Tenant): void {
    this.selectedTenant = { ...tenant };
    this.dialog.header = 'Modifica Tenant';
    this.dialog.show();
  }

  deleteTenant(tenant: Tenant): void {
    if (confirm('Sei sicuro di voler eliminare questo tenant?')) {
      tenant.cf01Deleted = true;
      this.tenantService.updateTenant(tenant).subscribe({
        next: (response) => {
          this.loadTenants();
        },
        error: (error) => {
          console.error('Errore durante l\'eliminazione del tenant:', error);
        }
      });
    }
  }

  openAnagraficaDitta(id: number, ragSociale: string){
    this.router.navigate(['/tenants/ditta'], {
      queryParams: {
        id: id,
        ragSociale: ragSociale
      }
    });
  }

  pulisciFiltri(): void {
    this.filter.fieldFilters = [];
    this.loadTenants();
    this.grid.clearFiltering();
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
        this.loadTenants();
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
        this.loadTenants();
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
          this.loadTenants();
    }
  }

}
