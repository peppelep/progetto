import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { An01DittumDTO } from '../models/dto/an/an01-dittum.dto';
import { API_BASE_URL, API_ENDPOINTS } from '../config/global-url.config';
import { RemoteResponse } from '../models/RemoteResponse';
import { AziendaCommonResponse } from '../models/aziendaCommonResponse';

@Injectable({
  providedIn: 'root'
})
export class DittaService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.DITTA;

  constructor(private http: HttpClient) { }

  getDitte(): Observable<An01DittumDTO[]> {
    return this.http.get<RemoteResponse<An01DittumDTO[]>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento delle ditte');
          }
          return response.data || [];
        })
      );
  }

  getDittaById(id: string): Observable<An01DittumDTO> {
    return this.http.get<RemoteResponse<An01DittumDTO>>(`${this.apiUrl}/GetById/${id}`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento della ditta');
          }
          return response.data || {} as An01DittumDTO;
        })
      );
  }

  createDitta(ditta: An01DittumDTO): Observable<An01DittumDTO> {
    return this.http.post<RemoteResponse<An01DittumDTO>>(`${this.apiUrl}/Create`, ditta)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione della ditta');
          }
          return response.data || {} as An01DittumDTO;
        })
      );
  }

  updateDitta(id: string, ditta: An01DittumDTO): Observable<An01DittumDTO> {
    return this.http.put<RemoteResponse<An01DittumDTO>>(`${this.apiUrl}/Update/${id}`, ditta)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento della ditta');
          }
          return response.data || {} as An01DittumDTO;
        })
      );
  }

  getDatiPiva(pIva: string): Observable<AziendaCommonResponse> {
    return this.http.get<RemoteResponse<AziendaCommonResponse>>(`${this.apiUrl}/GetDatiPiva/${pIva}`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel recupero dei dati della ditta');
          }
          return response.data || {} as AziendaCommonResponse;
        })
      );
  }

  deleteDitta(id: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(`${this.apiUrl}/Delete/${id}`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella cancellazione della ditta');
          }
          return response.data || false;
        })
      );
  }

  getDitteByTenantId(tenantId: string): Observable<An01DittumDTO[]> {
    return this.http.get<RemoteResponse<An01DittumDTO[]>>(`${this.apiUrl}/GetByTenantId/${tenantId}`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento delle ditte per il tenant');
          }
          return response.data || [];
        })
      );
  }

  getMyDitta(): Observable<An01DittumDTO> {
    return this.http.get<RemoteResponse<An01DittumDTO>>(`${this.apiUrl}/GetMyDitta`)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento delle ditte per il tenant');
          }
          return response.data || {} as An01DittumDTO;
        })
      );
  }
}
