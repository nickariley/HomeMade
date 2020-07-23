using HomeMade.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeMade.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<User> Users { get; set; }

        // This method runs once when the DbContext is first used.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../HomeMade.Infrastructure/HomeMade.db");
        }

        // This method runs once when the DbContext is first used.
        // It's a place where we can customize how EF Core maps our
        // model to the database. 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId });

            // configure some seed data in the ingredient table
            modelBuilder.Entity<Ingredient>().HasData(

                new Ingredient
                {
                    Id = 1,
                    IngredientName = "Bread",
                    IngredientQuantity = 2,
                    IngredientUnit = "slices",
                    IngredientEdibleYieldPercentage = 100.00F
                },
                new Ingredient
                {
                    Id = 2,
                    IngredientName = "Peanut Butter",
                    IngredientQuantity = 2,
                    IngredientUnit = "ounces",
                    IngredientEdibleYieldPercentage = 100.00F
                },
                new Ingredient
                {
                    Id = 3,
                    IngredientName = "Banana",
                    IngredientQuantity = 2,
                    IngredientUnit = "ounces",
                    IngredientEdibleYieldPercentage = 66.67F
                }
                );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Nick"
                }
                );

            modelBuilder.Entity<Recipe>().HasData(
                new Recipe
                {
                    Id = 1,
                    RecipeName = "Peanut Butter Banana Sandwiches",
                    RecipeClassification = "Lunch",
                    UserId = 1
                }
                );
            modelBuilder.Entity<RecipeIngredient>().HasData(
                new RecipeIngredient
                {
                    IngredientId = 1,
                    RecipeId = 1
                },
                new RecipeIngredient
                {
                    IngredientId = 2,
                    RecipeId = 1
                },
                new RecipeIngredient
                {
                    IngredientId = 3,
                    RecipeId = 1
                }
                );
        }
    }
}
