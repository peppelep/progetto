using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionaleFatturaPA.Service.Interface.ICfService
{
    public interface ICf01TenantService
    {
        RemoteResponse<IEnumerable<Cf01TenantDto>> GetAll();
        RemoteResponse<Cf01TenantDto> Get(Guid id);
        RemoteResponse<Cf01TenantDto> Create(Cf01TenantDto dto);
        RemoteResponse<Cf01TenantDto> Update(Cf01TenantDto dto);
        RemoteResponse<Cf01TenantDto> Delete(Guid id);
    }
}
