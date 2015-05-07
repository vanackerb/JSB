using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JSBVelgenEnVeren.Models
{
    public class Velgen: Product
    {

        public int VelgId { get; set; }
        //Velgenmaat in inch
        public string Grootte{ get; set; }

        public String Breedte { get; set; }

        public String Steekmaat { get; set; }

        public String Offset { get; set; }

        public String Naafgat { get; set; }

        public int AutoId { get; set; }

        public List<Auto> AutoDetails { get; set; }

        

    }
}