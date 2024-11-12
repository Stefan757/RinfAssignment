using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.ModelBuilderExtensions
{
    internal static class ArticleModelBuilder
    {
        internal static ModelBuilder BuildArticleModel(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Article>()
                .Property(x => x.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Article>()
                .Property(x => x.Author).HasMaxLength(100);

            modelBuilder.Entity<Article>()
                .Property(x => x.Title).HasMaxLength(100);

            modelBuilder.Entity<Article>()
                .HasIndex(x => new { x.Author, x.Title }).IsUnique();

            modelBuilder.Entity<Article>()
                .HasMany(x => x.Transactions)
                .WithMany(x => x.Articles)
                .UsingEntity<ArticleTransaction>();

            modelBuilder.Entity<Article>().HasData
                (
                    new Article { Id = 1, Author = "John Hersey", Title = "Hiroshima", Price = 45, Stock = 80},
                    new Article { Id = 2, Author = "Rachel Carson", Title = "Silent Spring", Price = (decimal)29.50, Stock = 120 },
                    new Article { Id = 3, Author = "Edward R. Murrow", Title = "This is London", Price = 63, Stock = 55 },
                    new Article { Id = 4, Author = "Ida Tarbell", Title = "The History of the Standard Oil Company", Price = (decimal)56.50, Stock = 79 },
                    new Article { Id = 5, Author = "Lincoln Steffens", Title = "The Shame of the Cities", Price = (decimal)35.50, Stock = 37 }
                );

            return modelBuilder;
        }
    }
}
