using App.Domain;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class OrderRepository<T> : IRepository<T> where T : Order
    {
        private readonly IOrderList _orderList;

        public OrderRepository(IOrderList orderList)
        {
            _orderList = orderList;
        }
        public Task<T> AddAsync(T item)
        {
            var allOrders = new List<Order>();
            _orderList.OrderList.TryGetValue(item.CustomerId, out var existingOrders);
            if (existingOrders != null)
            {
                allOrders.AddRange(existingOrders);
                allOrders.Add(item);
                _orderList.OrderList.TryUpdate(item.CustomerId, allOrders, existingOrders);
            }
            else
            {
                _orderList.OrderList.TryAdd(item.CustomerId, [item]);
            }           
            
            return Task.FromResult(item);
        }

        public Task<ICollection<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<T?> GetAsync(Guid id)
        {
            var orderList = _orderList.OrderList.Values.FirstOrDefault(x => x.Any(y => y.Id == id));
            if (orderList == null)
            {
                return Task.FromResult(default(T));
            }

            var order = orderList.FirstOrDefault(x => x.Id == id);

            return Task.FromResult((T?)order);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
