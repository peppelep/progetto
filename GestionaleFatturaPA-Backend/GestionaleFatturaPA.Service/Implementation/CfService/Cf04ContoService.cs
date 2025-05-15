using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Utility.Common.Factory;
using GestionaleFatturaPA.Utility.Helpers;
using Microsoft.Extensions.Configuration;

public class Cf04ContoService : ICf04ContoService
{
    private readonly IMapper mapper;
    private readonly IConfiguration configuration;

    public Cf04ContoService(IMapper mapper, IConfiguration configuration)
    {
        this.mapper = mapper;
        this.configuration = configuration;
    }

    public RemoteResponse<PaginatedResult<Cf04ContoDto>> GetAllPaginated(Guid tenantId, PaginatedRequest request)
	{
        using (var context = new GestionaleFatturaPaContext())
        {
            try
            {
               
				var paginatedResult = new PaginatedResult<Cf04ContoDto>();
				var query = context.Cf04Contos.Where(x => x.Cf04TenantCf01 == tenantId)
					.AsQueryable();
                var result = query.WhereDynamicFilters(request.FieldFilters, request.PageIndex, request.PageSize);
                query = result.Query;
                paginatedResult.TotalCount = result.TotalCount;
                paginatedResult.Items = query.Select(x => mapper.Map<Cf04ContoDto>(x)).ToList();
				
				paginatedResult.PageIndex = request.PageIndex;
				paginatedResult.PageSize = request.PageSize;
				paginatedResult.TotalPages = (int)Math.Ceiling((double)paginatedResult.TotalCount / request.PageSize);

				return RemoteResponseFactory.CreateResponse(paginatedResult);
			}
            catch (Exception e)
            {
                return RemoteResponseFactory.CreateErrorResponse<PaginatedResult<Cf04ContoDto>>("Generic error", 500);
            }
        }
    }

    public RemoteResponse<Cf04ContoDto> Get(Guid tenantId, Guid contoId)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var conto = context.Cf04Contos.FirstOrDefault(x => x.Cf04TenantCf01 == tenantId && x.Cf04Conto1 == contoId );
				if (conto == null)
					return RemoteResponseFactory.CreateErrorResponse<Cf04ContoDto>($"Conto con ID {contoId} non trovato", 404);

				return RemoteResponseFactory.CreateResponse(mapper.Map<Cf04ContoDto>(conto));
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<Cf04ContoDto>("Errore generico", 500);
			}
		}
	}

    public RemoteResponse<Cf04ContoDto> Create(Cf04ContoDto dto)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = mapper.Map<Cf04Conto>(dto);
				context.Cf04Contos.Add(entity);
				entity.Cf04Conto1 = Guid.NewGuid();
				context.SaveChanges();

				return RemoteResponseFactory.CreateResponse(mapper.Map<Cf04ContoDto>(entity));
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<Cf04ContoDto>("Errore durante la creazione del conto", 500);
			}
		}
	}

	public RemoteResponse<Cf04ContoDto> Update(Cf04ContoDto dto)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = context.Cf04Contos.FirstOrDefault(x => x.Cf04TenantCf01 == dto.Cf04TenantCf01 && x.Cf04Conto1 == dto.Cf04Conto1);
				if (entity == null)
					return RemoteResponseFactory.CreateErrorResponse<Cf04ContoDto>($"Conto con ID {dto.Cf04Conto1} non trovato", 404);
				mapper.Map(dto, entity);
				context.SaveChanges();
				return RemoteResponseFactory.CreateResponse(mapper.Map<Cf04ContoDto>(entity));
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<Cf04ContoDto>("Errore durante l'aggiornamento del conto", 500);
			}
		}
	}

	public RemoteResponse<bool> Delete(Guid tenantId, Guid contoId)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = context.Cf04Contos.FirstOrDefault(x => x.Cf04TenantCf01 == tenantId && x.Cf04Conto1 == contoId);
				if (entity == null)
					return RemoteResponseFactory.CreateErrorResponse<bool>($"Conto con ID {contoId} non trovato", 404);
				context.Remove(entity);
				context.SaveChanges();
				return RemoteResponseFactory.CreateResponse(true);
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<bool>("Errore durante l'eliminazione del conto", 500);
			}
		}
	}
}