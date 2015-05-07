using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace JSBVelgenEnVeren.Models
{
    public partial class Order
    {
        
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:dd/MM/yyyy}")]
        public DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        public decimal Total { get; set; }
        [ScaffoldColumn(false)]
        public List<OrderDetail> OrderDetails { get; set; }



        public Client Client { get; set; }
    }
}