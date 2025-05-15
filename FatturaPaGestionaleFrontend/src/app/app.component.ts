import { Component, OnInit, ViewChild } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { AuthService } from './services/auth.service';
import { LoaderService } from './services/loader.service';
import { LoginService } from './services/login.service';
import { SelectEventArgs } from '@syncfusion/ej2-angular-lists';
import { NodeSelectEventArgs, SidebarComponent } from '@syncfusion/ej2-angular-navigations';


interface SidebarSettings {
  width: string;
  position: 'Left' | 'Right';
  type: 'Over' | 'Push' | 'Slide';
  target: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  standalone: false,

})
export class AppComponent implements OnInit {
  title = 'Gestionale Fattura PA';
  isSidebarOpen = true;
  isAuthenticated = false;
  showFiller = false;
  breadcrumbItems: { [key: string]: Object }[] = [];



  public treeData: { [key: string]: Object }[] = [
    { id: "0", name: "Partners", url: '/tenants', iconCss: 'e-icons e-user-defined' },
    { id: "1", name: "Configurazione", hasChild: true, expanded: false, iconCss: 'e-icons e-settings' },
    { id: "2", name: "Ditta", pid: "1", url: '/ditta', iconCss: 'e-icons e-home' },
    { id: "3", name: "Account Personale", pid:"1", url: '/utente', iconCss: 'e-icons e-user' },
    { id: "4", name: "Utenti e Permessi", pid:"1", url: '/utenteList', iconCss: 'e-icons e-people' },
    { id: "5", name: "Conti Saldo", pid: "1", url: '/conto', iconCss: 'e-icons e-list-box' },
    { id: "6", name: "Metodi di Pagamento", pid:"1", url: '/pagamento', iconCss: 'e-icons e-number-formatting' },
    { id: "7", name: "Configurazione SMTP", pid:"1", url: '/smtp', iconCss: 'e-icons e-send-1' }, //e-web-layout
    //{ id: "8", name: "Classificazione", pid:"1", url: '/ditta', iconCss: 'e-icons e-filtered-sort-descending' },
    { id: "9", name: "Solleciti Automatici", pid:"1", url: '/sollecito', iconCss: 'e-icons e-annotation-edit' },
    { id: "10", name: "Numerazione", pid:"1", url: '/numerazione', iconCss: 'e-icons e-restart-at-1' },

    { id: "11", name: "Anagrafiche", hasChild: true, expanded: false, iconCss: 'e-icons e-people' },
    { id: "12", name: "Clienti", pid:"11", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "13", name: "Fornitori", pid:"11", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "14", name: "Articoli", pid:"11", url: '/anagrafica/articoli', iconCss: 'e-icons e-volume' },

    { id: "15", name: "Documenti", hasChild: true, expanded: false, iconCss: 'e-icons e-description' },
    { id: "16", name: "Clienti", pid:"15", hasChild: true, expanded: false, iconCss: 'e-icons e-home' },
    { id: "17", name: "Preventivo", pid:"16", url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "18", name: "Rapp. Intervento", pid:"16",url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "19", name: "Ordine", pid:"16",url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "20", name: "Pro Forma", pid:"16", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "21", name: "Fattura", pid:"16", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "22", name: "DDT", pid:"16", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "23", name: "Ricevuta", pid:"16", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "24", name: "Nota Credito", pid:"16", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "25", name: "Auto-Fattura", pid:"16", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "26", name: "Corrispettivo", pid:"16", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "27", name: "Fattura Riepilogativa", pid:"16", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },

    { id: "28", name: "Fornitori", pid:"15", hasChild: true, expanded: false, iconCss: 'e-icons e-home' },
    { id: "29", name: "Preventivo", pid:"28", url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "30", name: "Ordine", pid:"28",url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "31", name: "Fattura", pid:"28", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "32", name: "DDT", pid:"28", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "33", name: "Ricevuta", pid:"28", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "34", name: "Nota Credito", pid:"28", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },
    { id: "35", name: "Fattura Riepilogativa", pid:"28", url: '/anagrafica/fornitori', iconCss: 'e-icons e-user' },

    { id: "36", name: "Interni", pid:"15", hasChild: true, expanded: false, iconCss: 'e-icons e-home' },
    { id: "37", name: "Scarico Merci", pid:"36", url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },
    { id: "38", name: "Carico Merci", pid:"36",url: '/anagrafica/clienti', iconCss: 'e-icons e-home' },


    { id: "39", name: "Contabilità Generale", hasChild:true, expanded:false, iconCss: 'e-icons e-user' },
    { id: "40", name: "Prima Nota", pid:"39", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' },
    { id: "41", name: "F24", pid:"39", url: '/anagrafica/clienti', iconCss: 'e-icons e-user' }

];

public treeFields: { [key: string]: Object } = {
  dataSource: this.treeData,
  id: "id",
  text: "name",
  selected: "selected",
  parentID: "pid",
  hasChildren: "hasChild",
  expanded: "expanded",
  url: "url",
  iconCss: "iconCss"
};


  constructor(
    private router: Router,
    private authService: AuthService,
    private loginService: LoginService
  ) {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
        this.updateBreadcrumb(event.url);
      }
    });
  }

  ngOnInit() {
    this.updateBreadcrumb(this.router.url);
  }

  // private updateBreadcrumb(url: string) {
  //   const segments = url.split('/').filter(segment => segment);
  //   this.breadcrumbItems = segments.map((segment, index) => {
  //     const path = '/' + segments.slice(0, index + 1).join('/');
  //     return {
  //       text: this.getBreadcrumbLabel(segment),
  //       url: path
  //     };
  //   });
  // }

  // private getBreadcrumbLabel(segment: string): string {
  //   const labels: { [key: string]: string } = {
  //     'tenants': 'Partners',
  //     'ditta': 'Ditta',
  //     'conto': 'Conti Saldo',
  //     'anagrafica': 'Anagrafiche',
  //     'fornitori': 'Fornitori',
  //     'clienti': 'Clienti',
  //     'pagamento': 'Metodi di Pagamento',
  //     'utente': 'Profilo Utente',
  //     'utenteList': 'Utenti e Permessi',
  //     'smtp': 'Configurazione SMTP',
  //     'sollecito': 'Solleciti Automatici'
  //   };
  //   return labels[segment] || segment;
  // }


  private updateBreadcrumb(url: string): void {
    const urlTree = this.router.parseUrl(url);
    const segments = urlTree.root.children['primary']?.segments || [];
    const queryParams = urlTree.queryParams;

    this.breadcrumbItems = [];

    segments.forEach((segment, index) => {
      const path = '/' + segments.slice(0, index + 1).map(s => s.path).join('/');

       // Se il segmento è "tenants", lo mostriamo come "Partners"
      // if (segment.path.toLowerCase() === 'tenants') {
      //   this.breadcrumbItems.push({
      //     text: this.getBreadcrumbLabel(segment.path),
      //     url: path
      //   });
      // }

      // Se il segmento è "ditta" e c'è la ragione sociale, lo mostriamo come "Ditta <nome>"
      if (segment.path.toLowerCase() === 'ditta' && queryParams['ragSociale']) {
        const ragioneSociale = this.formatRagioneSociale(decodeURIComponent(queryParams['ragSociale']));
        this.breadcrumbItems.push({
          text: `Ditta ${ragioneSociale}`,
          url: path
        });
      }
      else
      { // Altri segmenti gestiti normalmente
        this.breadcrumbItems.push({
          text: this.getBreadcrumbLabel(segment.path),
          url: path
        });
      }
    });
  }

  private getBreadcrumbLabel(segment: string): string {
    const labels: { [key: string]: string } = {
      'tenants': 'Partners',
      'ditta': 'Ditta',
      'conto': 'Conti Saldo',
      'anagrafica': 'Anagrafiche',
      'fornitori': 'Fornitori',
      'clienti': 'Clienti',
      'pagamento': 'Metodi di Pagamento',
      'utente': 'Profilo Utente',
      'utenteList': 'Utenti e Permessi',
      'smtp': 'Configurazione SMTP',
      'sollecito': 'Solleciti Automatici'
    };
    return labels[segment] || segment;
  }

  private formatRagioneSociale(value: string): string {
    return value
      .toLowerCase()
      .split(' ')
      .map(word => word.charAt(0).toUpperCase() + word.slice(1))
      .join(' ');
  }


  getLogin(){
    return this.loginService.isLogged();
  }

  toggleSidebar() {
    this.isSidebarOpen = !this.isSidebarOpen;
  }

  logout() {
    this.loginService.logoutStorage();
    this.loginService.logoutSession();
    this.router.navigate(['/login']);
  }

  toggleFiller() {
    this.showFiller = !this.showFiller;
  }

  onSelect(args: any) {
    console.log(args.nodeData);
    const selectedId = args.nodeData.id;
    const selectedItem = this.treeData.find(item => item['id'] === selectedId);
    if (selectedItem!['url']) {
      this.router.navigate([selectedItem!['url']]);
    }
  }

  onListSelect(args: SelectEventArgs) {
    args.item.classList.remove("e-active");
  }
}
