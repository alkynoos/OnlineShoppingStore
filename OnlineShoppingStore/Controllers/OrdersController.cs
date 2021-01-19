using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class OrdersController : Controller
    {

        private dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        // GET: Orders
        public ActionResult Index()
        {
            return View(ctx.Orders.ToList());
        }

        public ActionResult CheckoutComplete()
        {
            CartCount.cartcounter = 0;
            ViewData["Count"] = CartCount.cartcounter;
            ViewBag.CheckoutCompleteMessage = "Thank you for your order.";
            return View();
        }

        public ActionResult Checkout()
        {
            ViewData["Count"] = CartCount.cartcounter;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout([Bind(Include = "FirstName,LastName,Address,City,AreaCode,PhoneNumber")] Order order)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            if (ModelState.IsValid)
            {
                
                order.OrderPlaced = DateTime.Now;
                decimal total = 0m;
                decimal l = 0m;
                foreach (var item in cart)
                {
                    l = item.Product.Price * item.Quantity;
                    total += 1;
                }
                order.OrderTotal = total;
                
                ctx.Orders.Add(order);
                order.OrderComplete = false;

                ctx.SaveChanges();
                foreach( var shoppingCartItem in cart)
                {
                    var orderDetil = new OrderDetail
                    {
                        Amount = shoppingCartItem.Quantity,
                        Price = shoppingCartItem.Product.Price,
                        ProductId = shoppingCartItem.Product.ProductId,
                        OrderId = order.OrderId
                    };
                    ctx.OrderDetail.Add(orderDetil);
                }
                ctx.SaveChanges();
                Session["cart"] = null;
            }
            return RedirectToAction("CheckoutComplete");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _unitOfWork.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}