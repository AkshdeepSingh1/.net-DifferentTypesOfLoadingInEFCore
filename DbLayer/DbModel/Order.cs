using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.DbModel
{
    public class Order
    {
        public int Id { get; set; } 
        public string Description { get; set; }
        public int CustomerId { get; set; }
        //public Invoice Invoice { get; set; }
        //public Customer Customer { get; set; }  
        public virtual Invoice Invoice { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
