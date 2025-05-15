using AutoMapper;
using GestionaleClientiFornitoriAPI.Service.Interfaces;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using GestionaleFatturaPA.Utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GestionaleClientiFornitoriAPI.Service.Services
{
	public class An02AnagraficaService : IAn02AnagraficaService
	{
		private readonly IMapper mapper;
		private readonly IConfiguration configuration;

		public An02AnagraficaService(IMapper mapper, IConfiguration configuration)
		{
			this.mapper = mapper;
			this.configuration = configuration;
		}

		public RemoteResponse<IEnumerable<An02AnagraficaDto>> GetAll(Guid tenantId)
		{
			using (var context = new GestionaleFatturaPaContext())
			{
				try
				{
					var lista = context.An02Anagraficas
						.Where(x => x.An02TenantCf01 == tenantId && (x.An02Deleted == null || x.An02Deleted == false))
						.OrderBy(x => x.An02Ragsoc)
						.ToList()
						.Select(x => mapper.Map<An02AnagraficaDto>(x));



					return RemoteResponseFactory.CreateResponse(lista);
				}
				catch (Exception e)
				{
					return RemoteResponseFactory.CreateErrorResponse<IEnumerable<An02AnagraficaDto>>("Generic error", 500);
				}
			}
		}

        public RemoteResponse<PaginatedResult<An02AnagraficaDto>> GetAllPaginated(Guid tenantId, PaginatedRequest request)
        {
            using (var context = new GestionaleFatturaPaContext())
            {
                try
                {
					var paginatedResult = new PaginatedResult<An02AnagraficaDto>();
					var query = context.An02Anagraficas
						.Where(x => x.An02TenantCf01 == tenantId && (x.An02Deleted == null || x.An02Deleted == false))
						.AsQueryable();
					
					var result= query.WhereDynamicFilters(request.FieldFilters, request.PageIndex, request.PageSize);
					query = result.Query;
                    paginatedResult.TotalCount = result.TotalCount;
                    paginatedResult.Items = query.Select(x => mapper.Map<An02AnagraficaDto>(x)).ToList();
				
					paginatedResult.PageIndex = request.PageIndex;
					paginatedResult.PageSize = request.PageSize;
					paginatedResult.TotalPages = (int)Math.Ceiling((double)paginatedResult.TotalCount / request.PageSize);

					return RemoteResponseFactory.CreateResponse(paginatedResult);
				}
				catch (Exception e)
				{
                    return RemoteResponseFactory.CreateErrorResponse<PaginatedResult<An02AnagraficaDto>>("Generic error", 500);
                }
            }
        }

        public RemoteResponse<An02AnagraficaDto> Get(Guid tenantId, Guid anagraficaId)
		{
			using (var context = new GestionaleFatturaPaContext())
			{
				try
				{
					var anagrafica = context.An02Anagraficas
						.Include(ut => ut.Cf02UtenteNavigation)
						.Include(ut => ut.Cf02Utente)
						.FirstOrDefault(x => x.An02TenantCf01 == tenantId && x.An02Anagrafica1 == anagraficaId);

					if (anagrafica == null)
						return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>($"Anagrafica con ID {anagraficaId} non trovata", 404);

					return RemoteResponseFactory.CreateResponse(mapper.Map<An02AnagraficaDto>(anagrafica));
				}
				catch (Exception e)
				{
					return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>("Errore generico", 500);
				}
			}
		}

		public RemoteResponse<An02AnagraficaDto> Create(An02AnagraficaDto dto)
		{
			using (var context = new GestionaleFatturaPaContext())
			{
				try
				{
					var entity = mapper.Map<An02Anagrafica>(dto);
					entity.An02DataCreate = DateTime.Now;

					context.An02Anagraficas.Add(entity);
					context.SaveChanges();

					return RemoteResponseFactory.CreateResponse(mapper.Map<An02AnagraficaDto>(entity));
				}
				catch (Exception e)
				{
					return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>("Errore durante la creazione dell'anagrafica", 500);
				}
			}
		}

		public RemoteResponse<An02AnagraficaDto> Update(An02AnagraficaDto dto)
		{
			using (var context = new GestionaleFatturaPaContext())
			{
				try
				{
					var entity = context.An02Anagraficas
						.FirstOrDefault(x => x.An02TenantCf01 == dto.An02TenantCf01 && x.An02Anagrafica1 == dto.An02Anagrafica1);

					if (entity == null)
						return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>($"Anagrafica con ID {dto.An02Anagrafica1} non trovata", 404);

					mapper.Map(dto, entity);
					entity.An02DataUpdate = DateTime.Now;
					context.SaveChanges();

					return RemoteResponseFactory.CreateResponse(mapper.Map<An02AnagraficaDto>(entity));
				}
				catch (Exception e)
				{
					return RemoteResponseFactory.CreateErrorResponse<An02AnagraficaDto>("Errore durante l'aggiornamento dell'anagrafica", 500);
				}
			}
		}

		public RemoteResponse<bool> Delete(Guid tenantId, Guid anagraficaId)
		{
			using (var context = new GestionaleFatturaPaContext())
			{
				try
				{
					var entity = context.An02Anagraficas
						.FirstOrDefault(x => x.An02TenantCf01 == tenantId && x.An02Anagrafica1 == anagraficaId);

					if (entity == null)
						return RemoteResponseFactory.CreateErrorResponse<bool>($"Anagrafica con ID {anagraficaId} non trovata", 404);

					// Soft delete
					entity.An02Deleted = true;
					entity.An02DataUpdate = DateTime.Now;
					context.SaveChanges();

					return RemoteResponseFactory.CreateResponse(true);
				}
				catch (Exception e)
				{
					return RemoteResponseFactory.CreateErrorResponse<bool>("Errore durante l'eliminazione dell'anagrafica", 500);
				}
			}
		}


	}
}

