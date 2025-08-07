
using bookapi_minimal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bookapi_minimal.Configurations
{
    public class BookTypeConfigurations : IEntityTypeConfiguration<BookModel>
    {
        public void Configure(EntityTypeBuilder<BookModel> builder)
        {
            builder.ToTable("Books"); //table_name

            builder.HasKey(bk => bk.Id); //primary_key

            builder.Property(bk => bk.Id).ValueGeneratedOnAdd();
            builder.Property(bk => bk.Title).IsRequired().HasMaxLength(50);
            builder.Property(bk => bk.Author).IsRequired().HasMaxLength(50);
            builder.Property(bk => bk.Category).IsRequired().HasMaxLength(20);
            builder.Property(bk => bk.Description).IsRequired().HasMaxLength(100);
            builder.Property(bk => bk.Language).IsRequired().HasMaxLength(30);
            builder.Property(bk => bk.TotalPages).IsRequired();

            builder.HasData(
                  new BookModel
                  {
                      Id = Guid.NewGuid(),
                      Title = "The Alchemist",
                      Author = "Paulo Coelho",
                      Description = "The Alchemist follows the journey of an Andalusian shepherd",
                      Category = "Fiction",
                      Language = "English",
                      TotalPages = 208
                  },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "A novel about the serious issues of rape and racial inequality.",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 281
                }, new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    Description = "The Alchemist follows the journey of an Andalusian shepherd",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 208
                },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Description = "A novel about the serious issues of rape and racial inequality.",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 281
                },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 328
                },
                new BookModel
                {
                    Id = Guid.NewGuid(),
                    Title = "1984",
                    Author = "George Orwell",
                    Description = "A dystopian social science fiction novel and cautionary tale about the dangers of totalitarianism. ",
                    Category = "Fiction",
                    Language = "English",
                    TotalPages = 328
                }
            );
        }
    }
}