﻿using JSBVelgenEnVeren.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.ViewModel
{
    public class ShoppingCartViewModel
    {
        
        public List<Cart> CartItems { get; set; }
        public Decimal CartTotal { get; set; }
    
        
    }
}