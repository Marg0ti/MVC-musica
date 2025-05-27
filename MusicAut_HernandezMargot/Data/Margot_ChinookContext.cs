using System;
using System.Collections.Generic;
using MusicAut_HernandezMargot.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MusicAut_HernandezMargot.Data;

public partial class Margot_ChinookContext : IdentityDbContext
{
    public Margot_ChinookContext()
    {
    }

    public Margot_ChinookContext(DbContextOptions<Margot_ChinookContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Album> Albums { get; set; }

    public virtual DbSet<Artist> Artists { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceLine> InvoiceLines { get; set; }

    public virtual DbSet<MediaType> MediaTypes { get; set; }

    public virtual DbSet<Playlist> Playlists { get; set; }

    public virtual DbSet<Track> Tracks { get; set; }
    public virtual DbSet<Review> Reviews { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Chiknook_db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding users
        List<IdentityRole> roles = new List<IdentityRole>
        {
            new IdentityRole 
            {
                Name = "Administrator", 
                NormalizedName = "ADMINISTRATOR" 
            },
            new IdentityRole 
            {
                Name = "User", 
                NormalizedName = "USER" 
            },
            new IdentityRole 
            {
                Name = "Platinum", 
                NormalizedName = "PLATINUM"
            }
        };
        modelBuilder.Entity<IdentityRole>().HasData(roles);

        List<IdentityUser> users = new List<IdentityUser>
        {
            new IdentityUser
            {
                UserName = "admin@chinook.com", 
                NormalizedUserName = "ADMIN@CHINOOK.COM", 
                Email = "admin@chinook.com", 
                NormalizedEmail = "ADMIN@CHINOOK.COM", 
                EmailConfirmed = true
           
            },
            new IdentityUser
            { 
                UserName = "user@chinook.com", 
                NormalizedUserName = "USER@CHINOOK.COM", 
                Email = "user@chinook.com",
                NormalizedEmail = "USER@CHINOOK.COM",
                EmailConfirmed = true
            },
            new IdentityUser
            { 
                UserName = "platinum@chinook.com", 
                NormalizedUserName = "PLATINUM@CHINOOK.COM", 
                Email = "platinum@chinook.com",
                NormalizedEmail = "PLATINUM@CHINOOK.COM",
                EmailConfirmed = true           
            }
        };
        modelBuilder.Entity<IdentityUser>().HasData(users);

        var passwordHasher = new PasswordHasher<IdentityUser>();
        users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Inma24.");
        users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Inma24.");
        users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Inma24.");


        //List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
        //{
        //    new IdentityUserRole<string> { UserId = users[0].Id, RoleId = roles[0].Id },
        //    new IdentityUserRole<string> { UserId = users[1].Id, RoleId = roles[1].Id },
        //    new IdentityUserRole<string> { UserId = users[2].Id, RoleId = roles[2].Id }
        //};

        //HasData no acepta colecciones, por lo que se pasan los datos uno a uno
        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { UserId = users[0].Id, RoleId = roles[0].Id },
            new IdentityUserRole<string> { UserId = users[1].Id, RoleId = roles[1].Id },
            new IdentityUserRole<string> { UserId = users[2].Id, RoleId = roles[2].Id }
            );

        //-------------------------------------------

        modelBuilder.Entity<IdentityUserRole<string>>()
            .HasOne<IdentityUser>()
            .WithMany()
            .HasForeignKey(userRole => userRole.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        

        base.OnModelCreating(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


}
