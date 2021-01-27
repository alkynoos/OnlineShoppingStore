using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {
       private static dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();

        private static List<Product> productsList = ctx.Products.ToList();

       
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
            ViewData.Model = productVMList.Where(x=>x.IsFeatured == true);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            ViewData["Count"] = CartCount.cartcounter;
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            ViewData["Count"] = CartCount.cartcounter;
            return View();
        }
        


        
        public PartialViewResult AllNewVM()
        {
            dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();



            List<Product> productsList = ctx.Products.ToList();

            ProductViewModel productVM = new ProductViewModel();

            List<ProductViewModel> productVMList = productsList.Select(x => new ProductViewModel
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
            }).Where(x => x.IsFeatured == true).ToList();

            return PartialView("_Products", productVMList);
        }


        public PartialViewResult AllVM()
        {
            dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();



            List<Product> productsList = ctx.Products.ToList();

            ProductViewModel productVM = new ProductViewModel();

            List<ProductViewModel> productVMList = productsList.Select(x => new ProductViewModel
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

            return PartialView("_Products", productVMList);
        }
    }
}