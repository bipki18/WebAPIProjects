using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Models
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetSubCategory();
        Task<SubCategory> GetSubCategory(int subcategoryId);
        Task<SubCategory> AddSubCategory(SubCategory subcategory);
        Task<SubCategory> UpdateSubCategory(SubCategory subcategory);
        void DeleteSubCategory(int subcategoryId);
    }
}
