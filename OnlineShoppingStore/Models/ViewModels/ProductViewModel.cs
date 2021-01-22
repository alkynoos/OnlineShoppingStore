using OnlineShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShoppingStore.Models.ViewModels
{
    public class ProductViewModel
    {
        
        [Key]
        public int ProductId { get; set; }

        


        public string CategoryName { get; set; }

        
        public string ArtistName { get; set; }
        
        public string AlbumName { get; set; }

        public string ProductName
        {
            get { return this.CategoryName + ": " + this.ArtistName + " " + this.AlbumName; }

        }

        public string Genre { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string Description { get; set; }
        public string ProductImage { get; set; }
        public bool? IsFeatured { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }

        public virtual List<Product> Products { get; set; }
       
    }
}