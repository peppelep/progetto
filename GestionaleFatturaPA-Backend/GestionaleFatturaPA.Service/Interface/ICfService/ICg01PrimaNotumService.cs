using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using System;
using System.Collections.Generic;

public interface ICg01PrimaNotumService
{
    RemoteResponse<PaginatedResult<Cg01PrimaNotumDto>> GetAll(Guid tenantId, PaginatedRequest request);
    RemoteResponse<Cg01PrimaNotumDto> Get(Guid tenantId, Guid primaNotaId);
    RemoteResponse<Cg01PrimaNotumDto> Create(Cg01PrimaNotumDto movimento);
    RemoteResponse<Cg01PrimaNotumDto> Update(Cg01PrimaNotumDto movimento);
    RemoteResponse<bool> Delete(Guid tenantId, Guid primaNotaId);

}