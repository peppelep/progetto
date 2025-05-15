import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isAuthenticatedSubject = new BehaviorSubject<boolean>(false);
  isAuthenticated$ = this.isAuthenticatedSubject.asObservable();

  login(username: string, password: string): boolean {
    // TODO: Implementare la logica di autenticazione reale
    // Per ora simuliamo un login riuscito
    this.isAuthenticatedSubject.next(true);
    return true;
  }

  logout() {
    this.isAuthenticatedSubject.next(false);
  }
}
