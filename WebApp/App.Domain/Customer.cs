using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class Customer : BaseEntity<int>
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
