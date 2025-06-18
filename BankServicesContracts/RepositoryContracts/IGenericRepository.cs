using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankServicesContracts.RepositoryContracts
{
    public interface IGenericRepository<T>
    {
        public Task<Boolean> IsObjectIdExists(int id);
        public Task<IEnumerable<T>?> GetAllValuesAsync();
        public Task<T?> GetValueByIdAsync(int id);
        public Task AddAsync(T entity);
        public void DeleteElement(T entity);
        public void UpdateObject(T entity);
        public Task SaveAsync();
    }
}


