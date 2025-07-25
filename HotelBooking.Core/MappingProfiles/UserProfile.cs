using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
namespace HotelBooking.Core.MappingProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<RegistrationDTO, AppUser>()
              .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
              .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FName))
              .ForMember(dest => dest.MName, opt => opt.MapFrom(src => src.MName))
              .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LName))
              .ForMember(dest => dest.NationaltyID, opt => opt.MapFrom(src => src.NationalityID))
              .ForMember(dest => dest.SecondPhoneNum, opt => opt.MapFrom(src => src.SecondPhoneNum))
              .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
              .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
              .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
              .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage));

            CreateMap<AppUser, RegistrationDTO>()
              .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
              .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
              .ForMember(dest => dest.FName, opt => opt.MapFrom(src => src.FName))
              .ForMember(dest => dest.MName, opt => opt.MapFrom(src => src.MName))
              .ForMember(dest => dest.LName, opt => opt.MapFrom(src => src.LName))
              .ForMember(dest => dest.NationalityID, opt => opt.MapFrom(src => src.NationaltyID))
              .ForMember(dest => dest.SecondPhoneNum, opt => opt.MapFrom(src => src.SecondPhoneNum))
              .ForMember(dest => dest.JobTitle, opt => opt.MapFrom(src => src.JobTitle))
              .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
              .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate))
              .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => src.ProfileImage));
        }
    }
}