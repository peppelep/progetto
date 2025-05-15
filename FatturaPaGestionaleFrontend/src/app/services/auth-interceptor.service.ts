import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, tap } from 'rxjs';
import jwt_decode from "jwt-decode";


@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor{

  constructor(private router:Router) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      tap(
        (event: HttpEvent<any>) => {},
        (error) => {

          if (error.status === 401) {

            this.logout()

          }

        }
      )
    );
    }


  isLogged(): boolean {
    var token= sessionStorage.getItem("token")
    if (token==null) token=localStorage.getItem("token")
    if (token==null) return false

    if (! this.isTokenExpired(token!))return true;
      return false;

  }

  isTokenExpired(accessToken: string): boolean {
    const decodedToken: any = jwt_decode(accessToken);
    const expirationDate = new Date(decodedToken.exp * 1000); // Converte la data di scadenza da UNIX timestamp a una data JavaScript

    // Verifica se la data di scadenza è nel passato
    return expirationDate < new Date();
  }


    logout(){

      if (sessionStorage.getItem("token")!=null)
        sessionStorage.clear()
      else
        localStorage.clear()

      this.router.navigate(['/login']);
    }




}
