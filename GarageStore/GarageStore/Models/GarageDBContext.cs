using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GarageStore.Models
{
    public class GarageDBContext: DbContext
    {
        public GarageDBContext() : base("GarageDbContext") { }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Message> Messages { get; set; }

      

       
    }
}