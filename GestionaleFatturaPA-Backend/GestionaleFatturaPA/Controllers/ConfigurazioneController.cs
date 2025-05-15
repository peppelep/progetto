using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Model.DTOs;
using GestionaleFatturaPa.Data.Entities;
using System.Linq;
using GestionaleFatturaPA.Model.DTOs;
using System;
using GestionaleFatturaPA.Utility.Common.Factory;
using System.Security.Claims;

namespace GestionaleFatturaPa.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurazioneController : ControllerBase
    {
        private readonly GestionaleFatturaPaContext _context;
        private readonly IMapper _mapper;

        public ConfigurazioneController(GestionaleFatturaPaContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // Endpoint per Ge01Comuni
        [HttpGet("Ge01Comuni")]
        public async Task<RemoteResponse<IEnumerable<Ge01ComuniDto>>> GetGe01Comuni()
        {
            try
            {
                var entities = await _context.Ge01Comunis.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge01ComuniDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge01ComuniDto>>(ex.Message);
            }
        }

        [HttpGet("Ge01Comuni/{id}")]
        public async Task<RemoteResponse<Ge01ComuniDto>> GetGe01Comune(int id)
        {
            try
            {
                var entity = await _context.Ge01Comunis.FindAsync(id);
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Ge01ComuniDto>("Comune non trovato");
                }
                var dto = _mapper.Map<Ge01ComuniDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Ge01ComuniDto>(ex.Message);
            }
        }

        [HttpGet("Ge01Comuni/Descrizione/{descrizione}")]
        public async Task<RemoteResponse<IEnumerable<Ge01ComuniDto>>> GetGe01ComuniByDescrizione(string descrizione)
        {
            try
            {
                var entities = await _context.Ge01Comunis
                    .Where(e => e.Ge01Nome.Contains(descrizione))
                    .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge01ComuniDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge01ComuniDto>>(ex.Message);
            }
        }

        // Endpoint per Ge02Ruoli
        [HttpGet("Ge02Ruoli")]
        public async Task<RemoteResponse<IEnumerable<Ge02RuoliDto>>> GetGe02Ruoli()
        {
            try
            {
                var entities = await _context.Ge02Ruolis.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge02RuoliDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge02RuoliDto>>(ex.Message);
            }
        }

		[HttpGet("Ge02RuoliFiltered")]
		public async Task<RemoteResponse<IEnumerable<Ge02RuoliDto>>> GetGe02RuoliFiltered()
		{
			try
			{
				var ruoloId = Guid.Parse(User.FindFirst(ClaimTypes.Role)?.Value);
                var myRole= _context.Ge02Ruolis.FirstOrDefault(x => x.Ge02Ruolo == ruoloId);
				var entities = await _context.Ge02Ruolis.Where(x => x.Ge02Gerarchia >= myRole.Ge02Gerarchia).OrderBy(x => x.Ge02Gerarchia).ToListAsync();
				var dtos = _mapper.Map<IEnumerable<Ge02RuoliDto>>(entities);
				return RemoteResponseFactory.CreateResponse(dtos);
			}
			catch (Exception ex)
			{
				return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge02RuoliDto>>(ex.Message);
			}
		}


		[HttpGet("Ge02Ruoli/{id}")]
        public async Task<RemoteResponse<Ge02RuoliDto>> GetGe02Ruolo(int id)
        {
            try
            {
                var entity = await _context.Ge02Ruolis.FindAsync(id);
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Ge02RuoliDto>("Ruolo non trovato");
                }
                var dto = _mapper.Map<Ge02RuoliDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Ge02RuoliDto>(ex.Message);
            }
        }

        [HttpGet("Ge02Ruoli/Descrizione/{descrizione}")]
        public async Task<RemoteResponse<IEnumerable<Ge02RuoliDto>>> GetGe02RuoliByDescrizione(string descrizione)
        {
            try
            {
                var entities = await _context.Ge02Ruolis
                    .Where(e => e.Ge02Descrizione.Contains(descrizione))
                    .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge02RuoliDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge02RuoliDto>>(ex.Message);
            }
        }

        // Endpoint per Ge03Iva
        [HttpGet("Ge03Iva")]
        public async Task<RemoteResponse<IEnumerable<Ge03IvaDto>>> GetGe03Iva()
        {
            try
            {
                var entities = await _context.Ge03Ivas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge03IvaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge03IvaDto>>(ex.Message);
            }
        }

        [HttpGet("Ge03Iva/{id}")]
        public async Task<RemoteResponse<Ge03IvaDto>> GetGe03IvaById(int id)
        {
            try
            {
                var entity = await _context.Ge03Ivas.FindAsync(id);
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Ge03IvaDto>("IVA non trovata");
                }
                var dto = _mapper.Map<Ge03IvaDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Ge03IvaDto>(ex.Message);
            }
        }

        [HttpGet("Ge03Iva/Descrizione/{descrizione}")]
        public async Task<RemoteResponse<IEnumerable<Ge03IvaDto>>> GetGe03IvaByDescrizione(string descrizione)
        {
            try
            {
                var entities = await _context.Ge03Ivas
                    .Where(e => e.Ge03Descrizione.Contains(descrizione))
                    .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge03IvaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge03IvaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge04RegimeFiscale
        [HttpGet("Ge04RegimeFiscale")]
        public async Task<RemoteResponse<IEnumerable<Ge04RegimeFiscaleDto>>> GetGe04RegimeFiscale()
        {
            try
            {
                var entities = await _context.Ge04RegimeFiscales.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge04RegimeFiscaleDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge04RegimeFiscaleDto>>(ex.Message);
            }
        }

        [HttpGet("Ge04RegimeFiscale/{id}")]
        public async Task<RemoteResponse<Ge04RegimeFiscaleDto>> GetGe04RegimeFiscaleById(string id)
        {
            try
            {
                var entity = await _context.Ge04RegimeFiscales.FindAsync(id);
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Ge04RegimeFiscaleDto>("Regime fiscale non trovato");
                }
                var dto = _mapper.Map<Ge04RegimeFiscaleDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Ge04RegimeFiscaleDto>(ex.Message);
            }
        }

        [HttpGet("Ge04RegimeFiscale/Descrizione/{descrizione}")]
        public async Task<RemoteResponse<IEnumerable<Ge04RegimeFiscaleDto>>> GetGe04RegimeFiscaleByDescrizione(string descrizione)
        {
            try
            {
                var entities = await _context.Ge04RegimeFiscales
                    .Where(e => e.Ge04Descrizione.Contains(descrizione))
                    .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge04RegimeFiscaleDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge04RegimeFiscaleDto>>(ex.Message);
            }
        }

        // Endpoint per Ge05CassaProf
        [HttpGet("Ge05CassaProf")]
        public async Task<RemoteResponse<IEnumerable<Ge05CassaProfDto>>> GetGe05CassaProf()
        {
            try
            {
                var entities = await _context.Ge05CassaProfs.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge05CassaProfDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge05CassaProfDto>>(ex.Message);
            }
        }

        [HttpGet("Ge05CassaProf/{id}")]
        public async Task<RemoteResponse<Ge05CassaProfDto>> GetGe05CassaProfById(string id)
        {
            try
            {
                var entity = await _context.Ge05CassaProfs.FindAsync(id);
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Ge05CassaProfDto>("Cassa professionale non trovata");
                }
                var dto = _mapper.Map<Ge05CassaProfDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Ge05CassaProfDto>(ex.Message);
            }
        }

        [HttpGet("Ge05CassaProf/Descrizione/{descrizione}")]
        public async Task<RemoteResponse<IEnumerable<Ge05CassaProfDto>>> GetGe05CassaProfByDescrizione(string descrizione)
        {
            try
            {
                var entities = await _context.Ge05CassaProfs
                    .Where(e => e.Ge05Descrizione.Contains(descrizione))
                    .ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge05CassaProfDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge05CassaProfDto>>(ex.Message);
            }
        }

        // Endpoint per Ge08Provincia
        [HttpGet("Ge08Provincia")]
        public async Task<RemoteResponse<IEnumerable<Ge08ProvinciaDto>>> GetGe08Provincia()
        {
            try
            {
                var entities = await _context.Ge08Provincia.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge08ProvinciaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge08ProvinciaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge06TipoRitenuta
        [HttpGet("Ge06TipoRitenuta")]
        public async Task<RemoteResponse<IEnumerable<Ge06TipoRitenutumDto>>> GetGe06TipoRitenuta()
        {
            try
            {
                var entities = await _context.Ge06TipoRitenuta.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge06TipoRitenutumDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge06TipoRitenutumDto>>(ex.Message);
            }
        }

        // Endpoint per Cf07Numerazione
        [HttpGet("Cf07Numerazione")]
        public async Task<RemoteResponse<IEnumerable<Cf07NumerazioneDto>>> GetCf07Numerazione()
        {
            try
            {
                var entities = await _context.Cf07Numeraziones.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Cf07NumerazioneDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Cf07NumerazioneDto>>(ex.Message);
            }
        }

        [HttpGet("Cf07Numerazione/{tenantId}/{anno}/{causale}/{serie}")]
        public async Task<RemoteResponse<Cf07NumerazioneDto>> GetCf07NumerazioneById(Guid tenantId, int anno, int causale, string serie)
        {
            try
            {
                var entity = await _context.Cf07Numeraziones
                    .FirstOrDefaultAsync(e => e.Cf07TenantCf01 == tenantId && 
                                            e.Cg07Anno == anno && 
                                            e.Cg07CausaleGe10 == causale && 
                                            e.Cf07Serie == serie);
                
                if (entity == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf07NumerazioneDto>("Numerazione non trovata");
                }
                
                var dto = _mapper.Map<Cf07NumerazioneDto>(entity);
                return RemoteResponseFactory.CreateResponse(dto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Cf07NumerazioneDto>(ex.Message);
            }
        }

        // Endpoint per Ge09Stato
        [HttpGet("Ge09Stato")]
        public async Task<RemoteResponse<IEnumerable<Ge09StatoDto>>> GetGe09Stato()
        {
            try
            {
                var entities = await _context.Ge09Statos.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge09StatoDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge09StatoDto>>(ex.Message);
            }
        }

        // Endpoint per Ge07CausPagRitenuta
        [HttpGet("Ge07CausPagRitenuta")]
        public async Task<RemoteResponse<IEnumerable<Ge07CausPagRitenutumDto>>> GetGe07CausPagRitenuta()
        {
            try
            {
                var entities = await _context.Ge07CausPagRitenuta.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge07CausPagRitenutumDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge07CausPagRitenutumDto>>(ex.Message);
            }
        }

        // Endpoint per Ge10CauDocumento
        [HttpGet("Ge10CauDocumento")]
        public async Task<RemoteResponse<IEnumerable<Ge10CauDocumentoDto>>> GetGe10CauDocumento()
        {
            try
            {
                var entities = await _context.Ge10CauDocumentos.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge10CauDocumentoDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge10CauDocumentoDto>>(ex.Message);
            }
        }

        // Endpoint per Ge11Valutum
        [HttpGet("Ge11Valutum")]
        public async Task<RemoteResponse<IEnumerable<Ge11ValutumDto>>> GetGe11Valutum()
        {
            try
            {
                var entities = await _context.Ge11Valuta.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge11ValutumDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge11ValutumDto>>(ex.Message);
            }
        }

        // Endpoint per Ge12Lingua
        [HttpGet("Ge12Lingua")]
        public async Task<RemoteResponse<IEnumerable<Ge12LinguaDto>>> GetGe12Lingua()
        {
            try
            {
                var entities = await _context.Ge12Linguas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge12LinguaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge12LinguaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge13ModelloStampa
        [HttpGet("Ge13ModelloStampa")]
        public async Task<RemoteResponse<IEnumerable<Ge13ModelloStampaDto>>> GetGe13ModelloStampa()
        {
            try
            {
                var entities = await _context.Ge13ModelloStampas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge13ModelloStampaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge13ModelloStampaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge14Um
        [HttpGet("Ge14Um")]
        public async Task<RemoteResponse<IEnumerable<Ge14UmDto>>> GetGe14Um()
        {
            try
            {
                var entities = await _context.Ge14Ums.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge14UmDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge14UmDto>>(ex.Message);
            }
        }

        // Endpoint per Ge15ModalitaPagFepa
        [HttpGet("Ge15ModalitaPagFepa")]
        public async Task<RemoteResponse<IEnumerable<Ge15ModalitaPagFepaDto>>> GetGe15ModalitaPagFepa()
        {
            try
            {
                var entities = await _context.Ge15ModalitaPagFepas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge15ModalitaPagFepaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge15ModalitaPagFepaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge16AltriDatiFepa
        [HttpGet("Ge16AltriDatiFepa")]
        public async Task<RemoteResponse<IEnumerable<Ge16AltriDatiFepaDto>>> GetGe16AltriDatiFepa()
        {
            try
            {
                var entities = await _context.Ge16AltriDatiFepas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge16AltriDatiFepaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge16AltriDatiFepaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge17CondPagFepa
        [HttpGet("Ge17CondPagFepa")]
        public async Task<RemoteResponse<IEnumerable<Ge17CondPagFepaDto>>> GetGe17CondPagFepa()
        {
            try
            {
                var entities = await _context.Ge17CondPagFepas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge17CondPagFepaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge17CondPagFepaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge18TipoDocFepa
        [HttpGet("Ge18TipoDocFepa")]
        public async Task<RemoteResponse<IEnumerable<Ge18TipoDocFepaDto>>> GetGe18TipoDocFepa()
        {
            try
            {
                var entities = await _context.Ge18TipoDocFepas.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge18TipoDocFepaDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge18TipoDocFepaDto>>(ex.Message);
            }
        }

        // Endpoint per Ge19TipocessionePrestazione
        [HttpGet("Ge19TipocessionePrestazione")]
        public async Task<RemoteResponse<IEnumerable<Ge19TipocessionePrestazioneDto>>> GetGe19TipocessionePrestazione()
        {
            try
            {
                var entities = await _context.Ge19TipocessionePrestaziones.ToListAsync();
                var dtos = _mapper.Map<IEnumerable<Ge19TipocessionePrestazioneDto>>(entities);
                return RemoteResponseFactory.CreateResponse(dtos);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Ge19TipocessionePrestazioneDto>>(ex.Message);
            }
        }

   

        // Endpoint per le altre tabelle... (seguendo lo stesso schema)
    }
}
