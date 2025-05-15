
using GestionaleClientiFornitoriAPI.Service.Interfaces;
using GestionaleClientiFornitoriAPI.Service.Services;
using GestionaleFatturaPa.Data.Context;
using GestionaleFatturaPA.Service.Helpers;
using GestionaleFatturaPA.Service.Implementation;
using GestionaleFatturaPA.Service.Implementation.CfService;
using GestionaleFatturaPA.Service.Interface;
using GestionaleFatturaPA.Service.Interface.ICfService;
using GestionaleFatturaPA.Utility.Mapping;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;




namespace GestionaleFatturaPA
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
		

			//

			// AutoMapper
			builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);


            builder.Services.AddScoped<ICf01TenantService, Cf01TenantService>();
            builder.Services.AddScoped<ICf02UtenteService, Cf02UtenteService>();
			builder.Services.AddScoped<IAn01DittumService, An01DittumService>();
			builder.Services.AddScoped<IAn02AnagraficaService, An02AnagraficaService>();
			builder.Services.AddScoped<ICf04ContoService, Cf04ContoService>();

			// scoped



			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddCors();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddDbContext<GestionaleFatturaPaContext>();
			var provider = builder.Services.BuildServiceProvider();
			var configuration = provider.GetRequiredService<IConfiguration>();



			// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
			builder.Services.AddOpenApi();
			builder.Services.AddSwaggerGen(option =>
			{
				option.SwaggerDoc("v1", new OpenApiInfo { Title = "Gestionale API", Version = "v1" });
				option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					In = ParameterLocation.Header,
					Description = "Please enter a valid token",
					Name = "Authorization",
					Type = SecuritySchemeType.Http,
					BearerFormat = "JWT",
					Scheme = "Bearer"
				});
				option.AddSecurityRequirement(new OpenApiSecurityRequirement
	{
		{
			new OpenApiSecurityScheme
			{
				Reference = new OpenApiReference
				{
					Type=ReferenceType.SecurityScheme,
					Id="Bearer"
				}
			},
						new string[]{}
					}
				});
			});

			var appSettingsSection = configuration.GetSection("AppSettings");
			//var appSettingsSection = builder.Configuration.GetSection("AppSettings"); //TODO modifica paolo

			builder.Services.Configure<AuthSettings>(appSettingsSection);
			var appSettings = appSettingsSection.Get<AuthSettings>();
			var key = Encoding.ASCII.GetBytes(appSettings.Secret);
			builder.Services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(x =>
			{

				x.RequireHttpsMetadata = false;
				x.SaveToken = true;
				x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(key),
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ClockSkew = TimeSpan.Zero

				};
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestionale API v1");
					// Puoi anche impostare il routePrefix a stringa vuota per far partire swagger dalla root
					// c.RoutePrefix = "";
				});
			}

			app.UseCors(options =>
				options
					.AllowAnyOrigin()
					.AllowAnyMethod()
					.AllowAnyHeader()
			);

			app.UseRouting();



			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.Run();
		}
	}
}
