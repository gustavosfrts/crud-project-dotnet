using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using estudo_dotnet.Entities;

namespace estudo_dotnet.Data.Context
{
    public class EstudoContext : DbContext
    {
        public EstudoContext(DbContextOptions<EstudoContext> options) : base(options) { }
        public DbSet<Product> Product { get; set; }
        public DbSet<User> User {get; set;}
    }
}