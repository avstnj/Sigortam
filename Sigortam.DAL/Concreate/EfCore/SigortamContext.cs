using Microsoft.EntityFrameworkCore;
using Sigortam.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sigortam.DAL.Concreate.EfCore
{
    public class SigortamContext : DbContext
    {
        public SigortamContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Bid> Bids { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=TANJUAVSAR;Database=SigortamDB;Trusted_Connection=true;");
        //}
    }
}
