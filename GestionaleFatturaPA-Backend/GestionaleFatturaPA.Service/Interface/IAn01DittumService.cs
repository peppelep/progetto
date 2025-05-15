using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;

namespace GestionaleFatturaPA.Service.Interface;

public interface IAn01DittumService
{
    RemoteResponse<An01DittumDTO> GetById(Guid id);
    RemoteResponse<An01DittumDTO> Create(An01DittumDTO ditta, string guidUtente);
    RemoteResponse<An01DittumDTO> Update(Guid id, An01DittumDTO ditta, string guidUtente);
    RemoteResponse<bool> Delete(Guid id, string guidUtente);
    RemoteResponse<IEnumerable<An01DittumDTO>> GetByTenantId(Guid tenantId);
    RemoteResponse<AziendaCommonResponse> GetDatiPiva(string pIva);
    RemoteResponse<An01DittumDTO> GetMyDitta(Guid tenantId);
} 