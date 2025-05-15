using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Helpers;
using GestionaleFatturaPA.Service.Interface.ICfService;
using GestionaleFatturaPA.Service.Security;
using GestionaleFatturaPA.Utility.Common.Factory;
using GestionaleFatturaPA.Utility.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionaleFatturaPA.Service.Implementation.CfService
{
    public class Cf02UtenteService : ICf02UtenteService
    {

        //private readonly AuthSettings _appSettings;
        private readonly GestionaleFatturaPaContext _context;
        private readonly AuthSettings _appSettings;
        private readonly IMapper mapper;


        public Cf02UtenteService(GestionaleFatturaPaContext context, IOptions<AuthSettings> appsettings, IMapper mapper)
        {
            _context = context;
            _appSettings = appsettings.Value;
            this.mapper = mapper;
        }



        public RemoteResponse<AuthDTO> Authenticate(AuthDtoIn authIn)
        {
            string tokenJWT = "";
            AuthDTO auth = new AuthDTO();
            bool isOk = VerifyLogin(authIn.email, authIn.password);
            if (!isOk)
            {
                auth.Error = true;
                auth.ErrorDescription = "Username e/o password errate";
                return RemoteResponseFactory.CreateResponse(auth);
            }
            var utente = GetUtentebyEmail(authIn.email);
            tokenJWT = GetToken(utente);
            //ModelsAuth.Utente utenteRes = await GetUtentebyEmail(authIn.email);
            auth.Error = false;
            auth.Token = tokenJWT;
            auth.TenantId = utente.Cf02TenantCf01;
            return RemoteResponseFactory.CreateResponse(auth);
        }//Authenticate




        private bool VerifyLogin(string email, string password)
        {
            bool retVal = false;
            PasswordHasher Hasher = new PasswordHasher();
            var utente = GetUtentebyEmail(email);
            if (utente != null)
            {
                string EncryptPwd = utente.Cf02Password;
                retVal = Hasher.Check(EncryptPwd, password).Verified;
            }
            return retVal;
        }//VerifyLogin


        private string GetToken(Cf02Utente utente)
        {

            if (utente == null)
            {
                throw new Exception("Utente non presente");
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var ruolo = utente.Cf02RuoloGe02Navigation;
            if (ruolo.Ge02Descrizione != "UTENTE")
            {
                utente.Cf02Primanota = true;
                utente.Cf02Fornitori = true;
                utente.Cf02Clienti = true;

            }
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, utente.Cf02Utente1),
                new Claim(ClaimTypes.Email, utente.Cf02Email.ToString()),
                new Claim(ClaimTypes.Role, ruolo.Ge02Ruolo.ToString()),
                new Claim(ClaimTypes.PrimarySid, utente.Cf02TenantCf01.ToString()),
                new Claim("PRIMA_NOTA", utente.Cf02Primanota.ToString()),
                new Claim("CLIENTI", utente.Cf02Clienti.ToString()),
                new Claim("FORNITORI", utente.Cf02Fornitori.ToString())
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                //Validità del TOKEN
                Expires = DateTime.Now.AddSeconds(_appSettings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }//GetToken


        public Cf02Utente GetUtentebyEmail(string email)
        {
            Cf02Utente utente = _context.Cf02Utentes.Include(x => x.Cf02RuoloGe02Navigation).FirstOrDefault(x => x.Cf02Utente1 == email || x.Cf02Email == email);
            return utente;
        }//GetUtentebyEmail



        public RemoteResponse<Cf02UtenteDto> AddNewUtente(Cf02UtenteDto dto)
        {
            try
            {
                var exists = GetUtentebyEmail(dto.Cf02Email);
                if (exists != null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>("Impossibile aggiungere l'utente", 500);
                }


                Cf02Utente utente = mapper.Map<Cf02Utente>(dto);
                PasswordHasher hasher = new PasswordHasher();
                var password = utente.Cf02Password;
                utente.Cf02Password = hasher.Hash(password);
                utente.Cf02Utente1 = Guid.NewGuid().ToString();
                _context.Add(utente);
                _context.SaveChanges();
                dto.Cf02Utente1 = utente.Cf02Utente1;
                dto.Cf02Password = string.Empty;
                return RemoteResponseFactory.CreateResponse(dto);


            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>("Impossibile aggiungere l'utente", 500);
            }
        }
        public RemoteResponse<PaginatedResult<Cf02UtenteDto>> GetAllUtenti(Guid tenantId, PaginatedRequest request)
        {
            try
            {
				var paginatedResult = new PaginatedResult<Cf02UtenteDto>();
				var query = _context.Cf02Utentes
					.Where(x => x.Cf02TenantCf01 == tenantId )
                    .Include(x => x.Cf02RuoloGe02Navigation)
					.AsQueryable();
                var result = query.WhereDynamicFilters(request.FieldFilters, request.PageIndex, request.PageSize);
                query = result.Query;
                paginatedResult.TotalCount = result.TotalCount;
                paginatedResult.Items = query.Select(x => mapper.Map<Cf02UtenteDto>(x)).ToList();
				paginatedResult.PageIndex = request.PageIndex;
				paginatedResult.PageSize = request.PageSize;
				paginatedResult.TotalPages = (int)Math.Ceiling((double)paginatedResult.TotalCount / request.PageSize);
				return RemoteResponseFactory.CreateResponse(paginatedResult);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<PaginatedResult<Cf02UtenteDto>>(ex.Message);
            }
        }

        public RemoteResponse<bool> DeleteUtente(Guid guidUtente)
        {
            try
            {
                var utenteDaEliminare = _context.Cf02Utentes.FirstOrDefault(u => u.Cf02TenantCf01 == guidUtente);
                if (utenteDaEliminare == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<bool>("Utente non trovato");
                }

                _context.Cf02Utentes.Remove(utenteDaEliminare);
                _context.SaveChanges();
                return RemoteResponseFactory.CreateResponse(true);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<bool>(ex.Message);
            }
        }

        public RemoteResponse<Cf02UtenteDto> UpdateUtente(Cf02UtenteDto utente)
        {
            try
            {
                var utenteDaAggiornare = _context.Cf02Utentes.FirstOrDefault(u => u.Cf02Utente1 == utente.Cf02Utente1);
                if (utenteDaAggiornare == null)
                {
                    return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>("Utente non trovato");
                }
				utenteDaAggiornare.Cf02Clienti=utente.Cf02Clienti;
				utenteDaAggiornare.Cf02Fornitori = utente.Cf02Fornitori;
                utenteDaAggiornare.Cf02Primanota = utente.Cf02Primanota;
				utenteDaAggiornare.Cf02Email = utente.Cf02Email;
				utenteDaAggiornare.Cf02Telefono = utente.Cf02Telefono;
				utenteDaAggiornare.Cf02RuoloGe02 = utente.Cf02RuoloGe02;
				_context.SaveChanges();
                return RemoteResponseFactory.CreateResponse(utente);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>(ex.Message);
            }
        }


		public RemoteResponse<bool> ResetPassword(string Cf02Utente1)
		{
			try
			{
				var utenteDaAggiornare = _context.Cf02Utentes.FirstOrDefault(u => u.Cf02Utente1 == Cf02Utente1);
				if (utenteDaAggiornare == null)
				{
					return RemoteResponseFactory.CreateErrorResponse<bool>("Utente non trovato");
				}
				var password = GenerateRandomPassword();
				PasswordHasher hasher = new PasswordHasher();
				utenteDaAggiornare.Cf02Password = hasher.Hash(password);
				_context.SaveChanges();
				// Inviare la password via email a utente
				return RemoteResponseFactory.CreateResponse(true);
			}
			catch (Exception ex)
			{
				return RemoteResponseFactory.CreateErrorResponse<bool>(ex.Message);
			}
		}

		public RemoteResponse<Cf02UtenteDto> GetCurrentUtente(string utenteId)
        {
            try
            {
                var utente = _context.Cf02Utentes.FirstOrDefault(u => u.Cf02Utente1 == utenteId);
                var utenteDto = mapper.Map<Cf02UtenteDto>(utente);
                return RemoteResponseFactory.CreateResponse(utenteDto);
            }
            catch (Exception ex)
            {
                return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>(ex.Message);

            }
        }

		public RemoteResponse<Cf02UtenteDto> GetUtenteById(string utenteId)
		{
			try
			{
				var utente = _context.Cf02Utentes.FirstOrDefault(u => u.Cf02Utente1 == utenteId);
				var utenteDto = mapper.Map<Cf02UtenteDto>(utente);
				return RemoteResponseFactory.CreateResponse(utenteDto);
			}
			catch (Exception ex)
			{
				return RemoteResponseFactory.CreateErrorResponse<Cf02UtenteDto>(ex.Message);

			}
		}

		private string GenerateRandomPassword()
		{
			const string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			const int length = 8;

			var random = new Random();
			var chars = new char[length];

			for (int i = 0; i < length; i++)
			{
				chars[i] = validChars[random.Next(validChars.Length)];
			}

			return new string(chars);
		}


	}
}
