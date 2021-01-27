using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using OnlineShoppingStore.Models.Home;


namespace OnlineShoppingStore.Controllers
{
    public class PartialViewController : Controller
    {
       private static dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();

        private static List<Product> productsList = ctx.Products.ToList();

        //private static ProductViewModel productVM = new ProductViewModel();

        private static List<ProductViewModel> productVMList = productsList.Select(x => new ProductViewModel
        {
            ProductId = x.ProductId,
            CategoryName = x.Category.CategoryName,
            ArtistName = x.Album.Artist.Name,
            AlbumName = x.Album.AlbumName,
            Genre = x.Album.Genre,
            ProductImage = x.ProductImage,
            Description = x.Description,
            IsFeatured = x.IsFeatured,
            Quantity = x.Quantity,
            Price = x.Price,
            ModifiedDate = x.ModifiedDate,
            CreatedDate = x.CreatedDate
        }).ToList();


       
        public ActionResult Index()
        {
            ViewData["Count"] = CartCount.cartcounter;
            ViewData.Model = productVMList;
            return View();
        }

        
        public PartialViewResult AllNewVM()
        {
           return PartialView("_Products", productVMList.Where(x=> x.IsFeatured==true));
        }


        public PartialViewResult AllVM()
        {
            return PartialView("_Products", productVMList);
        }

        public PartialViewResult AllVinyl()
        {
            return PartialView("_Products", productVMList.Where(x => x.CategoryName == "Vinyl"));
        }
        public PartialViewResult AllBoxSet()
        {
            return PartialView("_Products", productVMList.Where(x => x.CategoryName == "Boxset"));
        }
        public PartialViewResult AllCD()
        {
            return PartialView("_Products", productVMList.Where(x => x.CategoryName == "CD"));
        }
    }
}