using App.Domain;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class CustomerRepository<T> : ICustomerRepository<T> where T : Customer
    {
        private readonly IOrderList _orderList;

        public CustomerRepository(IOrderList orderList)
        {
            _orderList = orderList;
        }
        public Task<T> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> AllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Customer?> GetCustomerOrders(int id, int size)
        {
            Customer? customer = null;
            _orderList.OrderList.TryGetValue(id, out var existingOrders);
            if (existingOrders != null)
            {
                var ordersToReturn = existingOrders.OrderBy(x => x.OrderDate).Take(size).ToList();
                customer = new Customer();
                customer.Id = id;
                customer.Orders = ordersToReturn;
            }

            return Task.FromResult(customer);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
