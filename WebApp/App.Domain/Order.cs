using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class Order : BaseEntity<Guid>
    {
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLine> Lines { get; set; } = new List<OrderLine>();
    }
}
