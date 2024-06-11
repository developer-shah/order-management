using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository<T> : IRepository<T> where T : class
    {
        Task <Customer?> GetCustomerOrders(int id, int size);
    }
}
