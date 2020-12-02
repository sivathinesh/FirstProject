using FreeRecycle.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRecycle.Data.Services
{
    public class SqlItemData : IItemData
    {
        private FreeRecycleDBContext db;

        public SqlItemData(FreeRecycleDBContext db)
        {
            this.db = db;
        }

        public void Add(Item item)
        {
            db.Items.Add(item);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Item removeItem = db.Items.Find(id);
            db.Items.Remove(removeItem);
            db.SaveChanges();
        }

        public Item Get(int id)
        {
           return  db.Items.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Item> GetAll()
        {

            return from r in db.Items orderby r.Name select r;

        }

        public void Update(Item item)
        {

            var entry = db.Entry(item);
            entry.State =EntityState.Modified;
            db.SaveChanges();

        }
    }
}
