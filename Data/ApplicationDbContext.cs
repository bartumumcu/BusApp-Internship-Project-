using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BusApp.Models;

namespace BusApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BusApp.Models.Bus>? Bus { get; set; }
        public DbSet<BusApp.Models.Driver>? Driver { get; set; }
        public DbSet<BusApp.Models.Line>? Line { get; set; }
        public DbSet<BusApp.Models.Trip>? Trip { get; set; }
    }
}