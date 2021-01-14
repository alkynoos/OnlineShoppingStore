using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models
{
    public class ArtistDetails
    {
        public int ArtistId { get; set; }

        public string Genre { get; set; }
        [Required(ErrorMessage = "Artist Name Requird")]
        [StringLength(100, ErrorMessage = "From 3 to 5 and maximum 100 characters are allowed", MinimumLength = 3)]
        public string Name { get; set; }
        public string Country { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsDelete { get; set; }
    }
}