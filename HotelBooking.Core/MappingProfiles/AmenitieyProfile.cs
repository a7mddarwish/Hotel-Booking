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
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Amenitiey, AmenitieyDTO>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))            
            .ForMember(dest => dest.imagedto, opt => opt.MapFrom(src => src.EntityImageInfo));

            CreateMap<EntityImage, DisplayImageDTO>()
            .ForMember(dest => dest.ImageId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.Image.DisplayURL ))
            .ForMember(dest => dest.IsPrimary, opt => opt.MapFrom(src => src.IsPrimary))
            .ForMember(dest => dest.UploadedAt, opt => opt.MapFrom(src => src.Image.UploadedAt));



            CreateMap<AddAminityDTO, Amenitiey>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));




        }
    }
}
