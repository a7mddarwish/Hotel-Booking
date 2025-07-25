using HotelBooking.Core.Domain.Entities.IdentityEntities;
using HotelBooking.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Entities.BusineesEntites
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int RoomId { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal TotalPrice { get; set; }
        public enReservationState Status { get; set; } = enReservationState.Pending;
        public enPaidState PaymentStatus { get; set; } = enPaidState.Paid;
        public string? CancellationReason { get; set; }

        // Navigation
        public Room Room { get; set; }
        public Hotel Hotel { get; set; }
        public AppUser User { get; set; }
    }
}
