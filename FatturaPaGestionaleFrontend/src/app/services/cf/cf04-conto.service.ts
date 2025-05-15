import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';

import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';
import { Cf04ContoDto } from 'src/app/models/dto/cf/cf04-conto.dto';

@Injectable({
    providedIn: 'root'
  })
  export class Cf04ContoService {
    private apiUrl = API_BASE_URL + API_ENDPOINTS.CONTO;

    constructor(private http: HttpClient) { }

    getAll( request: PaginatedRequest): Observable<PaginatedResult<Cf04ContoDto>> {
      return this.http.post<RemoteResponse<PaginatedResult<Cf04ContoDto>>>(this.apiUrl+"/GetAllPaginated", request)
        .pipe(
          map(response => {
            if (response.hasError) {
              throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei Conti');
            }
            return response.data || {
              items: [],
              totalCount: 0,
              pageIndex: 0,
              pageSize: 0,
              totalPages: 0
            };
          })
        );
    }

    get(conto: string): Observable<Cf04ContoDto[]> {
      return this.http.get<RemoteResponse<Cf04ContoDto[]>>(this.apiUrl + '/' + conto)
        .pipe(
          map(response => {
            if (response.hasError) {
              throw new Error(response.error?.errorMessage || 'Errore nel caricamento del Conto');
            }
            return response.data || [];
          })
        );
    }

    create(dto: Cf04ContoDto): Observable<Cf04ContoDto> {
      return this.http.post<RemoteResponse<Cf04ContoDto>>(this.apiUrl, dto)
        .pipe(
          map(response => {
            if (response.hasError) {
              throw new Error(response.error?.errorMessage || 'Errore nella creazione del Conto');
            }
            return response.data || {} as Cf04ContoDto;
          })
        );
    }

    update(dto: Cf04ContoDto): Observable<Cf04ContoDto> {
      return this.http.put<RemoteResponse<Cf04ContoDto>>(this.apiUrl, dto)
        .pipe(
          map(response => {
            if (response.hasError) {
              throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del Conto');
            }
            return response.data || {} as Cf04ContoDto;
          })
        );
    }

    delete(conto: string): Observable<boolean> {
      return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + conto)
        .pipe(
          map(response => {
            if (response.hasError) {
              throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del Conto');
            }
            return response.data || {} as boolean;
          })
        );
    }
  }
