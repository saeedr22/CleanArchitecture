using CA.Domain.Entities;
using CA.Domain.ValueObjects;
using CA.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.EF.Contexts
{
    internal sealed class WriteDbContext : DbContext
    {
        public DbSet<TravelerCheckList> TravelerCheckLists { get; set; }




        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TravelerCheckList");

            var configuration = new WriteConfiguration();
            modelBuilder.ApplyConfiguration<TravelerCheckList>(configuration);
            modelBuilder.ApplyConfiguration<TravelerItem>(configuration);
        }
    }
}
