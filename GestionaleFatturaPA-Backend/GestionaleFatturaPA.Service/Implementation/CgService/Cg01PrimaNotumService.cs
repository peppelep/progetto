using System.Runtime.CompilerServices;
using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Interface.ICfService;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionaleFatturaPA.Service.Implementation.CgService
{

    public class Cg01PrimaNotumService : ICg01PrimaNotumService
    {

        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public Cg01PrimaNotumService(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            _configuration = configuration;
        }

        public RemoteResponse<IEnumerable<Cg01PrimaNotumDto>> GetAll()
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
                    return RemoteResponseFactory.CreateResponse
                }
            }
        }

        RemoteResponse<bool> ICg01PrimaNotumService.Delete(Guid tenantId, Guid primaNotaId)
        {
            throw new NotImplementedException();
        }

        RemoteResponse<Cg01PrimaNotumDto> ICg01PrimaNotumService.Get(Guid tenantId, Guid primaNotaId)
        {
            throw new NotImplementedException();
        }

        RemoteResponse<PaginatedResult<Cg01PrimaNotumDto>> ICg01PrimaNotumService.GetAllPaginated(Guid tenantId, PaginatedRequest request)
        {
            throw new NotImplementedException();
        }

        RemoteResponse<Cg01PrimaNotumDto> ICg01PrimaNotumService.Update(Cg01PrimaNotumDto movimento)
        {
            throw new NotImplementedException();
        }
    }
}
