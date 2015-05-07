using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.Models
{
   
    public class Product
    {
        public int ProductId { get; set; }

        public String Naam { get; set; }

        public String Merk { get; set; }

        public String Type { get; set; }

        public int CategorieId { get; set; }

        public decimal Prijs { get; set; }

        public String Omschrijving { get; set; }

        public int Unit { get; set; }

        public string Url { get; set; }




        public virtual Category Category { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}