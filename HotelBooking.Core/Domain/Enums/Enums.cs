using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.Domain.Enums
{

    public enum enReservationState
    {
        Pending=0,       
        Confirmed=1,     
        Cancelled=2,     
        CheckedIn=3,     
        CheckedOut =4  

    }
    public enum enPaidState
    {
        Unpaid=0,
        Paid=1
    }

}
