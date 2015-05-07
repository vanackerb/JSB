using JSBVelgenEnVeren.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSBVelgenEnVeren.Controllers
{
    public class CheckoutController : Controller
    {
        
        JSBVelgenEnVerenContext storeDB = new JSBVelgenEnVerenContext();

        // GET: /Checkout/AddressAndPayment
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        // POST: /Checkout/AddressAndPayment
        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Order();
            TryUpdateModel(order);
           
            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;
                
                //Save Order
                storeDB.Orders.Add(order);
                storeDB.SaveChanges();
                
                //Process the order
                var cart = ShoppingCart.GetCart(this.HttpContext);
                cart.CreateOrder(order);
               
                return RedirectToAction("Complete",new { id = order.OrderId });
            }
            catch
            {
                return View(order);
            }
        }

        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = storeDB.Orders.Any(o => o.OrderId == id && o.Username == User.Identity.Name);

            if (isValid)
            {
                var orderDetail = storeDB.OrderDetails.Where(i => i.OrderId == id).Select(p => p).ToList();
                /*var order_detail =from u in storeDB.OrderDetails
                                   where u.OrderId == id
                                   select u;
                */
                foreach (OrderDetail p in orderDetail)
                {
                    var product = storeDB.Products.Where(a=>a.ProductId == p.ProductId).Select(q=>q).ToList();
                    foreach(Product pro in product)
                    {
                        pro.Unit -= p.Quantity;
                        storeDB.Entry(pro).State = EntityState.Modified;
                    }
                    
                    
                }
                storeDB.SaveChanges();
                return View(orderDetail);
            }

            else
            {
                return View("Error");
            }
        }
    }
}