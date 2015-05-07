using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.Models
{
    public class Auto
    {
        public int AutoId { get; set; }

        public String AutoMerk { get; set; }
        public String AutoModel { get; set; }
        public int Bouwjaar { get; set; }

        
    }
}