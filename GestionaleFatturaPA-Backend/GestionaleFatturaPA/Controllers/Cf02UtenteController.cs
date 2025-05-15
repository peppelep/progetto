using AutoMapper;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Service.Interface.ICfService;
using System.Security.Claims;

namespace GestionaleFatturaPA.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class Cf02UtenteController : ControllerBase
	{
		private readonly ICf02UtenteService service;

		public Cf02UtenteController(ICf02UtenteService service)
		{
			this.service = service;
		}

		[HttpPost("auth")]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public RemoteResponse<AuthDTO> Auth([FromBody] AuthDtoIn auth)
		{
			return service.Authenticate(auth);
		}

		

		[HttpDelete("{guid}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public RemoteResponse<bool> DeleteUtente(Guid guid)
		{
			return service.DeleteUtente(guid);
		}

		[HttpPost]
		[ProducesResponseType(StatusCodes.Status201Created)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public RemoteResponse<Cf02UtenteDto> CreateUtente([FromBody] Cf02UtenteDto utente)
		{
			return service.AddNewUtente(utente);
		}

		[HttpPut]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[ProducesResponseType(StatusCodes.Status500InternalServerError)]
		public RemoteResponse<Cf02UtenteDto> UpdateUtente([FromBody] Cf02UtenteDto utente)
		{
			return service.UpdateUtente(utente);
		}
		[HttpGet("current")]
		public RemoteResponse<Cf02UtenteDto> GetCurrentUtente()
		{
			var guidUtente = User.FindFirst(ClaimTypes.Name)?.Value;
			return service.GetCurrentUtente(guidUtente);
		}
		[HttpPost("GetAllPaginated")]
		public RemoteResponse<PaginatedResult<Cf02UtenteDto>> GetAllUtenti(PaginatedRequest request)
		{
			var tenantId = Guid.Parse(User.FindFirst(ClaimTypes.PrimarySid)?.Value);
			return service.GetAllUtenti(tenantId, request);
		}
		[HttpGet("{utenteId}")]
		public RemoteResponse<Cf02UtenteDto> GetUtenteById(string utenteId)
		{
			return service.GetUtenteById(utenteId);
		}

		[HttpGet("ResetPassword")]
		public RemoteResponse<bool> ResetPassword(string Cf02Utente1)
		{
			return service.ResetPassword(Cf02Utente1);
		}
	}
}
