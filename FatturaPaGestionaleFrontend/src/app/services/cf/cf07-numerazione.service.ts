import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf07NumerazioneDto } from '../../models/dto/cf/cf07-numerazione.dto';
import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class Cf07NumerazioneService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.NUMERAZIONE;

  constructor(private http: HttpClient) { }

  getAll(filter?: PaginatedRequest): Observable<RemoteResponse<PaginatedResult<Cf07NumerazioneDto>>> {
    return this.http.post<RemoteResponse<PaginatedResult<Cf07NumerazioneDto>>>(`${this.apiUrl}/GetAll`,filter);
  }

  get(numerazione: string): Observable<Cf07NumerazioneDto[]> {
    return this.http.get<RemoteResponse<Cf07NumerazioneDto[]>>(this.apiUrl + '/' + numerazione)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento della Numerazione');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf07NumerazioneDto): Observable<Cf07NumerazioneDto> {
    return this.http.post<RemoteResponse<Cf07NumerazioneDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione della Numerazione');
          }
          return response.data || {} as Cf07NumerazioneDto;
        })
      );
  }

  update(dto: Cf07NumerazioneDto): Observable<Cf07NumerazioneDto> {
    return this.http.put<RemoteResponse<Cf07NumerazioneDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento della Numerazione');
          }
          return response.data || {} as Cf07NumerazioneDto;
        })
      );
  }

  delete(dto: Cf07NumerazioneDto): Observable<boolean> {
    return this.http.post<RemoteResponse<boolean>>(this.apiUrl + '/delete' , dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione della Numerazione');
          }
          return response.data || {} as boolean;
        })
      );
  }

  getAllFiltered(filter: PaginatedRequest): Observable<PaginatedResult<Cf07NumerazioneDto>> {
    return this.http.post<RemoteResponse<PaginatedResult<Cf07NumerazioneDto>>>(this.apiUrl + "/GetAllPaginated", filter)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento delle Numerazioni');
          }
          return response.data || {} as PaginatedResult<Cf07NumerazioneDto>;
        })
      );
  }
}
