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
    public class RoomTypeServ : IRoomTypeServ
    {
        private readonly IRoomTypeRepo _repo;
        private readonly IMapper _mapper;

        public RoomTypeServ(IRoomTypeRepo repo , IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        public OperationResult<ShowRoomTypeDTO> AddNewRoomType(AddRoomTypeDTO roomTypeDTO)
        {
            if (roomTypeDTO == null)
                return OperationResult<ShowRoomTypeDTO>.Failure("Room type data is required.");

            if (string.IsNullOrWhiteSpace(roomTypeDTO.Name))
                return OperationResult<ShowRoomTypeDTO>.Failure("Room type name is required.");

            if (roomTypeDTO.Capacity <= 0)
                return OperationResult<ShowRoomTypeDTO>.Failure("Capacity must be greater than zero.");

            if (roomTypeDTO.PricePerNight < 0)
                return OperationResult<ShowRoomTypeDTO>.Failure("Price per night must be non-negative.");


            var roomType = _mapper.Map<RoomType>(roomTypeDTO);


            if (roomTypeDTO.amenitiesIDs != null)
            {
                roomType.Amenities = roomTypeDTO.amenitiesIDs
                    .Select(id => new Amenitiey { Id = id })
                    .ToList();
            }

            var result = _repo.Create(roomType);

            if (!result.Success)
                return OperationResult<ShowRoomTypeDTO>.Failure(result.ErrorMessage ?? "Failed to create room type.");


            var showDto = _mapper.Map<ShowRoomTypeDTO>(result.Data);

            return OperationResult<ShowRoomTypeDTO>.SuccessOperation(showDto);
        }

        public async Task<OperationResult<IEnumerable<ShowRoomTypeDTO>>> GetAllRoomTypes()
        {
            var result = await _repo.GetRoomTypes();

            if (!result.Success)
                return OperationResult<IEnumerable<ShowRoomTypeDTO>>.Failure(result.ErrorMessage ?? "Failed to retrieve room types.");

            var showDtos = _mapper.Map<IEnumerable<ShowRoomTypeDTO>>(result.Data);

            return OperationResult<IEnumerable<ShowRoomTypeDTO>>.SuccessOperation(showDtos);
        }
    }
}
