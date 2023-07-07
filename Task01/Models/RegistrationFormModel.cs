using System.ComponentModel.DataAnnotations;
using Task01.Controllers;

namespace Task01.Models
{
    public class RegistrationFormModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [FutureDate(ErrorMessage = "Дата консультації має бути у майбутньому")]
        [NonWeekend(ErrorMessage = "Дата консультації не повинна потрапляти на вихідні дні")]
        public DateTime DesiredConsultationDate { get; set; }
        [Required]
        public string Product { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date > DateTime.Now;
            }

            return false;
        }
    }

    public class NonWeekendAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                return date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday;
            }

            return false;
        }
    }
}
