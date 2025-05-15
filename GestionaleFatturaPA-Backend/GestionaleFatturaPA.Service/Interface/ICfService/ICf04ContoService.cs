using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using System;
using System.Collections.Generic;

public interface ICf04ContoService
{
	RemoteResponse<PaginatedResult<Cf04ContoDto>> GetAllPaginated(Guid tenantId, PaginatedRequest request);
	RemoteResponse<Cf04ContoDto> Get(Guid tenantId, Guid contoId);
	RemoteResponse<Cf04ContoDto> Create(Cf04ContoDto conto);
	RemoteResponse<Cf04ContoDto> Update(Cf04ContoDto conto);
	RemoteResponse<bool> Delete(Guid tenantId, Guid contoId);
}