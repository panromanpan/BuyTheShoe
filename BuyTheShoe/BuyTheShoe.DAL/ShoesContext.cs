using BuyTheShoe.Model;

namespace BuyTheShoe.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoesContext : DbContext
    {
        public ShoesContext()
            : base("name=ShoesContext")
        {
        }

        public virtual DbSet<Shoe> Shoes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shoe>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);
        }
    }
}
