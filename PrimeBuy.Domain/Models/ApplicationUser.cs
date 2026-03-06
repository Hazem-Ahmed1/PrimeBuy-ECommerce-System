using Microsoft.AspNetCore.Identity;
using Microsoft.Identity;
using System.ComponentModel.DataAnnotations;

namespace PrimeBuy.Domain.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The First Name Cannot Exceed 50 Characters")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The First Name Cannot Exceed 50 Characters")]
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();
        public Cart Cart { get; set; }



    }
}
