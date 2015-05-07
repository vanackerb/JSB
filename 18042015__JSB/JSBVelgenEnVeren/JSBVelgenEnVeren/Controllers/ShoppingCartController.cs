using JSBVelgenEnVeren.Models;
using JSBVelgenEnVeren.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JSBVelgenEnVeren.Controllers
{
    public class ShoppingCartController : Controller
    {

        JSBVelgenEnVerenContext storeDB = new JSBVelgenEnVerenContext();

        // GET: ShoppingCart
        public ActionResult Index()
        {

            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            return View(viewModel);
        }
        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the product from the database
            var addedProduct = storeDB.Products
                .Single(product => product.ProductId == id);

            // Add it to the shopping cart
            var cart = ShoppingCart.GetCart(this.HttpContext);
            
            cart.AddToCart(addedProduct);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        // AJAX: /ShoppingCart/RemoveFromCart/5
        
        public ActionResult RemoveFromCart(int id)
        {

            // Remove the item from the cart
            var cart = ShoppingCart.GetCart(this.HttpContext);

            // Get the name of the product to display confirmation
            string productName = storeDB.Carts.FirstOrDefault(item => item.ProductId == id).Product.Naam;
                //.Single(item => item.ProductId == id).Product.Naam;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);
            
            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) +
                    " Is verwijderd uit het mandje.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                ItemCount = itemCount,
                DeleteId = id
            };
            return Json(results);
            //return RedirectToAction("Index");
        }

        // GET: /ShoppingCart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = ShoppingCart.GetCart(this.HttpContext);

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }

    }
}