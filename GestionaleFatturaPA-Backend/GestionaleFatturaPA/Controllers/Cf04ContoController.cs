using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionaleFatturaPA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cf04ContoController : ControllerBase
    {
        private readonly ICf04ContoService service;

        public Cf04ContoController(ICf04ContoService service)
        {
            this.service = service;
        }

        [HttpPost("GetAllPaginated")]
        public RemoteResponse<PaginatedResult<Cf04ContoDto>> GetAllPaginated(PaginatedRequest request)
		{
            var tenantId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            return service.GetAllPaginated(tenantId,request);
        }

        [HttpGet("GetByConto/{contoId}")]
        public RemoteResponse<Cf04ContoDto> Get(Guid contoId)
        {
            var tenantId = Guid.Parse(User.FindFirst("TenantId")?.Value ?? string.Empty);
            return service.Get(tenantId, contoId);
        }

        [HttpPost]
        public RemoteResponse<Cf04ContoDto> Create([FromBody] Cf04ContoDto dto)
        {
            return service.Create(dto);
        }

        [HttpPut]
        public RemoteResponse<Cf04ContoDto> Update([FromBody] Cf04ContoDto dto)
        {
            return service.Update(dto);
        }

        [HttpDelete("{contoId}")]
        public RemoteResponse<bool> Delete(Guid contoId)
        {
			var tenantId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value);
			return service.Delete(tenantId, contoId);
        }
    }
}
