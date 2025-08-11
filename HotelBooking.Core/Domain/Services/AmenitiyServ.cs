using AutoMapper;
using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
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

        public AmenitiyServ(IAmenitieyRepo repo , IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
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

        public OperationResult<AmenitieyDTO> AddNewAminity(AmenitieyDTO amenitieyDTO)
        {
            if (amenitieyDTO == null)
                return OperationResult<AmenitieyDTO>.Failure("Amenity cannot be null");


            var amenity = _mapper.Map<Amenitiey>(amenitieyDTO);

            var result = _repo.AddAmenitiey(amenity);

            if (!result.Success)
                return OperationResult<AmenitieyDTO>.Failure(result.ErrorMessage);

            var amenityDto = _mapper.Map<AmenitieyDTO>(result.Data);

            return OperationResult<AmenitieyDTO>.SuccessOperation(amenityDto);
        }
    }
}
