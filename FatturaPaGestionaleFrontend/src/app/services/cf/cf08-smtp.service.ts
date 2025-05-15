import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { API_BASE_URL, API_ENDPOINTS } from '../../config/global-url.config';
import { RemoteResponse } from '../../models/RemoteResponse';
import { Cf08SmtpDto } from '../../models/dto/cf/cf08-smtp.dto';
import { PaginatedRequest, PaginatedResult } from 'src/app/models/filterSettings';

@Injectable({
  providedIn: 'root'
})
export class Cf08SmtpService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.SMTP;

  constructor(private http: HttpClient) { }

  get(): Observable<Cf08SmtpDto> {
    return this.http.get<RemoteResponse<Cf08SmtpDto>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei Smtp');
          }
          return response.data || {} as Cf08SmtpDto;
        })
      );
  }

  getAllFiltered(filter: PaginatedRequest): Observable<PaginatedResult<Cf08SmtpDto>> {
    return this.http.get<RemoteResponse<PaginatedResult<Cf08SmtpDto>>>(this.apiUrl)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nel caricamento dei Smtp');
          }
          return response.data || {} as PaginatedResult<Cf08SmtpDto>;
        })
      );
  }



  create(dto: Cf08SmtpDto): Observable<Cf08SmtpDto> {
    return this.http.post<RemoteResponse<Cf08SmtpDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nella creazione del Smtp');
          }
          return response.data || {} as Cf08SmtpDto;
        })
      );
  }

  update(dto: Cf08SmtpDto): Observable<Cf08SmtpDto> {
    return this.http.put<RemoteResponse<Cf08SmtpDto>>(this.apiUrl, dto)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'aggiornamento del Smtp');
          }
          return response.data || {} as Cf08SmtpDto;
        })
      );
  }

  delete(smtp: string): Observable<boolean> {
    return this.http.delete<RemoteResponse<boolean>>(this.apiUrl + '/' + smtp)
      .pipe(
        map(response => {
          if (response.hasError) {
            throw new Error(response.error?.errorMessage || 'Errore nell\'eliminazione del Smtp');
          }
          return response.data || {} as boolean;
        })
      );
  }
}
