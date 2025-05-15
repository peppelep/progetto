import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { Tenant } from '../../models/dto/cf/cf01-tenant.dto';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';

@Injectable({
  providedIn: 'root'
})
export class TenantService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.TENANT;

  constructor(private http: HttpClient) { }

  getTenants(): Observable<Tenant[]> {
    return this.http.get<RemoteResponse<Tenant[]>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei tenant');
          }
          return response.data || [];
        })
      );
  }

  getTenantById(id: string): Observable<Tenant> {
    return this.http.get<RemoteResponse<Tenant>>(`${this.apiUrl}/${id}`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento del tenant');
          }
          return response.data || {} as Tenant;
        })
      );
  }

  createTenant(tenant: Tenant): Observable<Tenant> {
    return this.http.post<RemoteResponse<Tenant>>(this.apiUrl, tenant)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del tenant');
          }
          return response.data || {} as Tenant;
        })
      );
  }

  updateTenant(tenant: Tenant): Observable<Tenant> {
    return this.http.put<RemoteResponse<Tenant>>(this.apiUrl, tenant)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del tenant');
          }
          return response.data || {} as Tenant;
        })
      );
  }
}
