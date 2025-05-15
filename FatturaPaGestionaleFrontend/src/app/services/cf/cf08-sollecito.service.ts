import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf08SollecitoDto } from '../../models/dto/cf/cf08-sollecito.dto';
import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class Cf08SollecitoService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.SOLLECITO;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cf08SollecitoDto[]> {
    return this.http.get<RemoteResponse<Cf08SollecitoDto[]>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei Solleciti');
          }
          return response.data || [];
        })
      );
  }

  getAllFiltered(filter: PaginatedRequest): Observable<PaginatedResult<Cf08SollecitoDto>> {
    return this.http.post<RemoteResponse<PaginatedResult<Cf08SollecitoDto>>>(this.apiUrl+"/GetAllPaginated",filter)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei Solleciti');
          }
          return response.data || {} as PaginatedResult<Cf08SollecitoDto>;;
        })
      );
  }

  get(sollecito: string): Observable<Cf08SollecitoDto[]> {
    return this.http.get<RemoteResponse<Cf08SollecitoDto[]>>(this.apiUrl + '/' + sollecito)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento del Sollecito');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf08SollecitoDto): Observable<Cf08SollecitoDto> {
    return this.http.post<RemoteResponse<Cf08SollecitoDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del Sollecito');
          }
          return response.data || {} as Cf08SollecitoDto;
        })
      );
  }

  update(dto: Cf08SollecitoDto): Observable<Cf08SollecitoDto> {
    return this.http.put<RemoteResponse<Cf08SollecitoDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del Sollecito');
          }
          return response.data || {} as Cf08SollecitoDto;
        })
      );
  }

  delete(sollecito: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + sollecito)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del Sollecito');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
