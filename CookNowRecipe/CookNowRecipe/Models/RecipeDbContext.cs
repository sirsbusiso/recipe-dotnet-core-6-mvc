using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CookNowRecipe.Models;

public partial class RecipeDbContext : DbContext
{
    public RecipeDbContext()
    {
    }

    public RecipeDbContext(DbContextOptions<RecipeDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbRecipe> TbRecipes { get; set; }

    public virtual DbSet<TbRecipeImage> TbRecipeImages { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbUser> TbUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

        var connectionString = configuration.GetConnectionString("ConnString");
        optionsBuilder.UseSqlServer(connectionString);
    }
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Server=LAPTOP-OI7RBJ0Q\\SQLEXPRESS;Database=RecipeDB;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbRecipe>(entity =>
        {
            entity.HasKey(e => e.RecId).HasName("PK__tb_Recip__360414DF45A1FEC9");

            entity.ToTable("tb_Recipe");

            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Ingredient).IsUnicode(false);
            entity.Property(e => e.Instructions).HasColumnType("xml");
            entity.Property(e => e.RecipeName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.TbRecipes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tb_Recipe__UserI__3C69FB99");
        });

        modelBuilder.Entity<TbRecipeImage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__tb_Recip__7516F70C66DDFDFC");

            entity.ToTable("tb_Recipe_Image");

            entity.Property(e => e.FileName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FilePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FileType)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Rec).WithMany(p => p.TbRecipeImages)
                .HasForeignKey(d => d.RecId)
                .HasConstraintName("FK__tb_Recipe__RecId__3F466844");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__tb_Role__8AFACE1A3F8FF988");

            entity.ToTable("tb_Role");

            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tb_User__1788CC4CE72BEBE0");

            entity.ToTable("tb_User");

            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Role).WithMany(p => p.TbUsers)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__tb_User__RoleId__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
