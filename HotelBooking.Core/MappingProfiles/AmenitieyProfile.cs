using AutoMapper;
using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.MappingProfiles
{
    public class AmenitieyProfile : Profile
    {
        public AmenitieyProfile()
        {

            CreateMap<AmenitieyDTO, Amenitiey>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));

            CreateMap<Amenitiey, AmenitieyDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.IconUrl, opt => opt.MapFrom(src => src.IconUrl));
            

        }
    }
}
