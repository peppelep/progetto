import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf03ParametriConfDto } from '../../models/dto/cf/cf03-parametri-conf.dto';

@Injectable({
  providedIn: 'root'
})
export class Cf03ParametriConfService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.PARAMETRI_CONF;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Cf03ParametriConfDto[]> {
    return this.http.get<RemoteResponse<Cf03ParametriConfDto[]>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei ParametriConf');
          }
          return response.data || [];
        })
      );
  }

  get(parametro: string): Observable<Cf03ParametriConfDto[]> {
    return this.http.get<RemoteResponse<Cf03ParametriConfDto[]>>(this.apiUrl + '/' + parametro)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento del ParametroConf');
          }
          return response.data || [];
        })
      );
  }

  create(dto: Cf03ParametriConfDto): Observable<Cf03ParametriConfDto> {
    return this.http.post<RemoteResponse<Cf03ParametriConfDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del ParametroConf');
          }
          return response.data || {} as Cf03ParametriConfDto;
        })
      );
  }

  update(dto: Cf03ParametriConfDto): Observable<Cf03ParametriConfDto> {
    return this.http.put<RemoteResponse<Cf03ParametriConfDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del ParametroConf');
          }
          return response.data || {} as Cf03ParametriConfDto;
        })
      );
  }

  delete(parametro: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + parametro)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del ParametroConf');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
