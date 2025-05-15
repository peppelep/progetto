import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { An02AnagraficaDto, AnagraficaCreate, AnagraficaFilter, AnagraficaList, AnagraficaUpdate} from '../models/dto/an/an02-anagrafica.dto';
import { API_BASE_URL, API_ENDPOINTS } from '../config/global-url.config';
import { RemoteResponse } from '../models/RemoteResponse';
import { PaginatedRequest, PaginatedResult } from '../models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class AnagraficaService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.ANAGRAFICA;

  constructor(private http: HttpClient) { }

  getAnagrafiche(filter?: PaginatedRequest): Observable<RemoteResponse<PaginatedResult<An02AnagraficaDto>>> {
    return this.http.post<RemoteResponse<PaginatedResult<An02AnagraficaDto>>>(`${this.apiUrl}/GetAllPaginated`,filter);
  }

  getAnagrafica(anagraficaId: string): Observable<RemoteResponse<An02AnagraficaDto>> {
    return this.http.get<RemoteResponse<An02AnagraficaDto>>(`${this.apiUrl}/${anagraficaId}`);
  }

  createAnagrafica(anagrafica: An02AnagraficaDto): Observable<RemoteResponse<An02AnagraficaDto>> {
    return this.http.post<RemoteResponse<An02AnagraficaDto>>(this.apiUrl, anagrafica);
  }

  updateAnagrafica(anagrafica: An02AnagraficaDto): Observable<RemoteResponse<An02AnagraficaDto>> {
    return this.http.put<RemoteResponse<An02AnagraficaDto>>(this.apiUrl, anagrafica);
  }

  deleteAnagrafica(tenantId: string, tipoAnagrafica: string, anagraficaId: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${tenantId}/${tipoAnagrafica}/${anagraficaId}`);
  }

}
