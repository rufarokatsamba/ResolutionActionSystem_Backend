using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolutionActionSystem.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByIdAsync(int id);
        Task UpdateAsync(T entity);
        Task DeleteByIdAsync(int id);
        Task<T> Add(T entity);
        Task<bool> Exists(int id);
    }
}
