import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//material modules
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatExpansionModule} from '@angular/material/expansion';

// Syncfusion Modules
import { ButtonModule, CheckBoxModule } from '@syncfusion/ej2-angular-buttons';
import { CalendarModule, DatePickerModule } from '@syncfusion/ej2-angular-calendars';
import { DropDownListModule } from '@syncfusion/ej2-angular-dropdowns';
import { NumericTextBoxModule, TextBoxModule } from '@syncfusion/ej2-angular-inputs';
import { ListViewModule } from '@syncfusion/ej2-angular-lists';
import { DialogModule } from '@syncfusion/ej2-angular-popups';
import { TabModule, ToolbarModule, MenuModule } from '@syncfusion/ej2-angular-navigations';
import { SplitButtonModule } from '@syncfusion/ej2-angular-splitbuttons';
import { DocumentEditorModule } from '@syncfusion/ej2-angular-documenteditor';
import { ToastModule } from '@syncfusion/ej2-angular-notifications';
import { EditService, FilterService, GridModule, PagerModule, PageService, SortService, ToolbarService } from '@syncfusion/ej2-angular-grids';
import { SidebarModule } from '@syncfusion/ej2-angular-navigations';
import { TooltipModule } from '@syncfusion/ej2-angular-popups';
import { TreeViewModule } from '@syncfusion/ej2-angular-navigations';
import { AccordionModule } from '@syncfusion/ej2-angular-navigations';
import { BreadcrumbModule } from '@syncfusion/ej2-angular-navigations';


// Syncfusion License
import { registerLicense } from '@syncfusion/ej2-base';
registerLicense('ORg4AjUWIQA/Gnt2XFhhQlJHfV5AQmBIYVp/TGpJfl96cVxMZVVBJAtUQF1hTH5QdURjUH5WcHZWTmFaWkZ/');

// App Modules
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { TenantListComponent } from './components/tenant-list/tenant-list.component';
import { TenantDialogComponent } from './components/tenant-dialog/tenant-dialog.component';
import { LoginComponent } from './components/login/login.component';
import { initializeSyncfusionLocale } from './config/syncfusion-locale.config';
import { DittaFormComponent } from './components/ditta-form/ditta-form.component';
import { AuthInterceptorService } from './services/auth-interceptor.service';
import { AuthServiceTokenService } from './services/auth-service-token.service';
import { InterceptorService } from './services/interceptor.service';
import { UtenteFormComponent } from './components/utente-form/utente-form.component';
import { UtenteListComponent } from './components/utente-list/utente-list.component';
import { ProfiloUtenteComponent } from './components/profilo-utente/profilo-utente.component';
import { ContoDialogComponent } from './components/conto-dialog/conto-dialog.component';
import { ContoListComponent } from './components/conto-list/conto-list.component';

// Inizializza la localizzazione di Syncfusion
initializeSyncfusionLocale();

@NgModule({
  declarations: [
    AppComponent,
    TenantListComponent,
    TenantDialogComponent,
    LoginComponent,
    DittaFormComponent,
    UtenteFormComponent,
    UtenteListComponent,
    ProfiloUtenteComponent,
    ContoDialogComponent,
    ContoListComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    //material Modules
    MatIconModule,
    MatButtonModule,
    FormsModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatExpansionModule,
    // Syncfusion Modules
    BreadcrumbModule,
    TreeViewModule,
    ButtonModule,
    CalendarModule,
    DropDownListModule,
    TextBoxModule,
    ListViewModule,
    DialogModule,
    TabModule,
    ToolbarModule,
    MenuModule,
    SplitButtonModule,
    DocumentEditorModule,
    ToastModule,
    GridModule,
    PagerModule,
    DatePickerModule,
    CheckBoxModule,
    SidebarModule,
    TooltipModule,
    ReactiveFormsModule,
    NumericTextBoxModule,
    AccordionModule
  ],
  providers: [FilterService, SortService, PageService,EditService,ToolbarService,
    {provide: HTTP_INTERCEPTORS, useClass: InterceptorService, multi:true},
    {provide:HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi:true },
    {provide: HTTP_INTERCEPTORS, useClass: AuthServiceTokenService, multi:true},
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
