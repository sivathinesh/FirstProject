using FreeRecycle.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeRecycle.Data.Services
{
    public class FreeRecycleDBContext : DbContext 
    {
        public DbSet<Item> Items { get; set; }

    }
}
