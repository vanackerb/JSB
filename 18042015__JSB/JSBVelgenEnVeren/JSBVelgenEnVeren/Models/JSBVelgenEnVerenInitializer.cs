using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace JSBVelgenEnVeren.Models
{
    public class JSBVelgenEnVerenInitializer: DropCreateDatabaseIfModelChanges<JSBVelgenEnVerenContext>
    {

        protected override void Seed(JSBVelgenEnVerenContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
           // GetProducts().ForEach(p => context.Products.Add(p));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category { CategoryId = 1,
                    Naam = "Banden" },
                new Category { CategoryId = 2,
                    Naam = "Velgen" },
                new Category {CategoryId = 3,
                    Naam = "Veren"},
            };
            return categories;
        }

       /* private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product { ProductId = 1, 
                    Naam = "Pirelli", 
                    Omschrijving = "De echte raceband" + "Power it up and let it go!", 
                    Url="Tires.jpg", 
                    Prijs = 57, 
                    CategorieId = 1 },

                    new Product { ProductId = 2, 
                    Naam = "BBS", 
                    Omschrijving = "De echte racevelg!", 
                    Url="Velg.jpg", 
                    Prijs = 80, 
                    CategorieId = 2 },

                    new Product { ProductId = 3, 
                    Naam = "Spring", 
                    Omschrijving = "De echte raceveer!", 
                    Url="shock absorbers.jpg", 
                    Prijs = 110, 
                    CategorieId = 3 },
            };
            return products;
        }*/
    }
}