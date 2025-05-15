import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf06ClassArticoloDto } from '../../models/dto/cf/cf06-class-articolo.dto';

@Injectable({
  providedIn: 'root'
})
export class Cf06ClassArticoloService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.CLASS_ARTICOLO;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cf06ClassArticoloDto[]> {
    return this.http.get<RemoteResponse<Cf06ClassArticoloDto[]>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei ClassArticoli');
          }
          return response.data || [];
        })
      );
  }

  get(classArticolo: string): Observable<Cf06ClassArticoloDto[]> {
    return this.http.get<RemoteResponse<Cf06ClassArticoloDto[]>>(this.apiUrl + '/' + classArticolo)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento del ClassArticolo');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf06ClassArticoloDto): Observable<Cf06ClassArticoloDto> {
    return this.http.post<RemoteResponse<Cf06ClassArticoloDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del ClassArticolo');
          }
          return response.data || {} as Cf06ClassArticoloDto;
        })
      );
  }

  update(dto: Cf06ClassArticoloDto): Observable<Cf06ClassArticoloDto> {
    return this.http.put<RemoteResponse<Cf06ClassArticoloDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del ClassArticolo');
          }
          return response.data || {} as Cf06ClassArticoloDto;
        })
      );
  }

  delete(classArticolo: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + classArticolo)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del ClassArticolo');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
