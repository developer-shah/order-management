using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
