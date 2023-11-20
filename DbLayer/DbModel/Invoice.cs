using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLayer.DbModel
{
    public class Invoice
    {
        public int Id { get; set; } 
        public int OrderId { get; set; }    
        public double Price { get; set; }   
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        //public Order Order { get; set; }
        public virtual Order Order { get; set; }
    }
}
