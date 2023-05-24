using System.ComponentModel.DataAnnotations;

namespace contact_management.Models.ViewModel
{
    public class AddContactViewModel
    {
        [MinLength(5)]
        [Required]
        public string Name { get; set; }

        [MinLength(9), MaxLength(9)]
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
