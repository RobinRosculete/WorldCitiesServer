using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WorldCitiesClass;

public partial class Com584dbContext : DbContext
{
    public Com584dbContext()
    {
    }

    public Com584dbContext(DbContextOptions<Com584dbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings2.json");
        IConfiguration configuration = builder.Build();
        //optionsBuilder.UseSqlServer(configuration.GetConnectionString("WorldCitiesContext"));
        optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"),
            Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.1.0-mysql"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CountryId, "FK_Cities_Countries");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.Latitude).HasPrecision(18, 4);
            entity.Property(e => e.Longitude).HasPrecision(18, 4);
            entity.Property(e => e.Name).HasMaxLength(45);

            entity.HasOne(d => d.Country).WithMany(p => p.Cities)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Cities_Countries");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Iso2)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.Name).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
