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
    public DbSet<Order> Orders { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<ServiceCategory> ServiceCategories { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    

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
            new Category { Id = 1, Title = "Masaže"},
            new Category { Id = 2, Title = "Ulja"},
            new Category { Id = 3, Title = "Sapuni"},
            new Category { Id = 4, Title = "Kreme"},
            new Category { Id = 5, Title = "Šamponi"}
        };

        builder.Entity<Category>().HasData(categories);

        List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Title = "Ulje za masažu", Sku = "MU0023", InStock = 54, Price = 39.99M},
            new Product { Id = 2, Title = "Eterično ulje", Sku = "EU0202", InStock = 46, Price = 47.99m},
            new Product { Id = 3, Title = "Miris za ormar na bazi sapuna", Sku = "MO1002", InStock = 191, Price = 14.99m},
            new Product { Id = 4, Title = "Prirodni sapun", Sku = "SP2220", InStock = 201, Price = 4.99m},
            new Product { Id = 5, Title = "Krema za lice", Sku = "FC0099", InStock = 98, Price = 29.99m},
            new Product { Id = 6, Title = "Krema za suhu kožu", Sku = "SH0001", InStock = 81, Price = 24.99m},
            new Product { Id = 7, Title = "Muški gel za tuširanje na bazi vetivera", Sku = "MS7770", InStock = 39, Price = 3.49m}
        };

        builder.Entity<Product>().HasData(products);

        List<Service> services = new List<Service>()
        {
            new Service { Id = 1, Title = "Muška sportska masaža", Sku = "SM2902", Price = 29.99m},
            new Service { Id = 2, Title = "Ženska masaža cijelog tijela", Sku = "MC2222", Price = 39.99m},
            new Service { Id = 3, Title = "Maderoterapija", Sku = "MM0440", Price = 44.99m}
        };

        builder.Entity<Service>().HasData(services);

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
        string adminAddress = "Slijepa ulica 8";
        //string adminUserName = "master_admin";                     // dodan userName za admina, ali smeta u Login-u...

        // hash lozinke
        var hasher = new PasswordHasher<ApplicationUser>();
        
        builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser() { 
                    Id = adminId, 
                    UserName = admin, 
                    NormalizedUserName = admin.ToUpper(),
                    Email = admin,
                    NormalizedEmail = admin.ToUpper(),
                    Address = adminAddress,
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
