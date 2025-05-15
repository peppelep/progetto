using AutoMapper;
using GestionaleFatturaPa.Data.Entities;
using GestionaleFatturaPA.Model.DTOs;

namespace GestionaleFatturaPA.Service.Helpers.MappingProfiles;

public class An01DittumProfile : Profile
{
    public An01DittumProfile()
    {
        CreateMap<An01Dittum, An01DittumDTO>().ReverseMap();
    }
} 