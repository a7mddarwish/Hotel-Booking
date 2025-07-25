using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Core.DTOs
{
    public class RegistrationDTO
    {
        [Required]
        public string FName { get; set; }

        public string MName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string NationalityID { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Phone]
        public string SecondPhoneNum { get; set; }

        public string JobTitle { get; set; }

        public char Gender { get; set; }

        public string ProfileImage { get; set; }

        public DateOnly? BirthDate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }


        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password" , ErrorMessage = "The password and confirmation password do not match.") ]
        public string ConfirmPassword { get; set; }
    }

}
