//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShoppingStore.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public Nullable<int> TrackNo { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> ReleaseDate { get; set; }
        public string Genre { get; set; }
        public Nullable<int> ArtistId { get; set; }
    
        public virtual Artist Artist { get; set; }
    }
}
