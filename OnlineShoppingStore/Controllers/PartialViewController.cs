using OnlineShoppingStore.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class PartialViewController : Controller
    {
        dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();
        // GET: PartialView
        public ActionResult Index()
        {
            return View();
        }
        
        //public PartialViewResult AllNew()
        //{
        //    List<Product> productsList = ctx.Products.Where(x=>x.IsFeatured == true).ToList();

        //    return PartialView("_newProducts", productsList);
        //}
        
        
        //public PartialViewResult All()
        //{
        //    List<Product> productsList = ctx.Products.ToList();

        //    return PartialView("_newProducts", productsList);
        //}
    }
}