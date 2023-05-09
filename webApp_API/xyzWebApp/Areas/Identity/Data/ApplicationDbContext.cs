using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using xyzWebApp.Areas.Identity.Data;
using xyzWebApp.Models;

namespace xyzWebApp.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    // MAPIRANJE KLASA MODELA SA TABLICAMA BAZE PODATAKA
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        // SEEDING PRVIH PODATAKA (category, product, service)
        List<Category> categories = new List<Category>()
        {
            new Category { Id = 1, Title = "Massage's", Description="Massage's we offer."},
            new Category { Id = 2, Title = "Oil's", Description="Essential and aromatic oil's."},
            new Category { Id = 3, Title = "Soap's", Description="Bio all natural hand made soap's."},
            new Category { Id = 4, Title = "Body cream's", Description="All natural and skin healthy body cream's."},
            new Category { Id = 5, Title = "Shampoo's", Description="Bio friendly and skin healthy shampoo's"},
            new Category { Id = 6, Title = "Toothpaste's", Description="Natural ingeredient toothpaste's made by hand."}
        };

        builder.Entity<Category>().HasData(categories);

        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Title = "Massage oil", Sku = "MU0023", InStock = 54, Price = 39.99M, Image="mas_oil.jpg"},
            new Product { Id = 2, Title = "Lime essential oil", Sku = "EU0202", InStock = 46, Price = 47.99m, Image="lime_oil.jpg"},
            new Product { Id = 3, Title = "Bio soap", Sku = "MO1002", InStock = 191, Price = 14.99m, Image="bio_soap.jpg"},
            new Product { Id = 4, Title = "Natural lavander soap", Sku = "SP2220", InStock = 201, Price = 4.99m, Image="lav_soap.jpg"},
            new Product { Id = 5, Title = "White soap", Sku = "FC0099", InStock = 98, Price = 29.99m, Image="white_soap.jpg"},
            new Product { Id = 6, Title = "Body balm", Sku = "SH0001", InStock = 81, Price = 24.99m, Image="body_balm.jpg"},
            new Product { Id = 7, Title = "Body cream", Sku = "MS7770", InStock = 39, Price = 3.49m, Image="body_cream.jpg"},
            new Product { Id = 8, Title = "Bio toothpaste", Sku = "TT5770", InStock = 40, Price = 11.99m, Image="bio_tooth.jpg"},
            new Product { Id = 9, Title = "Bergamont essential oil", Sku = "OO0100", InStock = 60, Price = 24.99m, Image="bergam_oil.jpg"},
            new Product { Id = 10, Title = "All natural toothpast", Sku = "TT1111", InStock = 49, Price = 9.99m, Image="natural_tooth.jpg"},
            new Product { Id = 11, Title = "Hand made soap", Sku = "SS3343", InStock = 91, Price = 19.99m, Image="hm_soap.jpg"},
            new Product { Id = 12, Title = "CBD body balm", Sku = "CBD999", InStock = 71, Price = 31.99m, Image="cbd_balm.jpg"}
        };

        builder.Entity<Product>().HasData(products);

        List<Service> services = new List<Service>()
        {
            new Service { Id = 1, Title = "Reflexo therapy", Sku = "SM2902", Price = 29.99m, Image="reflexo.jpg"},
            new Service { Id = 2, Title = "Women full body massage", Sku = "MC2222", Price = 39.99m, Image="wome_mass.jpg"},
            new Service { Id = 3, Title = "Dry needle therapy", Sku = "MM0440", Price = 44.99m, Image="dry_needle.jpg"}
        };

        builder.Entity<Service>().HasData(services);

        List<ProductCategory> productCategories = new List<ProductCategory>()
        {
            new ProductCategory{ Id=1, CategoryId=2, ProductId=1},
            new ProductCategory{ Id=2, CategoryId=2, ProductId=2},
            new ProductCategory{ Id=3, CategoryId=2, ProductId=9},
            new ProductCategory{ Id=4, CategoryId=3, ProductId=3},
            new ProductCategory{ Id=5, CategoryId=3, ProductId=4},
            new ProductCategory{ Id=6, CategoryId=3, ProductId=5},
            new ProductCategory{ Id=7, CategoryId=3, ProductId=11},
            new ProductCategory{ Id=8, CategoryId=4, ProductId=6},
            new ProductCategory{ Id=9, CategoryId=4, ProductId=7},
            new ProductCategory{ Id=10, CategoryId=4, ProductId=12},
            new ProductCategory{ Id=11, CategoryId=6, ProductId=8},
            new ProductCategory{ Id=12, CategoryId=6, ProductId=10}
        };

        builder.Entity<ProductCategory>().HasData(productCategories);

        List<ServiceCategory> serviceCategories = new List<ServiceCategory>()
        {
            new ServiceCategory { Id=1, CategoryId=1, ServiceId=1},
            new ServiceCategory { Id=2, CategoryId=1, ServiceId=2},
            new ServiceCategory { Id=3, CategoryId=1, ServiceId=3}
        };

        builder.Entity<ServiceCategory>().HasData(serviceCategories);

        // SEEDING ULOGA (roles) I ADMINA
        // tablica AspNetRoles -> klasa IdentityRole
        string adminRoleId = "7a830b98-d453-441b-bf95-f97c7b79c81c";
        string adminRoleTitle = "Admin";

        string customerRoleId = "168d01bf-f3eb-49c5-8f52-35a05304c020";
        string customerRoleTitle = "Customer";

        builder.Entity<IdentityRole>().HasData(
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = adminRoleTitle,
                    NormalizedName = adminRoleTitle.ToUpper()
                },
                new IdentityRole()
                {
                    Id = customerRoleId,
                    Name = customerRoleTitle,
                    NormalizedName = customerRoleTitle.ToUpper(),
                }
            );

        // tablica AspNetUsers -> klasa ApplicationUser (izvorna "IdentityUser")
        string adminId = "7023ed45-9bf9-4fb8-a7e8-30378c89d14d";
        string admin = "admin@admin.com";
        string adminFirstName = "Master";
        string adminLastName = "Admin";
        string adminPassword = "asdasd";

        // hash lozinke
        var hasher = new PasswordHasher<ApplicationUser>();
        
        builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { 
                    Id = adminId, 
                    UserName = admin, 
                    NormalizedUserName = admin.ToUpper(),
                    Email = admin,
                    NormalizedEmail = admin.ToUpper(),
                    FirstName = adminFirstName,
                    LastName = adminLastName,
                    PasswordHash = hasher.HashPassword(null, adminPassword)
                }
            );


        // tablica AspNetUserRoles -> klasa IdentityUserRole<string> (veza izmedu Users i Roles)
        builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>()
                {
                    UserId = adminId,
                    RoleId = adminRoleId,
                }
            );
    }
}
