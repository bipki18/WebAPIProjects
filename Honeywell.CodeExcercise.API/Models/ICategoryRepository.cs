using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Models
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategory();
        Task<Category> GetCategory(int categoryId);
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        void DeleteCategory(int categoryId);
    }
}
