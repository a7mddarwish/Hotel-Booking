using AutoMapper;
using HotelBooking.Core.Domain.Entities.BusineesEntites;
using HotelBooking.Core.Domain.ReposConstracts;
using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Infrastructure.Repos
{
    public class HotelRepo : BaseRepo, IHotelRepo
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;

        public HotelRepo(AppDbContext Context , IMapper mapper) : base(Context) 
        {
            this._context = Context;
            this._mapper = mapper;
        }
        public OperationResult<Hotel> AddNewHotel(Hotel Hotel)
        {

            if (Hotel == null)
                return OperationResult<Hotel>
                    .Failure("Error before saving proccess, hotel information not found to complete insertation proccess");


            if(Hotel.OwnerId == Guid.Empty)
            {
                return OperationResult<Hotel>
                    .Failure("Error while saving hotel information, owner id is not valid");
            }


            if (_context.Users.Where(u => u.Id == Hotel.OwnerId).Count() <= 0)
            {
                return OperationResult<Hotel>
                    .Failure("Error while saving hotel information,this is not an owner or owner id is not valid");
            }


            if (_context.Hotels.Any(h => h.Name == Hotel.Name && h.Country == Hotel.Country ))
            {
                return OperationResult<Hotel>
                    .Failure("Error while saving hotel information, this hotel name already exists in this country for this owner");
            }

             _context.Hotels.Add(Hotel);



            return (_context.SaveChanges() > 0) ?
                 OperationResult<Hotel>.SuccessOperation(Hotel) :
                 OperationResult<Hotel>.Failure("Error while saving hotel information");



        }
        public async Task<OperationResult<Hotel>> Update(Hotel Hotel)
        {
            

            if (Hotel == null)
            {
                return OperationResult<Hotel>
                    .Failure("Error while updating hotel information, this hotel is not found");
            }
            
           
            var result = _context.Hotels.Update(Hotel);

            return (_context.SaveChanges() > 0) ?
                 OperationResult<Hotel>.SuccessOperation(Hotel) :
                 OperationResult<Hotel>.Failure("Error while updating hotel information");

        }
        public async Task<OperationResult<Hotel>> Find(int id)
        {
            var acthotel = (await _context.Hotels.FindAsync(id));

            if (acthotel == null)
                return OperationResult<Hotel>
                    .Failure($"Cannot find Hotel with id = {id} into the system");




            return OperationResult<Hotel>
                .SuccessOperation(data:acthotel);


        }
        public async Task<OperationResult<List<Hotel>>> GetAllInCity(string City)
        {

           
            var hotelsInCity = await _context.Hotels.
                Where(h => h.City.Equals(City, StringComparison.OrdinalIgnoreCase))
                .Include(h => h.Owner)
                .ToListAsync();



            if (hotelsInCity == null || hotelsInCity.Count == 0)
                {
                return OperationResult<List<Hotel>>
                    .Failure($"No hotels found in the city: {City}");
            }

            return OperationResult<List<Hotel>>
                .SuccessOperation(hotelsInCity);


        }
        public async Task<OperationResult<List<Hotel>>> GetAllHotelsbystatus(bool IsActive)
        {
            var AllHotels = await GetAllHotels();

            if (AllHotels == null || AllHotels.Data.Count() <= 0)
                return OperationResult<List<Hotel>>
                    .Failure("cannot find any hotel");


            var hotels = AllHotels.Data.Where(h => h.IsActive == IsActive);

            return OperationResult<List<Hotel>>
                .SuccessOperation(data:hotels.ToList());
        }
        public async Task<OperationResult<List<Hotel>>> GetAllHotels()
        {
          
                var hotels = await _context.Hotels.ToListAsync();

                if (hotels == null || hotels.Count == 0)
                {
                    return OperationResult<List<Hotel>>.Failure("No hotels found.");
                }

                return OperationResult<List<Hotel>>.SuccessOperation(hotels);


        }
        public async Task<OperationResult<List<Hotel>>> GetAllInCountry(string Country)
        {
            var AllHotels = await GetAllHotels();

            if (AllHotels == null || AllHotels.Data.Count() <= 0)
                return OperationResult<List<Hotel>>
                    .Failure("cannot find any hotel");


            var hotels = AllHotels.Data.Where(h => h.Country.Equals(Country ,StringComparison.OrdinalIgnoreCase));

            return OperationResult<List<Hotel>>
                .SuccessOperation(data: hotels.ToList());

        }
        public async Task<OperationResult<List<Hotel>>> GetAllHotelsByOwnerId(Guid OwnerId)
        {
            var AllHotels = await GetAllHotels();

            if (AllHotels == null || AllHotels.Data.Count() <= 0)
                return OperationResult<List<Hotel>>
                    .Failure("cannot find any hotel");


            var hotels = AllHotels.Data.Where(h => h.OwnerId == OwnerId);

            return OperationResult<List<Hotel>>
                .SuccessOperation(data: hotels.ToList());
        }
      

      
      
    

     

     
    }
}
