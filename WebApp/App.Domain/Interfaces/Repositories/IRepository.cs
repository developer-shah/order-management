using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetAsync(Guid id);
        Task<T> FindByAsync(string value);
        Task<ICollection<T>> AllAsync();
        Task<T> AddAsync(T item);
        Task SaveChangesAsync();
    }
}
