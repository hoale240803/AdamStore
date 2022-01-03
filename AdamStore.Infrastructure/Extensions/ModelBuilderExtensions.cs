using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shared.Entities;
using Shared.Enums;
using System;

namespace AdamStore.Infrastructure.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
               new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
               new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
               new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
               );
            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Status.Active,
                },
                 new Category()
                 {
                     Id = 2,
                     IsShowOnHome = true,
                     ParentId = null,
                     SortOrder = 2,
                     Status = Status.Active
                 });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                  new CategoryTranslation() { Id = 1, CategoryId = 1, Name = "Áo nam", LanguageId = "vi", SeoAlias = "ao-nam", SeoDescription = "Sản phẩm áo thời trang nam", SeoTitle = "Sản phẩm áo thời trang nam" },
                  new CategoryTranslation() { Id = 2, CategoryId = 1, Name = "Men Shirt", LanguageId = "en", SeoAlias = "men-shirt", SeoDescription = "The shirt products for men", SeoTitle = "The shirt products for men" },
                  new CategoryTranslation() { Id = 3, CategoryId = 2, Name = "Áo nữ", LanguageId = "vi", SeoAlias = "ao-nu", SeoDescription = "Sản phẩm áo thời trang nữ", SeoTitle = "Sản phẩm áo thời trang women" },
                  new CategoryTranslation() { Id = 4, CategoryId = 2, Name = "Women Shirt", LanguageId = "en", SeoAlias = "women-shirt", SeoDescription = "The shirt products for women", SeoTitle = "The shirt products for women" }
                    );

            modelBuilder.Entity<Product>().HasData(
           new Product()
           {
               Id = 1,
               DateCreated = DateTime.Now,
               OriginalPrice = 100000,
               Price = 200000,
               Stock = 0,
               ViewCount = 0,
           });
            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Áo sơ mi nam trắng Việt Tiến",
                     LanguageId = "vi",
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Áo sơ mi nam trắng Việt Tiến",
                     SeoTitle = "Áo sơ mi nam trắng Việt Tiến",
                     Details = "Áo sơ mi nam trắng Việt Tiến",
                     Description = "Áo sơ mi nam trắng Việt Tiến"
                 },
                    new ProductTranslation()
                    {
                        Id = 2,
                        ProductId = 1,
                        Name = "Viet Tien Men T-Shirt",
                        LanguageId = "en",
                        SeoAlias = "viet-tien-men-t-shirt",
                        SeoDescription = "Viet Tien Men T-Shirt",
                        SeoTitle = "Viet Tien Men T-Shirt",
                        Details = "Viet Tien Men T-Shirt",
                        Description = "Viet Tien Men T-Shirt"
                    });
            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

            // add user roles (admin, manager, user, visitor)
            var roleId = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b");
            var adminId = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74b");
            var roleId1 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c");
            var adminId1 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74c");
            var roleId2 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d");
            var adminId2 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74d");
            var roleId3 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e");
            var adminId3 = new Guid("baac266d-dcb9-4500-8bd7-ce7a9c24c74e");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId1,
                Name = "manager",
                NormalizedName = "manager",
                Description = "Manager role"
            });
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId2,
                Name = "user",
                NormalizedName = "user",
                Description = "User role"
            });
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId3,
                Name = "visitor",
                NormalizedName = "visitor",
                Description = "Visitor role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "lehoa08121998@gmail.com",
                NormalizedEmail = "lehoa08121998@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "HoaL123!@#"),
                SecurityStamp = string.Empty,
                FirstName = "Hoa",
                LastName = "Le",
                Dob = new DateTime(2020, 01, 31)
            });
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId1,
                UserName = "manager",
                NormalizedUserName = "manager",
                Email = "hoamanager@yopmail.com",
                NormalizedEmail = "hoamanager@yopmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "HoaL123!@#"),
                SecurityStamp = string.Empty,
                FirstName = "Hoa Manager",
                LastName = "Le",
                Dob = new DateTime(2020, 01, 31)
            });
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId2,
                UserName = "user",
                NormalizedUserName = "user",
                Email = "hoauser@yopmail.com",
                NormalizedEmail = "hoauser@yopmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "HoaL123!@#"),
                SecurityStamp = string.Empty,
                FirstName = "Hoa User",
                LastName = "Le",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId3,
                UserName = "visitor",
                NormalizedUserName = "visitor",
                Email = "hoavisitor@yopmail.com",
                NormalizedEmail = "hoavisitor@yopmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "HoaL123!@#"),
                SecurityStamp = string.Empty,
                FirstName = "Hoa Visitor",
                LastName = "Le",
                Dob = new DateTime(2020, 01, 31)
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId1,
                UserId = adminId1
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId2,
                UserId = adminId2
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId3,
                UserId = adminId3
            });

            modelBuilder.Entity<Slide>().HasData(
              new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
              new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
              new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
              new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
              new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
              new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
              );
        }
    }
}