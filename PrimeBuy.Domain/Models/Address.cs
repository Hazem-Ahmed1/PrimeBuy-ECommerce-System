using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PrimeBuy.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
        [Required]
        [MaxLength(100)]
        public string City { get; set; }
        [Required]
        [MaxLength(200)]
        public string Street { get; set; }
        [Required]
        [MaxLength(20)]
        public string ZipCode { get; set; }
        public bool IsDefault { get; set; }

        [ForeignKey(nameof(ApplicationUser))]
        [Required]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Order> Orders { get; set; } = new HashSet<Order>();

        private Address() { }

        public Address(string userId, string country, string city, string street, string zip, bool isDefault)
        {
            ApplicationUserId = userId;
            Country = country;
            City = city;
            Street = street;
            ZipCode = zip;
            IsDefault = isDefault;
        }

    }
}
