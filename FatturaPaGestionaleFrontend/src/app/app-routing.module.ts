import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TenantListComponent } from './components/tenant-list/tenant-list.component';
import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { DittaFormComponent } from './components/ditta-form/ditta-form.component';
import { ProfiloUtenteComponent } from './components/profilo-utente/profilo-utente.component';
import { UtenteListComponent } from './components/utente-list/utente-list.component';
import { ContoListComponent } from './components/conto-list/conto-list.component';

const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  //{ path: 'sign', component: RipristinaPasswordComponent },
  { path: 'tenants', component: TenantListComponent},
  { path: 'tenants/ditta', component: DittaFormComponent },
  { path: 'ditta', component: DittaFormComponent },
  //{ path: 'ditta/:id', component: DittaFormComponent },
  { path: 'utente', component: ProfiloUtenteComponent },
  { path: 'utenteList', component: UtenteListComponent },
  { path: 'conto', component: ContoListComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
