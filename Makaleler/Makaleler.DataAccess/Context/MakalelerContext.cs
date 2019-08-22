using Makaleler.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makaleler.DataAccess.Context
{
   public class MakalelerContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;User ID=sa;initial catalog=MakalelerDb;Password=123;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Yazar> Yazar { get; set; }

        public DbSet<Makale> Makale { get; set; }

        public DbSet<Kategori> Kategori { get; set; }
    }
}
