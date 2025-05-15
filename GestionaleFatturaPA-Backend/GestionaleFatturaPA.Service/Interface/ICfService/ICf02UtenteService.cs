using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Service.Interface.ICfService
{
    public interface ICf02UtenteService
    {
        RemoteResponse<AuthDTO> Authenticate(AuthDtoIn authIn);
        RemoteResponse<bool> DeleteUtente(Guid utente);
        RemoteResponse<Cf02UtenteDto> UpdateUtente(Cf02UtenteDto utente);
        RemoteResponse<Cf02UtenteDto> AddNewUtente(Cf02UtenteDto dto);
        RemoteResponse<Cf02UtenteDto> GetCurrentUtente(string utenteId);
        RemoteResponse<Cf02UtenteDto> GetUtenteById(string utenteId);
        RemoteResponse<bool> ResetPassword(string Cf02Utente1);
		RemoteResponse<PaginatedResult<Cf02UtenteDto>> GetAllUtenti(Guid tenantId, PaginatedRequest request);

	}
}
