using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
   }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<FeatEntity> Feats { get; set; }
        public DbSet<PlayerCharacterEntity> Characters { get; set; }
    }
}