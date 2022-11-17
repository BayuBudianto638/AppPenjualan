using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPenjualan.Database
{
    public class PenjualanContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionDetails> TransactionDetails { get; set; }

        public PenjualanContext(DbContextOptions<PenjualanContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connStr = "Server=FAIRUZ-PC\\SQLEXPRESS;Database=Penjualan;Trusted_Connection=True;TrustServerCertificate=True;";
        //    optionsBuilder.UseSqlServer(connStr);
        //}
    }
}
