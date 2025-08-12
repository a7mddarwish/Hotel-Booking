using AutoMapper;
using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.Domain.ServicesContracts;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;

namespace HotelBooking.Core.Domain.Services
{
    public class HotelServ : IHotelServ
    {
        private readonly IHotelRepo _repo;
        private readonly IMapper _mapper;

        public HotelServ(IHotelRepo repo , IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        public OperationResult<HotelDTO> AddNewHotel(HotelDTO hotelDto)
        {
            if (hotelDto == null)
                return OperationResult<HotelDTO>
                    .Failure("Hotel information is null, cannot add new hotel");

            var hotel = _mapper.Map<Hotel>(hotelDto);
            var result = _repo.AddNewHotel(hotel);


            if (!result.Success)
                return OperationResult<HotelDTO>
                    .Failure("Error while adding new hotel");

            var hotelDtoResult = _mapper.Map<HotelDTO>(result.Data);
            return OperationResult<HotelDTO>
                .SuccessOperation(hotelDtoResult);


        }

        public async Task<OperationResult<HotelDTO>> Find(int id)
        {
            if (id < 0)
                return OperationResult<HotelDTO>
                    .Failure("Enter a valied Hotel id");

            var htl = await _repo.Find(id);

            if (!htl.Success)
                return OperationResult<HotelDTO>
                        .Failure($"Cannot find Hotel with id = {id} into the system");

            var hoteldto = _mapper.Map<HotelDTO>(htl);

            return OperationResult<HotelDTO>
                .SuccessOperation(hoteldto);

        }

        public async Task<OperationResult<List<HotelDTO>>> GetAllHotels()
        {

            var result = await _repo.GetAllHotels();
            if (!result.Success)
                return OperationResult<List<HotelDTO>>
                    .Failure("Error while getting all hotels");

            var hotelsDto = _mapper.Map<List<HotelDTO>>(result.Data);

            return OperationResult<List<HotelDTO>>
                .SuccessOperation(hotelsDto);



        }

        public async Task<OperationResult<HotelDTO>> UpdateHotel(HotelDTO hotelDto , int id)
        {
            if (hotelDto == null)
                return OperationResult<HotelDTO>
                    .Failure("Error before updating proccess, hotel information not found to complete update proccess");

            if (hotelDto.Id != id)
                return OperationResult<HotelDTO>
                    .Failure("the hotel id is not correct");


            // Implelmet find first and map and upsate

            var htl = await _repo.Find(id);
            if (!htl.Success)
                return OperationResult<HotelDTO>
                    .Failure($"Cannot find Hotel with id = {id} into the system");

            _mapper.Map(hotelDto, htl.Data);

            var result = await _repo.Update(htl.Data);

            return (result.Success) ?
                OperationResult<HotelDTO>.SuccessOperation(_mapper.Map<HotelDTO>(result.Data)) :
                OperationResult<HotelDTO>.Failure("Error while updating hotel information");
        }


     
    }

}
