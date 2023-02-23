using Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Configuration
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {


        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        { 
        }

        public DbSet<Message> Message { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id); 

            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            
            return " Data Source = VAGNER-PC; Initial Catalog = API_DDD_2022; Integrated Security = True;MultipleActiveResultSets=True"


;
        }

    }
}
