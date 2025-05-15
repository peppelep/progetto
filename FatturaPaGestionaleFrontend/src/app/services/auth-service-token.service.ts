import { HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceTokenService implements HttpInterceptor {

  constructor() { }

  intercept(req: HttpRequest<any>, res: HttpHandler): Observable<HttpEvent<any>>{
    let header= sessionStorage.getItem('token')
    if (localStorage.getItem('token')!=null){

      header=localStorage.getItem('token')
    }
    req=req.clone({
      setHeaders: { 'Authorization':'Bearer '+ header}
    })
    return res.handle(req)
  }
}
