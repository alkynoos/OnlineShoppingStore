using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Hubs;
using OnlineShoppingStore.Models.Home;
using OnlineShoppingStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    [Authorize]
    public class OrdersController : Controller
    {

        private dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();
        public GenericUnitOfWork _unitOfWork = new GenericUnitOfWork();

        // GET: Orders
        public ActionResult Index()
        {
            ViewData["Count"] = CartCount.cartcounter;
            return View(ctx.Orders.ToList());
        }

        //public ActionResult CheckoutComplete()
        //{
        //    CartCount.cartcounter = 0;
        //    ViewData["Count"] = CartCount.cartcounter;
        //    ViewBag.CheckoutCompleteMessage = "Thank you for your order.";
        //    return View();
        //}

        public ActionResult Checkout()
        {
            ViewData["Count"] = CartCount.cartcounter;
            List<Item> cart = (List<Item>)Session["cart"];
            var total = cart.Sum(item => item.Product.Price * item.Quantity);
            ViewData["TotalPrice"] = total;

                        //< p style = "margin-top:10px" align = "center" > @total €</ p >;
            return View();
        }

        [HttpPost]
        public ActionResult Checkout([Bind(Include = "FirstName,LastName,Address,City,AreaCode,PhoneNumber")] Order order)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            if (ModelState.IsValid)
            {
                
                order.OrderPlaced = DateTime.Now;
                decimal? total = 0m;
                decimal? l = 0m;
                foreach (var item in cart)
                {
                    l = item.Product.Price * item.Quantity;
                    total += l;
                }
                order.OrderTotal = total;
                order.OrderComplete = false;
            
                ctx.Orders.Add(order);
               

                ctx.SaveChanges();
             
                foreach ( var shoppingCartItem in cart)
                {
                    var orderDetail = new OrderDetail
                    {
                        Amount = shoppingCartItem.Quantity,
                        Price = shoppingCartItem.Product.Price,
                        ProductId = shoppingCartItem.Product.ProductId,
                        OrderId = order.OrderId
                    };
                    ctx.OrderDetails.Add(orderDetail);
                }
                ctx.SaveChanges();
                OrdersHub.BroadcastData();
                Session["cart"] = null;
            }
            return RedirectToAction("PaymentWithPaypal","Payment");
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