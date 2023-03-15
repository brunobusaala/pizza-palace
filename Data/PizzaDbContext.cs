
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NewPizzaPalace.Models;

namespace NewPizzaPalace.Data
{

    public class PizzaDbContext : IdentityDbContext
    {
        //By Creating the ApplicationDbContext constructor; It will be easier to pass the Connection String and other things to Context class
        //Here we pass the DbContextOptions to be applied to ApplicationDbcontext.
        public PizzaDbContext(DbContextOptions<PizzaDbContext> options)
            : base(options)
        {

        }

        public DbSet<Size> Size { get; set; }
        public DbSet<BasicTopping> BasicToppings { get; set; }
        public DbSet<DeluxeTopping> DeluxeToppings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BasicTopping>()
                .HasOne(b => b.Size)
                .WithMany(s => s.BasicToppings)
                .HasForeignKey(b => b.SizeID);

            modelBuilder.Entity<DeluxeTopping>()
                .HasOne(d => d.Size)
                .WithMany(s => s.DeluxeToppings)
                .HasForeignKey(d => d.SizeID);


            modelBuilder.Entity<Size>().HasData(
             new Size { SizeID = "Small", Price = 12m },
             new Size { SizeID = "Medium", Price = 14m },
             new Size { SizeID = "Large", Price = 16m });

            modelBuilder.Entity<BasicTopping>().HasData(
             new BasicTopping { BasicTopppingID = 1, SizeID = "Small", Cheese = 0.5m, Pepperoni = 0.5m, Ham = 0.5m, Pineapple = 0.5m },
             new BasicTopping { BasicTopppingID = 2, SizeID = "Medium", Cheese = 0.75m, Pepperoni = 0.75m, Ham = 0.75m, Pineapple = 0.75m },
             new BasicTopping { BasicTopppingID = 3, SizeID = "Large", Cheese = 1m, Pepperoni = 1m, Ham = 1m, Pineapple = 1m }

            );

            modelBuilder.Entity<DeluxeTopping>().HasData(
              new DeluxeTopping { DeluxeToppingID = 1, SizeID = "Small", Sausage = 2m, FetaCheese = 2m, Tomatoes = 2m, Olives = 2m },
              new DeluxeTopping { DeluxeToppingID = 2, SizeID = "Medium", Sausage = 3m, FetaCheese = 3m, Tomatoes = 3m, Olives = 3m },
              new DeluxeTopping { DeluxeToppingID = 3, SizeID = "Large", Sausage = 4m, FetaCheese = 4m, Tomatoes = 4m, Olives = 4m }
            );
        }

    }
}

