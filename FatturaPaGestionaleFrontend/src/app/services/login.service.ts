import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginDto } from '../models/dto/loginDto';
import { Observable } from 'rxjs';
import { Auth } from '../models/auth';
import { Router } from '@angular/router';
import jwt_decode from "jwt-decode";
import { API_BASE_URL, API_ENDPOINTS } from '../config/global-url.config';
import { CurrentTenantService } from './current-tenant.service';
import { RemoteResponse } from '../models/RemoteResponse';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.UTENTE;
  public logged: boolean=false;
  public errorMessage: string="";
  constructor(private http: HttpClient,
    private router: Router,
    private currentTenant: CurrentTenantService)
  { }

  async loginSession(loginDto: LoginDto):Promise<Auth> {
    var ret=<Auth>await this.http.post(this.apiUrl+"/auth",loginDto).toPromise();
    if (ret.data?.error== true){
      this.errorMessage=ret.data?.errorDescription!;
      sessionStorage.clear();
    }
    else{
      sessionStorage.setItem("token", ret.data?.token!);
      sessionStorage.setItem("guidUtente", ret.data?.guidUtente!);
      sessionStorage.setItem("ruolo", ret.data?.ruolo!)
      sessionStorage.setItem("email", ret.data?.email!)
      sessionStorage.setItem("cf", ret.data?.cf!)
      sessionStorage.setItem("isLogged","true");
      sessionStorage.setItem("initials", ret.data?.initials!);
      //TenantId
      sessionStorage.setItem("tenantId", ret.data?.tenantId!);
      this.currentTenant.setTenantSession(ret.data?.tenantId!);

    }
    return  ret;
  }

  async loginStorage(loginDto:LoginDto): Promise<Auth>{
    var ret=<Auth> await this.http.post(this.apiUrl+"/auth",loginDto).toPromise();
    if (ret?.data?.error== true){
      this.errorMessage=ret.data?.errorDescription!;
      localStorage.clear();
    }
    else {
      localStorage.setItem("token", ret.data?.token!);
      localStorage.setItem("guidUtente", ret.data?.guidUtente!);
      localStorage.setItem("ruolo", ret.data?.ruolo!)
      localStorage.setItem("email", ret.data?.email!)
      localStorage.setItem("cf", ret.data?.cf!)
      localStorage.setItem("isLogged","true");
      localStorage.setItem("initials", ret.data?.initials!);
      sessionStorage.setItem("tenantId", ret.data?.tenantId!);
      this.currentTenant.setTenantLocal(ret.data?.tenantId!);
    }
    return ret;
  }

  logoutStorage(){
    localStorage.clear();
    this.router.navigate(['/login']);
  }


  logoutSession(){
    sessionStorage.clear();
    this.router.navigate(['/login']);
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

  getUserInfo(cf: string): Observable<any> {
    return this.http.get(this.apiUrl+"Utente/search/"+cf);
  }

  ripristinaPassword(credenziali:LoginDto): Observable<RemoteResponse<boolean>> {
    return this.http.get<RemoteResponse<boolean>>(this.apiUrl+"Utente/ResetPassword/"+credenziali);
  }

/*
  insertUser(user: User): Observable<any> {
    return this.http.post("")
  }
*/

}
