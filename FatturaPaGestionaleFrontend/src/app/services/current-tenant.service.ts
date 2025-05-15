import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CurrentTenantService {


  private currentTenantSubject: BehaviorSubject<string | null>;
  public currentTenant$: Observable<string | null>;

  constructor() {
    // Inizializza con il tenant salvato in localStorage (se presente)
    const savedTenant = this.getTenantFromStorage();
    this.currentTenantSubject = new BehaviorSubject<string | null>(savedTenant);
    this.currentTenant$ = this.currentTenantSubject.asObservable();
  }

  private getTenantFromStorage(): string | null {
    // Cerca prima in sessionStorage, poi in localStorage
    return sessionStorage.getItem('currentTenant') || localStorage.getItem('currentTenant');
  }

  // Getter per il valore corrente
  public get currentTenantValue(): string | null {
    return this.currentTenantSubject.value;
  }

  // Metodo per impostare il tenant
  setTenantLocal(tenant: string): void {
    // Salva in localStorage per persistenza
    localStorage.setItem('currentTenant', tenant);
    // Aggiorna il BehaviorSubject
    this.currentTenantSubject.next(tenant);
  }

  setTenantSession(tenant: string): void {
    // Salva in localStorage per persistenza
    sessionStorage.setItem('currentTenant', tenant);
    // Aggiorna il BehaviorSubject
    this.currentTenantSubject.next(tenant);
  }
  // Metodo per rimuovere il tenant (logout)
  clearTenant(): void {
    // Rimuovi da localStorage se presente
    if (localStorage.getItem('currentTenant')) {
      localStorage.removeItem('currentTenant');
    }
    // Rimuovi da sessionStorage se presente
    if (sessionStorage.getItem('currentTenant')) {
      sessionStorage.removeItem('currentTenant');
    }
    // Aggiorna il BehaviorSubject
    this.currentTenantSubject.next(null);
  }
}
