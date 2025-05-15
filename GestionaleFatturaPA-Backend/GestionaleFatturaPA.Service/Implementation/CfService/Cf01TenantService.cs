using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Interface.ICfService;
using GestionaleFatturaPA.Utility.Common.Factory;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionaleFatturaPA.Service.Implementation.CfService
{
    public class Cf01TenantService : ICf01TenantService
    {
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public Cf01TenantService(IMapper mapper, IConfiguration configuration)
        {
            this.mapper = mapper;
            _configuration = configuration;
        }

        public RemoteResponse<IEnumerable<Cf01TenantDto>> GetAll()
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
                    return RemoteResponseFactory.CreateResponse(context.Cf01Tenants.Include(x => x.An01Dittum).OrderBy(x => x.Cf01Nome).ToList().Select(x => mapper.Map<Cf01TenantDto>(x)));
                }
                catch (Exception e)
                {
                    return RemoteResponseFactory.CreateErrorResponse<IEnumerable<Cf01TenantDto>>("Generic error", 500);
                }
            }
        }

        public RemoteResponse<Cf01TenantDto> Get(Guid id)
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
                    return RemoteResponseFactory.CreateResponse(mapper.Map<Cf01TenantDto>(context.Cf01Tenants.FirstOrDefault(x => x.Cf01Tenant1 == id)));
                }
                catch (Exception e)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf01TenantDto>("Generic error", 500);
                }
            }
        }

        public RemoteResponse<Cf01TenantDto> Create(Cf01TenantDto dto)
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
                    var entity = mapper.Map<Cf01Tenant>(dto);
                    context.Cf01Tenants.Add(entity);
                    context.SaveChanges();
                    return RemoteResponseFactory.CreateResponse(mapper.Map<Cf01TenantDto>(entity));
                }
                catch (Exception e)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf01TenantDto>("Generic error", 500);
                }
            }
        }

        public RemoteResponse<Cf01TenantDto> Update(Cf01TenantDto dto)
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
                    var entity = context.Cf01Tenants.FirstOrDefault(x => x.Cf01Tenant1 == dto.Cf01Tenant1);
                    if (entity == null)
                    {
                        return RemoteResponseFactory.CreateErrorResponse<Cf01TenantDto>("Tenant not found", 404);
                    }
                    mapper.Map(dto, entity);
                    context.SaveChanges();
                    return RemoteResponseFactory.CreateResponse(mapper.Map<Cf01TenantDto>(entity));
                }
                catch (Exception e)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf01TenantDto>("Generic error", 500);
                }
            }
        }

        public RemoteResponse<Cf01TenantDto> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}


