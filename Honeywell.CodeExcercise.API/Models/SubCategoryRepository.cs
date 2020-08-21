using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Models
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly AppDbContext appDbContext;

        public SubCategoryRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public Task<SubCategory> AddSubCategory(SubCategory subcategory)
        {
            throw new NotImplementedException();
        }

        public void DeleteSubCategory(int subcategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SubCategory>> GetSubCategory()
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> GetSubCategory(int subcategoryId)
        {
            throw new NotImplementedException();
        }

        public Task<SubCategory> UpdateSubCategory(SubCategory subcategory)
        {
            throw new NotImplementedException();
        }
    }
}
