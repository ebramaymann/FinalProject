using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Good> Good { get; set; }
        public DbSet<WebApplication1.Models.TypeGood> typeGoods { get; set; }
        public DbSet<WebApplication1.Models.Offer> Offers { get; set; }
        public DbSet<WebApplication1.Models.Order> Orders { get; set; }
        public DbSet<WebApplication1.Models.OrderDetails> OrderDetails { get; set; }

    }
}
