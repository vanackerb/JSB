using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSBVelgenEnVeren.Models
{
    
    public class Banden : Product
    {
        public int BandenId { get; set; }

        public string Hoogte { get; set; }

        public string Breedte { get; set; }

        public string LaadIndex { get; set; }

        public int Diameter { get; set; }

        public int SnelheidsCode { get; set; }

        public int AutoId { get; set; }

        public List<Auto> AutoDetails { get; set; }
    }
}