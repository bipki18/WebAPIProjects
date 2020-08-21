using Honeywell.CodeExercise.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Honeywell.CodeExercise.DataBase.ItemDataContext
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> GetItem();
        Task<Item> GetItem(int itemId);
        Task<List<ItemViewModel>> GetItemsByName(string name);
        Task<Item> AddItem(Item item);
        Task<Item> UpdateItem(Item item);
        void DeleteItem(int itemId);
    }
}
