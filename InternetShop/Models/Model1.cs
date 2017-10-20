namespace InternetShop.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<order_item> order_item { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.items)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.category_id);

            modelBuilder.Entity<item>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<item>()
                .HasMany(e => e.order_item)
                .WithRequired(e => e.item)
                .HasForeignKey(e => e.item_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_item)
                .WithRequired(e => e.order)
                .HasForeignKey(e => e.order_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id)
                .WillCascadeOnDelete(false);
        }
    }
}
