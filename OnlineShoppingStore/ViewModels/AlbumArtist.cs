using OnlineShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace OnlineShoppingStore.ViewModels
{
    public class AlbumArtist
    {
        public Album album { get; set; }
        public List<Artist> artists{ get; set; }
    }
}