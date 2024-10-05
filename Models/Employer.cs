using System;
using System.ComponentModel.DataAnnotations;

namespace SSD_Employers.Models
{
    public class Employer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Employer Name")]
        [Required]
        public string Name { get; set; }

        [Phone]
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }


        [Url]
        [Required]
        [Display(Name = "Website")]
        public string Website { get; set; }

        [DataType(DataType.Date)]
        public DateTime? IncorporatedDate { get; set; }
    }
}
