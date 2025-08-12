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
    internal class RoomTypeProfile : Profile
    {
        public RoomTypeProfile()
        {
            CreateMap<AddRoomTypeDTO , RoomType>()
                .ForMember(dest => dest.RoomImages, opt => opt.MapFrom(src => src.RoomImages.Select(img => new RoomImage { ImageURL = img })))
                .ForMember(dest => dest.Amenities , opt => opt.MapFrom(src => src.amenitiesIDs.Select(id => new Amenitiey { Id = id })))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name)) 
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<RoomType, ShowRoomTypeDTO>()
                .ForMember(dest => dest.RoomImages, opt => opt.MapFrom(src => src.RoomImages.Select(img => img.ImageURL)))
                .ForMember(dest => dest.amenities, opt => opt.MapFrom(src => src.Amenities.Select(a =>new AmenitieyDTO {Name = a.Name , IconUrl = a.IconUrl , Id = 000 })))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Capacity, opt => opt.MapFrom(src => src.Capacity))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));






        }
    }
}
