using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShoppingStore.Controllers
{
    public class ShoppingCartItemController : Controller
    {

        private dbMyOnlineShoppingEntities ctx = new dbMyOnlineShoppingEntities();

        // GET: ShoppingCartItem
        public ActionResult Index()
        {
            ViewData["Count"] = CartCount.cartcounter;
            return View();
        }

        public ActionResult Buy(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                var product = ctx.Products.Find(id);

                cart.Add(new Item()
                {
                    Product = product,
                    Quantity = 1
                });

                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    var product = ctx.Products.Find(id);
                    cart.Add(new Item {
                        Product = product,
                        Quantity = 1 
                    });
                    Session["cart"] = cart;
                }
            }
            CartSinolo();
            return RedirectToAction("Index", "PartialView"); 
        }
        public ActionResult Remove(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            cart.RemoveAt(index);
            Session["cart"] = cart;
            if (cart.Count == 0)
            {
                CartCount.cartcounter = 0;
                return RedirectToAction("Index", "Home"); // this needs review
            }
            CartSinolo();
            return RedirectToAction("Index");
        }

        public ActionResult IncreaseQuantity(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            var product = ctx.Products.Find(id);
            foreach (var item in cart)
            {
                if (item.Product.ProductId == id)
                {
                    item.Quantity++;
                }                
            }
            CartSinolo();
            Session["cart"] = cart;
            return RedirectToAction("Index");
        }

        public ActionResult ReduceQuantity(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            int index = isExist(id);
            var product = ctx.Products.Find(id);
            var localAmount = 0;
            if (cart[index].Quantity > 1)
            {
                cart[index].Quantity--; ;
                localAmount = cart[index].Quantity;
            }
            else
            {
                cart.RemoveAt(index);
            }
            Session["cart"] = cart;
            if (cart.Count == 0)
            {
                CartCount.cartcounter = 0;
            }
            CartSinolo();
            return RedirectToAction("Index");
        }

        public ActionResult ClearCart()
        {
            Item item = new Item();
            List<Item> cart = (List<Item>)Session["cart"];
            Session["cart"] = null;
            CartCount.cartcounter = 0;
            return RedirectToAction("Index", "Home");
        }

        private int isExist(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Product.ProductId.Equals(id))
                {
                    return i;
                }
            }
            return (-1);
        }

        public void CartSinolo()
        {
            List<Item> cart = (List<Item>)Session["cart"];
            CartCount.cartcounter = 0;
            foreach (var item in cart)
            {
                CartCount.cartcounter = CartCount.cartcounter + item.Quantity;
            }
            ViewData["Count"] = CartCount.cartcounter;
        }

     
    }


}