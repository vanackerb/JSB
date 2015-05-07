using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JSBVelgenEnVeren.Models
{
    public class Category
    {

        public Int32 CategoryId { get; set; }
        public string Naam { get; set; }
        public List<Product> Products { get; set; }
    

    }
}
