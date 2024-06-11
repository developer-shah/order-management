using App.Domain.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain
{
    public class InMemoryOrderList : IOrderList
    {
        public ConcurrentDictionary<int, ICollection<Order>> OrderList { get; set; } = new();
    }
}
