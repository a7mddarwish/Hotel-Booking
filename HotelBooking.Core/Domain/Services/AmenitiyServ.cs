using AutoMapper;
using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.Enums;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.ExternalServContracts;
using HotelBooking.Core.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Services
{
    internal class AmenitiyServ : IAmenitiyServ
    {
        private readonly IAmenitieyRepo _repo;
        private readonly IMapper _mapper;
        private readonly ICloudServ _cloud;

        public AmenitiyServ(IAmenitieyRepo repo , IMapper mapper , ICloudServ cloud)
        {
            this._repo = repo;
            this._mapper = mapper;
            this._cloud = cloud;
        }
       

        public async Task<OperationResult<IEnumerable<AmenitieyDTO>>> GetAmenities()
        {
            var ameninties = await _repo.GetAmenities();

            if (!ameninties.Success)
                return OperationResult<IEnumerable<AmenitieyDTO>>.Failure(ameninties.ErrorMessage);

            var amendtos = _mapper.Map<IEnumerable<AmenitieyDTO>>(ameninties.Data);


            if (amendtos == null)
                return OperationResult<IEnumerable<AmenitieyDTO>>.Failure("Somthng goes wrong while mapping amenities");
            

            return OperationResult<IEnumerable<AmenitieyDTO>>.SuccessOperation(amendtos);
        }

        public async Task<OperationResult<AmenitieyDTO>> AddNewAminity(AddAminityDTO amenitieyDTO )
        {
            if (amenitieyDTO == null)
                return OperationResult<AmenitieyDTO>.Failure("Amenity cannot be null");

             OperationResult<FullImgInfoDTO> imginfo = await _cloud.UploadImageAsync(amenitieyDTO.Aminityimg);

            var amenity = _mapper.Map<Amenitiey>(amenitieyDTO);

            if (imginfo.Success)
            {
                

               amenity.EntityImageInfo= new EntityImage
                {
                    Id = Guid.NewGuid(),
                    EntitySet = enImageEntites.AMENITIEY,
                    Image = new SysImage
                    {
                        ImageID = Guid.NewGuid(),
                        DisplayURL = imginfo.Data.DisplayUrl,
                        DeletionURL = imginfo.Data.DeleteUrl,
                        UploadedAt = DateTime.UtcNow
                       
                    },
                    IsPrimary = true





                };

            }


            var result = _repo.AddAmenitiey(amenity); 

            if (!result.Success)
                return OperationResult<AmenitieyDTO>.Failure(result.ErrorMessage);

            var amenityDto = _mapper.Map<AmenitieyDTO>(result.Data);

            return OperationResult<AmenitieyDTO>.SuccessOperation(amenityDto);
        }

       
    }
}
