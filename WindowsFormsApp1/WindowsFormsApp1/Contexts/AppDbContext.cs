using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Entites;
using WindowsFormsApp1.Entities;
using WindowsFormsApp1.Entities.Auth;

namespace WindowsFormsApp1.Contexts
{ 
    public class AppDbContext : DbContext
    {
        public DbSet<RegisterEntity> RegisterEntities { get; set; }
        public DbSet<SearchLog> SearchLogs { get; set; }

        public AppDbContext() : base("name=DefaultConnection") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchLog>()
                .HasRequired(sl => sl.User) 
                .WithMany(u => u.SearchLogs) 
                .HasForeignKey(sl => sl.UserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
