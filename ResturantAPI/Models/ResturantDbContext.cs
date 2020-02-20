using Microsoft.EntityFrameworkCore;
using ResturantAPI.Models.BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResturantAPI.Models
{
    public class ResturantDbContext:DbContext
    {
        public ResturantDbContext(DbContextOptions<ResturantDbContext> options) 
            : base(options)
        {

        }
        
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Categorys> Categorys { get; set; }
        public DbSet<Editors> Editors { get; set; }
        public DbSet<Logos> Logos { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<Sliders> Sliders { get; set; }
        public DbSet<Images> Images { get; set; }
    }
}
