using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Interface;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionaleFatturaPA.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class An01DittumController : ControllerBase
{
    private readonly IAn01DittumService _dittaService;

    public An01DittumController(IAn01DittumService dittaService)
    {
        _dittaService = dittaService;
    }

    [HttpGet("GetById/{id}")]
    public RemoteResponse<An01DittumDTO> GetById(Guid id)
    {
        return _dittaService.GetById(id);
    }

    [HttpPost("Create")]
    public RemoteResponse<An01DittumDTO> Create([FromBody] An01DittumDTO ditta)
    {

		var guidUtente = User.FindFirst(ClaimTypes.Name)?.Value;
		return _dittaService.Create(ditta, guidUtente);
    }

    [HttpPut("Update/{id}")]
    public RemoteResponse<An01DittumDTO> Update(Guid id, [FromBody] An01DittumDTO ditta)
    {
		var guidUtente = User.FindFirst(ClaimTypes.Name)?.Value;

		if (string.IsNullOrEmpty(guidUtente))
            return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>("Utente non autorizzato", 401);

        return _dittaService.Update(id, ditta, guidUtente);
    }

    [HttpDelete("Delete/{id}")]
    public RemoteResponse<bool> Delete(Guid id)
    {
        var guidUtente = User.FindFirst("GuidUtente")?.Value;
        if (string.IsNullOrEmpty(guidUtente))
            return RemoteResponseFactory.CreateErrorResponse<bool>("Utente non autorizzato", 401);

        return _dittaService.Delete(id, guidUtente);
    }

    [HttpGet("GetByTenantId/{tenantId}")]
    public RemoteResponse<IEnumerable<An01DittumDTO>> GetByTenantId(Guid tenantId)
    {
        return _dittaService.GetByTenantId(tenantId);
    }


	[HttpGet("GetMyDitta")]
	public RemoteResponse<An01DittumDTO> GetMyDitta()
	{
		var tenantId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value);
		return _dittaService.GetMyDitta(tenantId);
	}
	[HttpGet("GetDatiPiva/{pIva}")]
	public RemoteResponse<AziendaCommonResponse> GetDatiPiva(string pIva)
    {
        return _dittaService.GetDatiPiva(pIva);
	}
} 