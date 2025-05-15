import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// DTOs
import { Ge01ComuniDto } from '../models/dto/ge/ge01-comuni.dto';
import { Ge02RuoliDto } from '../models/dto/ge/ge02-ruoli.dto';
import { Ge03IvaDto } from '../models/dto/ge/ge03-iva.dto';
import { Ge04RegimeFiscaleDto } from '../models/dto/ge/ge04-regime-fiscale.dto';
import { Ge05CassaProfDto } from '../models/dto/ge/ge05-cassa-prof.dto';
import { Ge06TipoRitenutumDto } from '../models/dto/ge/ge06-tipo-ritenutum.dto';
import { Ge07CausPagRitenutumDto } from '../models/dto/ge/ge07-caus-pag-ritenutum.dto';
import { Ge08ProvinciaDto } from '../models/dto/ge/ge08-provincia.dto';
import { Ge09StatoDto } from '../models/dto/ge/ge09-stato.dto';
import { Ge10CauDocumentoDto } from '../models/dto/ge/ge10-cau-documento.dto';
import { Ge11ValutumDto } from '../models/dto/ge/ge11-valutum.dto';
import { Ge12LinguaDto } from '../models/dto/ge/ge12-lingua.dto';
import { Ge13ModelloStampaDto } from '../models/dto/ge/ge13-modello-stampa.dto';
import { Ge14UmDto } from '../models/dto/ge/ge14-um.dto';
import { Ge15ModalitaPagFepaDto } from '../models/dto/ge/ge15-modalita-pag-fepa.dto';
import { Ge16AltriDatiFepaDto } from '../models/dto/ge/ge16-altri-dati-fepa.dto';
import { Ge17CondPagFepaDto } from '../models/dto/ge/ge17-cond-pag-fepa.dto';
import { Ge18TipoDocFepaDto } from '../models/dto/ge/ge18-tipo-doc-fepa.dto';
import { Ge19TipocessionePrestazioneDto } from '../models/dto/ge/ge19-tipocessione-prestazione.dto';
import { RemoteResponse } from '../models/RemoteResponse';
import { API_BASE_URL, API_ENDPOINTS } from '../config/global-url.config';

@Injectable({
  providedIn: 'root'
})
export class ConfigurazioneService {
  private apiUrl = API_BASE_URL + API_ENDPOINTS.CONFIGURAZIONE;

  constructor(private http: HttpClient) { }

  // Ge01Comuni
  getGe01Comuni(): Observable<RemoteResponse<Ge01ComuniDto[]>> {
    return this.http.get<RemoteResponse<Ge01ComuniDto[]>>(`${this.apiUrl}/Ge01Comuni`);
  }

  getGe01Comune(id: number): Observable<RemoteResponse<Ge01ComuniDto>> {
    return this.http.get<RemoteResponse<Ge01ComuniDto>>(`${this.apiUrl}/Ge01Comuni/${id}`);
  }

  getGe01ComuniByDescrizione(descrizione: string): Observable<RemoteResponse<Ge01ComuniDto[]>> {
    return this.http.get<RemoteResponse<Ge01ComuniDto[]>>(`${this.apiUrl}/Ge01Comuni/Descrizione/${descrizione}`);
  }

  // Ge02Ruoli
  getGe02Ruoli(): Observable<RemoteResponse<Ge02RuoliDto[]>> {
    return this.http.get<RemoteResponse<Ge02RuoliDto[]>>(`${this.apiUrl}/Ge02Ruoli`);
  }

  //filtered per ruolo
  getGe02RuoliFiltered(): Observable<RemoteResponse<Ge02RuoliDto[]>> {
    return this.http.get<RemoteResponse<Ge02RuoliDto[]>>(`${this.apiUrl}/Ge02RuoliFiltered`);
  }

  getGe02Ruolo(id: number): Observable<RemoteResponse<Ge02RuoliDto>> {
    return this.http.get<RemoteResponse<Ge02RuoliDto>>(`${this.apiUrl}/Ge02Ruoli/${id}`);
  }

  getGe02RuoliByDescrizione(descrizione: string): Observable<RemoteResponse<Ge02RuoliDto[]>> {
    return this.http.get<RemoteResponse<Ge02RuoliDto[]>>(`${this.apiUrl}/Ge02Ruoli/Descrizione/${descrizione}`);
  }

  // Ge03Iva
  getGe03Iva(): Observable<RemoteResponse<Ge03IvaDto[]>> {
    return this.http.get<RemoteResponse<Ge03IvaDto[]>>(`${this.apiUrl}/Ge03Iva`);
  }

  getGe03IvaById(id: number): Observable<RemoteResponse<Ge03IvaDto>> {
    return this.http.get<RemoteResponse<Ge03IvaDto>>(`${this.apiUrl}/Ge03Iva/${id}`);
  }

  getGe03IvaByDescrizione(descrizione: string): Observable<RemoteResponse<Ge03IvaDto[]>> {
    return this.http.get<RemoteResponse<Ge03IvaDto[]>>(`${this.apiUrl}/Ge03Iva/Descrizione/${descrizione}`);
  }

  // Ge04RegimeFiscale
  getGe04RegimeFiscale(): Observable<RemoteResponse<Ge04RegimeFiscaleDto[]>> {
    return this.http.get<RemoteResponse<Ge04RegimeFiscaleDto[]>>(`${this.apiUrl}/Ge04RegimeFiscale`);
  }

  getGe04RegimeFiscaleById(id: string): Observable<RemoteResponse<Ge04RegimeFiscaleDto>> {
    return this.http.get<RemoteResponse<Ge04RegimeFiscaleDto>>(`${this.apiUrl}/Ge04RegimeFiscale/${id}`);
  }

  getGe04RegimeFiscaleByDescrizione(descrizione: string): Observable<RemoteResponse<Ge04RegimeFiscaleDto[]>> {
    return this.http.get<RemoteResponse<Ge04RegimeFiscaleDto[]>>(`${this.apiUrl}/Ge04RegimeFiscale/Descrizione/${descrizione}`);
  }

  // Ge05CassaProf
  getGe05CassaProf(): Observable<RemoteResponse<Ge05CassaProfDto[]>> {
    return this.http.get<RemoteResponse<Ge05CassaProfDto[]>>(`${this.apiUrl}/Ge05CassaProf`);
  }

  getGe05CassaProfById(id: string): Observable<RemoteResponse<Ge05CassaProfDto>> {
    return this.http.get<RemoteResponse<Ge05CassaProfDto>>(`${this.apiUrl}/Ge05CassaProf/${id}`);
  }

  getGe05CassaProfByDescrizione(descrizione: string): Observable<RemoteResponse<Ge05CassaProfDto[]>> {
    return this.http.get<RemoteResponse<Ge05CassaProfDto[]>>(`${this.apiUrl}/Ge05CassaProf/Descrizione/${descrizione}`);
  }

  // Ge06TipoRitenuta
  getGe06TipoRitenuta(): Observable<RemoteResponse<Ge06TipoRitenutumDto[]>> {
    return this.http.get<RemoteResponse<Ge06TipoRitenutumDto[]>>(`${this.apiUrl}/Ge06TipoRitenuta`);
  }

  // Ge07CausPagRitenuta
  getGe07CausPagRitenuta(): Observable<RemoteResponse<Ge07CausPagRitenutumDto[]>> {
    return this.http.get<RemoteResponse<Ge07CausPagRitenutumDto[]>>(`${this.apiUrl}/Ge07CausPagRitenuta`);
  }

  // Ge08Provincia
  getGe08Provincia(): Observable<RemoteResponse<Ge08ProvinciaDto[]>> {
    return this.http.get<RemoteResponse<Ge08ProvinciaDto[]>>(`${this.apiUrl}/Ge08Provincia`);
  }

  // Ge09Stato
  getGe09Stato(): Observable<RemoteResponse<Ge09StatoDto[]>> {
    return this.http.get<RemoteResponse<Ge09StatoDto[]>>(`${this.apiUrl}/Ge09Stato`);
  }

  // Ge10CauDocumento
  getGe10CauDocumento(): Observable<RemoteResponse<Ge10CauDocumentoDto[]>> {
    return this.http.get<RemoteResponse<Ge10CauDocumentoDto[]>>(`${this.apiUrl}/Ge10CauDocumento`);
  }

  // Ge11Valutum
  getGe11Valutum(): Observable<RemoteResponse<Ge11ValutumDto[]>> {
    return this.http.get<RemoteResponse<Ge11ValutumDto[]>>(`${this.apiUrl}/Ge11Valutum`);
  }

  // Ge12Lingua
  getGe12Lingua(): Observable<RemoteResponse<Ge12LinguaDto[]>> {
    return this.http.get<RemoteResponse<Ge12LinguaDto[]>>(`${this.apiUrl}/Ge12Lingua`);
  }

  // Ge13ModelloStampa
  getGe13ModelloStampa(): Observable<RemoteResponse<Ge13ModelloStampaDto[]>> {
    return this.http.get<RemoteResponse<Ge13ModelloStampaDto[]>>(`${this.apiUrl}/Ge13ModelloStampa`);
  }

  // Ge14Um
  getGe14Um(): Observable<RemoteResponse<Ge14UmDto[]>> {
    return this.http.get<RemoteResponse<Ge14UmDto[]>>(`${this.apiUrl}/Ge14Um`);
  }

  // Ge15ModalitaPagFepa
  getGe15ModalitaPagFepa(): Observable<RemoteResponse<Ge15ModalitaPagFepaDto[]>> {
    return this.http.get<RemoteResponse<Ge15ModalitaPagFepaDto[]>>(`${this.apiUrl}/Ge15ModalitaPagFepa`);
  }

  // Ge16AltriDatiFepa
  getGe16AltriDatiFepa(): Observable<RemoteResponse<Ge16AltriDatiFepaDto[]>> {
    return this.http.get<RemoteResponse<Ge16AltriDatiFepaDto[]>>(`${this.apiUrl}/Ge16AltriDatiFepa`);
  }

  // Ge17CondPagFepa
  getGe17CondPagFepa(): Observable<RemoteResponse<Ge17CondPagFepaDto[]>> {
    return this.http.get<RemoteResponse<Ge17CondPagFepaDto[]>>(`${this.apiUrl}/Ge17CondPagFepa`);
  }

  // Ge18TipoDocFepa
  getGe18TipoDocFepa(): Observable<RemoteResponse<Ge18TipoDocFepaDto[]>> {
    return this.http.get<RemoteResponse<Ge18TipoDocFepaDto[]>>(`${this.apiUrl}/Ge18TipoDocFepa`);
  }

  // Ge19TipocessionePrestazione
  getGe19TipocessionePrestazione(): Observable<RemoteResponse<Ge19TipocessionePrestazioneDto[]>> {
    return this.http.get<RemoteResponse<Ge19TipocessionePrestazioneDto[]>>(`${this.apiUrl}/Ge19TipocessionePrestazione`);
  }
}
