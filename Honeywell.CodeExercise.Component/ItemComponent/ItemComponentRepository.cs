using Honeywell.CodeExercise.DataBase.ItemDataContext;
using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.Component.ItemComponent
{
    public class ItemComponentRepository : IItemComponentRepository
    {
        private readonly IItemRepository itemRepository;

        public ItemComponentRepository(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public async Task<Item> AddNewItem(Item item)
        {
            try
            {
                return await itemRepository.AddItem(item);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Item>> GetAllItem()
        {
            try
            {
                return await itemRepository.GetItem();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<Item> GetItemById(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ItemViewModel>> GetItemsByName(string name, PagingParameterModel pagingParameterModel)
        {
            try
            {
                var result = await itemRepository.GetItemsByName(name);

                if (result == null)
                {
                    throw new NotImplementedException();
                }

                int count = result.Count;
                int CurrentPage = pagingParameterModel.pageNumber;
                int PageSize = pagingParameterModel.pageSize;
                int TotalCount = count;
                int TotalPages = (int)Math.Ceiling(count / (double)PageSize);

                var items = result.Skip((CurrentPage - 1) * PageSize).Take(PageSize).ToList();
                var previousPage = CurrentPage > 1 ? "Yes" : "No";
                var nextPage = CurrentPage < TotalPages ? "Yes" : "No"; 

                var paginationMetadata = new
                {
                    totalCount = TotalCount,
                    pageSize = PageSize,
                    currentPage = CurrentPage,
                    totalPages = TotalPages,
                    previousPage,
                    nextPage
                };

                return items;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
