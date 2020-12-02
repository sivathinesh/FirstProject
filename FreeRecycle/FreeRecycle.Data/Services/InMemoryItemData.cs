using FreeRecycle.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRecycle.Data.Services
{
    public class InMemoryItemData : IItemData
    {


        List<Item> items;

        public InMemoryItemData()
        {
            items = new List<Item>()
            {
                new Item{Id = 1, Name = "Samsung Note 20 Ultra", Category = Category.Electronic, Description = "It's a brand new 2020 Samsung mobile.", Contact = "Email: sivathinesh@gmail.com"},
                new Item{Id = 2, Name = "Harry Potter and the Prisoner of Azkaban", Category = Category.Books, Description = "Harry Potter is a wizard. He is in his third year at Hogwarts School of Witchcraft and Wizardry. ", Contact = "Phone number: 199248494"},
                new Item{Id = 3, Name = "John Lewis & Partners Calia Desk, Oak", Category = Category.Furniture, Description = "In a good condition and easy to use.", Contact = "10 granville avenue, feltham, tw1239ll"}

            };
        }

        public void Add(Item item)
        {
            items.Add(item);
            item.Id = items.Max(r => r.Id) + 1;
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Item Get(int id)
        {

            return items.FirstOrDefault(r => r.Id == id);

        }

        public IEnumerable<Item> GetAll()
        {
            return items.OrderBy(r => r.Name);
        }

        public void Update(Item item)
        {

            var currentItem = Get(item.Id);
            if(currentItem != null)
            {
                currentItem.Name = item.Name;
                currentItem.Category = item.Category;
                currentItem.Description = item.Description;
            }

        }
    }
}
