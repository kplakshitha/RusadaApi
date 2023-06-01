using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.Profiles
{
    public class AircraftDetailProfile : Profile
    {
        public AircraftDetailProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<AircraftDetailModel, AircraftDetail>().ReverseMap();
        }
    }
}
