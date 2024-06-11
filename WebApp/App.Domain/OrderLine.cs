using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class OrderLine : BaseEntity<int>
    {
        public Order Order { get; set; } = new();
        public Product Product { get; set; } = new();
    }
}
