using FreeRecycle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRecycle.Data.Services
{
    public interface IItemData
    {
       IEnumerable<Item> GetAll();
        Item Get(int id);
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
    }



}
