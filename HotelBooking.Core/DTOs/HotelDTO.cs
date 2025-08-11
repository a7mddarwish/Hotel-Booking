using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Core.DTOs
{
    public class HotelDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(300)]
        public string Location { get; set; }

        [Required]
        [MaxLength (50)]
        public string City { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Range (0, 5)]
        public float RateFrom5 { get; set; }

        [Required, MaxLength (50)]
        public string OwnerId { get; set; }

        [Required]
        public bool IsActive { get; set; }

        [EmailAddress]
        public string? Email { get; set; }


        [Required , Phone]      
        public string PhoneToContact { get; set; }
        
    }
}
