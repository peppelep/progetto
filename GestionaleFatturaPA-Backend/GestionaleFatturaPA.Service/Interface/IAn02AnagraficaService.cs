using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestionaleClientiFornitoriAPI.Service.Interfaces
{
    public interface IAn02AnagraficaService
    {
		RemoteResponse<IEnumerable<An02AnagraficaDto>> GetAll(Guid tenantId);
		RemoteResponse<PaginatedResult<An02AnagraficaDto>> GetAllPaginated(Guid tenantId, PaginatedRequest request);

		RemoteResponse<An02AnagraficaDto> Get(Guid tenantId, Guid anagraficaId);
		RemoteResponse<An02AnagraficaDto> Create(An02AnagraficaDto dto);
		RemoteResponse<An02AnagraficaDto> Update(An02AnagraficaDto dto);
		RemoteResponse<bool> Delete(Guid tenantId, Guid anagraficaId);

	}
}
