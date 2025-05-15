import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf05PagamentoDto } from '../../models/dto/cf/cf05-pagamento.dto';
import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class Cf05PagamentoService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.PAGAMENTO;

  constructor(private http: HttpClient) { }

  getAll(request: PaginatedRequest):  Observable<PaginatedResult<Cf05PagamentoDto>>{
    return this.http.post<RemoteResponse<PaginatedResult<Cf05PagamentoDto>>>(this.apiUrl+"/GetAllPaginated", request)
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

  get(pagamento: string): Observable<Cf05PagamentoDto[]> {
    return this.http.get<RemoteResponse<Cf05PagamentoDto[]>>(this.apiUrl + '/' + pagamento)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento del Pagamento');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf05PagamentoDto): Observable<Cf05PagamentoDto> {
    console.log('create:', dto);
    return this.http.post<RemoteResponse<Cf05PagamentoDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del Pagamento');
          }
          return response.data || {} as Cf05PagamentoDto;
        })
      );
  }

  update(dto: Cf05PagamentoDto): Observable<Cf05PagamentoDto> {
    return this.http.put<RemoteResponse<Cf05PagamentoDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del Pagamento');
          }
          return response.data || {} as Cf05PagamentoDto;
        })
      );
  }

  delete(pagamento: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + pagamento)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del Pagamento');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
