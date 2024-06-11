using App.Domain;
using App.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Infrastructure.Repositories
{
    public class ProductRepository<T> : IRepository<T> where T : Product
    {
        public Task<T> AddAsync(T item)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<T>> AllAsync()
        {
            var fileName = Path.Combine(Directory.GetCurrentDirectory(), "MockData", "ProductData.json");
            var jsonString = File.ReadAllText(fileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            var products = JsonSerializer.Deserialize<ICollection<T>>(jsonString, options);

            return products == null ? Task.FromResult((ICollection<T>)Array.Empty<T>()) : Task.FromResult(products);

        }

        public Task<T> FindByAsync(string value)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
