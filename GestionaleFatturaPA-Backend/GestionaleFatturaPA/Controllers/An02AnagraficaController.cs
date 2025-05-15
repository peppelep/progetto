using Azure.Core;
using GestionaleClientiFornitoriAPI.Service.Interfaces;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionaleFatturaPA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class An02AnagraficaController : ControllerBase
    {

        private readonly IAn02AnagraficaService _anagraficaService;

        public An02AnagraficaController(IAn02AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }

        [HttpGet("{id}")]
        public RemoteResponse<An02AnagraficaDto> GetById(Guid id)
        {
            var tenantId = GetTenantIdFromClaims();
            return _anagraficaService.Get(tenantId, id);
        }

        [HttpPost()]
        public RemoteResponse<An02AnagraficaDto> Create([FromBody] An02AnagraficaDto anagrafica)
        {
            var guidUtente = User.FindFirst(ClaimTypes.Name)?.Value;
            var tenantId = GetTenantIdFromClaims();
            anagrafica.An02Anagrafica1 = Guid.NewGuid();
            anagrafica.An02TenantCf01 = tenantId;
            anagrafica.An02UserCreateCf02 = guidUtente;

            return _anagraficaService.Create(anagrafica);
        }

        [HttpPut()]
        public RemoteResponse<An02AnagraficaDto> Update([FromBody] An02AnagraficaDto anagrafica)
        {
            var guidUtente = User.FindFirst(ClaimTypes.Name)?.Value;
            var tenantId = GetTenantIdFromClaims();

            if (string.IsNullOrEmpty(guidUtente))
                return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>("Utente non autorizzato", 401);

            anagrafica.An02TenantCf01 = tenantId;
            anagrafica.An02UserUpdateCf02 = guidUtente;

            return _anagraficaService.Update(anagrafica);
        }

        [HttpDelete("{id}")]
        public RemoteResponse<bool> Delete(Guid id)
        {
            var guidUtente = User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            var tenantId = GetTenantIdFromClaims();

            if (string.IsNullOrEmpty(guidUtente))
                return RemoteResponseFactory.CreateErrorResponse<bool>("Utente non autorizzato", 401);

            return _anagraficaService.Delete(tenantId, id);
        }

        [HttpGet()]
        public RemoteResponse<IEnumerable<An02AnagraficaDto>> GetAll()
        {
            var tenantId = GetTenantIdFromClaims();
            return _anagraficaService.GetAll(tenantId);
        }

        [HttpPost("GetAllPaginated")]
        public RemoteResponse<PaginatedResult<An02AnagraficaDto>> GetAllPaginated(PaginatedRequest request)
        {
            var tenantId = GetTenantIdFromClaims();
            return _anagraficaService.GetAllPaginated(tenantId, request);
        }

        private Guid GetTenantIdFromClaims()
        {
            var tenantIdClaim = User.FindFirst(ClaimTypes.PrimarySid)?.Value;
            if (string.IsNullOrEmpty(tenantIdClaim) || !Guid.TryParse(tenantIdClaim, out var tenantId))
            {
                throw new UnauthorizedAccessException("Tenant ID non valido o mancante");
            }
            return tenantId;
        }
    }
}
