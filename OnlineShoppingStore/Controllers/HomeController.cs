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
        dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities(); //We can use reposiory

        public ActionResult Index(string search, int? page)
        {
            HomeIndexViewModel model = new HomeIndexViewModel();

            return View(model.CreateModel(search, 4, page));//page size
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        
        
        
        public ActionResult OurProducts()
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


            return View(productVMList);
        }
        

   

    }
}