using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.ViewModel
{
    public class ShoppingCartRemoveViewModel
    {
        public String Message { get; set; }
        public Decimal CartTotal { get; set; }
        public int CartCount { get; set; }
        public int ItemCount { get; set; }
        public int DeleteId { get; set; }

    }
}