using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Interface;
using GestionaleFatturaPA.Utility.Common.Factory;
using GestionaleFatturaPA.Utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace GestionaleFatturaPA.Service.Implementation;

public class An01DittumService : IAn01DittumService
{
	private readonly IMapper _mapper;
	private readonly IConfiguration _configuration;

	public An01DittumService(IMapper mapper, IConfiguration configuration)
	{
		_mapper = mapper;
		_configuration = configuration;
	}

	public RemoteResponse<An01DittumDTO> GetById(Guid id)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var ditta = context.An01Ditta
                    .FirstOrDefault(x => x.An01TenantCf01 == id && !x.An01Deleted);
				if (ditta == null)
					return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>($"Ditta con ID {id} non trovata", 404);

				var userCreate = context.Cf02Utentes.FirstOrDefault(x => x.Cf02Utente1 == ditta.An01UserCreateCf02);
                var userUpdate = context.Cf02Utentes.FirstOrDefault(x => x.Cf02Utente1 == ditta.An01UserUpdateCf02);

				var dto = _mapper.Map<An01DittumDTO>(ditta);
				dto.An01UserCreateCf02Email = userCreate.Cf02Email;
				dto.An01UserUpdateCf02Email = userUpdate.Cf02Email;
                return RemoteResponseFactory.CreateResponse(dto);
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>("Errore generico", 500);
			}
		}
	}

	public RemoteResponse<An01DittumDTO> Create(An01DittumDTO ditta, string guidUtente)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = _mapper.Map<An01Dittum>(ditta);
				entity.An01Deleted = false;
				entity.An01DataCreate = DateTime.UtcNow;
				//entity.An01UserCreateCf02 = guidUtente;
				context.An01Ditta.Add(entity);
				context.SaveChanges();

				var dittaCreata=context.An01Ditta.Include(x => x.An01ProvinciaAlboGe08Navigation).Include(x => x.An01ComuneGe01Navigation).FirstOrDefault(x => x.An01TenantCf01 == entity.An01TenantCf01);

				// CREAZIONE ANAGRAFICA COLLEGATA IN AUTOMATICO per AUTOFATTURA F
				var anagraficaFornitore = new An02Anagrafica
				{
					An02TenantCf01 = dittaCreata.An01TenantCf01,
					An02Anagrafica1 = Guid.NewGuid(),
					An02DataCreate = DateTime.UtcNow,
					//An02UserCreateCf02 = guidUtente,
					An02Deleted = false,
					An02Clifor = "F",
					An02Ragsoc = dittaCreata.An01Ragsoc +" AUTOFATTURA",
					An02Cap = dittaCreata.An01CapDiverso,
					An02CoiceFiscale = dittaCreata.An01CodiceFiscale,
					An02Partitaiva = dittaCreata.An01Partitaiva,
					An02Referente= dittaCreata.An01Nome+ " " + dittaCreata.An01Cognome,
					An02IndirizzoSpedizione= dittaCreata.An01Indirizzo+" "+ dittaCreata.An01NumeroCivico,
					An02Provincia=dittaCreata.An01ProvinciaAlboGe08Navigation.Ge08Provincia,
					An02Comune = dittaCreata.An01ComuneGe01Navigation.Ge01Nome,
					An02Telefono = dittaCreata.An01TelefonoContatto,
					An02IndirizzoPec = dittaCreata.An01EmailContatto,
					An02Iban = dittaCreata.An01Iban,
				};
				var anagraficaCliente = new An02Anagrafica
				{
					An02TenantCf01 = dittaCreata.An01TenantCf01,
					An02Anagrafica1 = Guid.NewGuid(),
					An02DataCreate = DateTime.UtcNow,
					//An02UserCreateCf02 = guidUtente,
					An02Deleted = false,
					An02Clifor = "C",
					An02Ragsoc = dittaCreata.An01Ragsoc ,
					An02Cap = dittaCreata.An01CapDiverso,
					An02CoiceFiscale = dittaCreata.An01CodiceFiscale,
					An02Partitaiva = dittaCreata.An01Partitaiva,
					An02Referente = dittaCreata.An01Nome + " " + dittaCreata.An01Cognome,
					An02IndirizzoSpedizione = dittaCreata.An01Indirizzo + " " + dittaCreata.An01NumeroCivico,
					An02Provincia = dittaCreata.An01ProvinciaAlboGe08Navigation.Ge08Provincia,
					An02Comune = dittaCreata.An01ComuneGe01Navigation.Ge01Nome,
					An02Telefono = dittaCreata.An01TelefonoContatto,
					An02IndirizzoPec = dittaCreata.An01EmailContatto,
					An02Iban = dittaCreata.An01Iban,
				};
				var list = new List<An02Anagrafica>() { anagraficaCliente, anagraficaFornitore};
				context.An02Anagraficas.AddRange(list);
				context.SaveChanges();


				return RemoteResponseFactory.CreateResponse(_mapper.Map<An01DittumDTO>(entity));
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>("Errore durante la creazione della ditta", 500);
			}
		}
	}

	public RemoteResponse<An01DittumDTO> Update(Guid id, An01DittumDTO ditta, string guidUtente)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = context.An01Ditta.FirstOrDefault(x => x.An01TenantCf01 == id && !x.An01Deleted);
				if (entity == null)
					return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>($"Ditta con ID {id} non trovata", 404);

				_mapper.Map(ditta, entity);
				entity.An01DataUpdate = DateTime.UtcNow;
				entity.An01UserUpdateCf02 = guidUtente;
				entity.An01UserUpdateCf02 = guidUtente;

				context.SaveChanges();
				return RemoteResponseFactory.CreateResponse(_mapper.Map<An01DittumDTO>(entity));
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>("Errore durante l'aggiornamento della ditta", 500);
			}
		}
	}

	public RemoteResponse<AziendaCommonResponse> GetDatiPiva(string pIva)
	{
		try
		{
			var client = new HttpClient();
			var request = new HttpRequestMessage(HttpMethod.Get, $"https://cavies.azurewebsites.net/api/Azienda/advanced/{pIva}");
			//var key = _configuration["AziendaApiKey"];
			var key= "fK9wTQ7pReX6V2MLaJh3yNbUvWpBdCZq84EmGxLtPdsRYoK1AZXcHrN5vJQiU3WY";
			request.Headers.Add("X-API-Key", key);
			var response = AsyncUtil.RunSync<HttpResponseMessage>(()=>  client.SendAsync(request));
			response.EnsureSuccessStatusCode();
			var responseString = AsyncUtil.RunSync<string>(() => response.Content.ReadAsStringAsync());
			var aziendaResponse = JsonConvert.DeserializeObject<RemoteResponse<AziendaCommonResponse>>(responseString);
			return RemoteResponseFactory.CreateResponse(aziendaResponse.Data);
		}
		catch (Exception e)
		{
			return RemoteResponseFactory.CreateErrorResponse<AziendaCommonResponse>("Errore durante l'aggiornamento della ditta", 500);
		}
	}


	public RemoteResponse<bool> Delete(Guid id, string guidUtente)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var entity = context.An01Ditta.FirstOrDefault(x => x.An01TenantCf01 == id && !x.An01Deleted);
				if (entity == null)
					return RemoteResponseFactory.CreateErrorResponse<bool>($"Ditta con ID {id} non trovata", 404);

				entity.An01Deleted = true;
				entity.An01DataUpdate = DateTime.UtcNow;
				entity.An01UserUpdateCf02 = guidUtente;

				context.SaveChanges();
				return RemoteResponseFactory.CreateResponse(true);
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<bool>("Errore durante l'eliminazione della ditta", 500);
			}
		}
	}

	public RemoteResponse<IEnumerable<An01DittumDTO>> GetByTenantId(Guid tenantId)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var ditte = context.An01Ditta
					.Where(x => x.An01TenantCf01 == tenantId && !x.An01Deleted)
					.ToList()
					.Select(x => _mapper.Map<An01DittumDTO>(x));

				return RemoteResponseFactory.CreateResponse(ditte);
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<IEnumerable<An01DittumDTO>>("Errore durante il recupero delle ditte", 500);
			}
		}
	}

	public RemoteResponse<An01DittumDTO> GetMyDitta(Guid tenantId)
	{
		using (var context = new GestionaleFatturaPaContext())
		{
			try
			{
				var ditta = context.An01Ditta
					.FirstOrDefault(x => x.An01TenantCf01 == tenantId && !x.An01Deleted);

                var userCreate = context.Cf02Utentes.FirstOrDefault(x => x.Cf02Utente1 == ditta.An01UserCreateCf02);
                var userUpdate = context.Cf02Utentes.FirstOrDefault(x => x.Cf02Utente1 == ditta.An01UserUpdateCf02);

                var dto = _mapper.Map<An01DittumDTO>(ditta);
                dto.An01UserCreateCf02Email = userCreate.Cf02Email;
                dto.An01UserUpdateCf02Email = userUpdate.Cf02Email;

                return RemoteResponseFactory.CreateResponse(dto);
			}
			catch (Exception e)
			{
				return RemoteResponseFactory.CreateErrorResponse<An01DittumDTO>("Errore durante il recupero delle ditte", 500);
			}
		}

	}
}