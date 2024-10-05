using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SSD_Employers.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required,Display(Name ="First Name" )]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
    }
}
