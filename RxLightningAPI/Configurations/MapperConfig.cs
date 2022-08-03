using AutoMapper;
using RxLightningAPI.Models.DTOs;
using RxLightningAPI.Models.PatientServiceAPIModels;

namespace RxLightningAPI.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<PatientViewDTO, Patient>().ReverseMap();
        }
    }
}
