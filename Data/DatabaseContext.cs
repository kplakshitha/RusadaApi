using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        public DbSet<AircraftDetail> AircraftDetails { get; set; }
    }
}
