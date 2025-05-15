using AutoMapper;
using GestionaleFatturaPa.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using GestionaleFatturaPA.Utility.Common.Factory;
using GestionaleFatturaPA.Model.DTOs;
using GestionaleFatturaPA.Service.Interface.ICfService;
using Microsoft.AspNetCore.Authorization;

namespace GestionaleFatturaPA.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
	[ApiController]
	public class Cf01TenantController : ControllerBase
	{
		private readonly ICf01TenantService service;

		public Cf01TenantController(ICf01TenantService service)
		{
			this.service = service;
        }

		[HttpGet]
		public RemoteResponse<IEnumerable<Cf01TenantDto>> GetAll()
		{
			return service.GetAll();
		}


		[HttpGet("{id}")]
		public RemoteResponse<Cf01TenantDto> Get(Guid id)
		{
			return service.Get(id);
		}

		[HttpPost]
		public RemoteResponse<Cf01TenantDto> Create([FromBody] Cf01TenantDto dto)
		{
			return service.Create(dto);
		}

		[HttpPut]
		public RemoteResponse<Cf01TenantDto> Update([FromBody] Cf01TenantDto dto)
		{
			return service.Update(dto);
		}

        [HttpDelete]
        public RemoteResponse<Cf01TenantDto> Delete(Guid id)
        {
            return service.Delete(id);
        }
    }
}
