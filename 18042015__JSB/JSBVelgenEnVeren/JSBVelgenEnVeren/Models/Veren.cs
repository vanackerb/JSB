using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.Models
{
    public class Veren: Product
    {
        public int VerenId { get; set; }

        public int AutoId { get; set; }

        public List<Auto> AutoDetails { get; set; }
    }
}