import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf02UtenteDto } from 'src/app/models/dto/cf/cf02-utente.dto';
import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class Cf02UtenteService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.UTENTE;

  constructor(private http: HttpClient) { }

  getAllFiltered(filter: PaginatedRequest): Observable<PaginatedResult<Cf02UtenteDto>> {
    return this.http.post<RemoteResponse<PaginatedResult<Cf02UtenteDto>>>(this.apiUrl+"/GetAllPaginated", filter)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento degli Utenti');
          }
          return response.data || {} as PaginatedResult<Cf02UtenteDto>;
        })
      );
  }

  getCurrent(): Observable<Cf02UtenteDto> {
    return this.http.get<RemoteResponse<Cf02UtenteDto>>(this.apiUrl + '/' + "current")
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dell\'Utente');
          }
          return response.data || {} as Cf02UtenteDto;
        })
      );
  }

  getUtenteById(utenteId: string): Observable<RemoteResponse<Cf02UtenteDto>> {
    return this.http.get<RemoteResponse<Cf02UtenteDto>>(`${this.apiUrl}/${utenteId}`);
  }


  get(utente: string): Observable<Cf02UtenteDto[]> {
    return this.http.get<RemoteResponse<Cf02UtenteDto[]>>(this.apiUrl + '/' + utente)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dell\'Utente');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf02UtenteDto): Observable<Cf02UtenteDto> {
    return this.http.post<RemoteResponse<Cf02UtenteDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione dell\'Utente');
          }
          return response.data || {} as Cf02UtenteDto;
        })
      );
  }

  update(dto: Cf02UtenteDto): Observable<Cf02UtenteDto> {
    return this.http.put<RemoteResponse<Cf02UtenteDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento dell\'Utente');
          }
          return response.data || {} as Cf02UtenteDto;
        })
      );
  }

  delete(utente: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + utente)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione dell\'Utente');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
