using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using GraduationProjectIdentity.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<GraduationProjectIdentity.Models.Good> Good { get; set; }
        public DbSet<GraduationProjectIdentity.Models.TypeGood> typeGoods { get; set; }
        public DbSet<GraduationProjectIdentity.Models.Offer> Offers { get; set; }

    }
}
