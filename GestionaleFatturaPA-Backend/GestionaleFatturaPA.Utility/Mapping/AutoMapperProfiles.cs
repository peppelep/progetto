using AutoMapper;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPa.Model.DTOs;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Model.DTOs.Do;

namespace GestionaleFatturaPA.Utility.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            TwoWayMap<An01Dittum, An01DittumDTO>();
            TwoWayMap<An02Anagrafica, An02AnagraficaDto>();

            CreateMap<Cf01TenantDto, Cf01Tenant>();
			CreateMap<Cf01Tenant, Cf01TenantDto>()
		   .ForMember(dest => dest.An01Ragsoc, opt => opt.MapFrom(src => src.An01Dittum.An01Ragsoc))
		   .ForMember(dest => dest.An01CodiceFiscale, opt => opt.MapFrom(src => src.An01Dittum.An01CodiceFiscale))
		   .ForMember(dest => dest.An01Partitaiva, opt => opt.MapFrom(src => src.An01Dittum.An01Partitaiva));

			CreateMap<Cf02Utente, Cf02UtenteDto>()
						   .ForMember(dest => dest.Ge02Descrizione, opt => opt.MapFrom(src => src.Cf02RuoloGe02Navigation.Ge02Descrizione));
			CreateMap<Cf02UtenteDto, Cf02Utente>();
			TwoWayMap<Cf04Conto, Cf04ContoDto>();
			TwoWayMap<Cf05Pagamento, Cf05PagamentoDto>();
			TwoWayMap<Cf06ClassArticolo, Cf06ClassArticoloDto>();
            TwoWayMap<Cf07Numerazione, Cf07NumerazioneDto>();
            TwoWayMap<Cf08Sollecito, Cf08SollecitoDto>();
            TwoWayMap<Cf08Smtp, Cf08SmtpDto>();

			

            TwoWayMap<Do01TestataDocumento, Do01TestataDocumentoDto>();
            TwoWayMap<Do02Scadenze, Do02ScadenzeDto>();
            TwoWayMap<Do03DocorigineFepa, Do03DocorigineFepaDto>();
            TwoWayMap<Do04PagamentoFepa, Do04PagamentoFepaDto>();
            TwoWayMap<Do05AltridatiFepa, Do05AltridatiFepaDto>();
            TwoWayMap<Do10CorpoDocumento, Do10CorpoDocumentoDto>();
            TwoWayMap<Do20Castellettoiva, Do20CastellettoivaDto>();


            TwoWayMap<Ge01Comuni, Ge01ComuniDto>();
            TwoWayMap<Ge02Ruoli, Ge02RuoliDto>();
            TwoWayMap<Ge03Iva, Ge03IvaDto>();
            TwoWayMap<Ge04RegimeFiscale, Ge04RegimeFiscaleDto>();
            TwoWayMap<Ge05CassaProf, Ge05CassaProfDto>();
            TwoWayMap<Ge06TipoRitenutum, Ge06TipoRitenutumDto>();
            TwoWayMap<Ge07CausPagRitenutum, Ge07CausPagRitenutumDto>();
            TwoWayMap<Ge08Provincium, Ge08ProvinciaDto>();
            TwoWayMap<Ge09Stato, Ge09StatoDto>();
            TwoWayMap<Ge10CauDocumento, Ge10CauDocumentoDto>();
            TwoWayMap<Ge11Valutum, Ge11ValutumDto>();
            TwoWayMap<Ge12Lingua, Ge12LinguaDto>();
            TwoWayMap<Ge13ModelloStampa, Ge13ModelloStampaDto>();
            TwoWayMap<Ge14Um, Ge14UmDto>();
            TwoWayMap<Ge15ModalitaPagFepa, Ge15ModalitaPagFepaDto>();
            TwoWayMap<Ge16AltriDatiFepa, Ge16AltriDatiFepaDto>();
            TwoWayMap<Ge17CondPagFepa, Ge17CondPagFepaDto>();
            TwoWayMap<Ge18TipoDocFepa, Ge18TipoDocFepaDto>();
            TwoWayMap<Ge19TipocessionePrestazione, Ge19TipocessionePrestazioneDto>();
            TwoWayMap<Cf07Numerazione, Cf07NumerazioneDto>();
        }

        public void TwoWayMap<A, B>()
        {
            CreateMap<A, B>();
            CreateMap<B, A>();
        }
    }
}
