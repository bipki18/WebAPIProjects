using Honeywell.CodeExercise.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExcercise.API.Models
{
    public class ItemRepository : IItemRepository
    {
        private readonly AppDbContext appDbContext;

        public ItemRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Item> AddItem(Item item)
        {
            var result = await appDbContext.Items.AddAsync(item);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async void DeleteItem(int itemId)
        {
            var result = await appDbContext.Items
                .FirstOrDefaultAsync(e => e.Id == itemId);
            if (result != null)
            {
                appDbContext.Items.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Item>> GetItem()
        {
            return await appDbContext.Items.ToListAsync();
        }

        public async Task<Item> GetItem(int itemId)
        {
            return await appDbContext.Items.FirstOrDefaultAsync(e => e.Id == itemId);
        }

        public async Task<List<ItemViewModel>> GetItemsByName(string name)
        {
            List<ItemViewModel> itemViewModellst = new List<ItemViewModel>();
            ItemViewModel itemViewModel = null;
            // var result;
            if (string.IsNullOrEmpty(name))
            {

                var act = (from i in appDbContext.Items
                                  join s in appDbContext.SubCategories on i.SubCategoryId equals s.Id
                                  join ca in appDbContext.Categories on s.CategoryId equals ca.Id
                                  select new
                                  {
                                      ItemName = i.Name,
                                      Description = i.Description,
                                      Category = ca.Name,
                                      SubCategory = s.Name,
                                  }).ToList();


                for(int i=0; i< act.Count; i++)
                {
                    itemViewModel = new ItemViewModel();
                    itemViewModel.ItemName= (act[i].ItemName);
                    itemViewModel.ItemDescription = act[0].Description;
                    itemViewModel.Category = act[0].Category;
                    itemViewModel.Subcategory = act[0].SubCategory;
                    itemViewModellst.Add(itemViewModel);
                }

               
            }
            else
            {
                var act = (from i in appDbContext.Items
                           join s in appDbContext.SubCategories on i.SubCategoryId equals s.Id
                           join ca in appDbContext.Categories on s.CategoryId equals ca.Id

                           where i.Name == name
                           select new
                           {
                               ItemName = i.Name,
                               Description = i.Description,
                               Category = ca.Name,
                               SubCategory = s.Name,
                           }).ToList();

                for (int i = 0; i < act.Count; i++)
                {
                    itemViewModel = new ItemViewModel();
                    itemViewModel.ItemName = (act[i].ItemName);
                    itemViewModel.ItemDescription = act[0].Description;
                    itemViewModel.Category = act[0].Category;
                    itemViewModel.Subcategory = act[0].SubCategory;
                    itemViewModellst.Add(itemViewModel);
                }
            }

            return itemViewModellst;
        }

        public async Task<Item> UpdateItem(Item item)
        {
            var result = await appDbContext.Items
                .FirstOrDefaultAsync(e => e.Id == item.Id);

            if (result != null)
            {
                result.Name = item.Name;
                result.Description = item.Description;
                result.SubCategoryId = item.SubCategoryId;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
