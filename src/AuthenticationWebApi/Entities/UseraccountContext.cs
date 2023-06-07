using AuthenticationWebApi.Dtos;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;

namespace AuthenticationWebApi.Entities
{
    public class UseraccountContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasPostgresExtension("uuid-ossp");
        }

        public UseraccountContext(DbContextOptions<UseraccountContext> options)
        : base(options)
        {
        }

        public DbSet<Useraccount> Users { get; set; } = null!;
    }
}
