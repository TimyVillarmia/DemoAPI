using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoAPI.Models;

public partial class DemoContext : DbContext
{

    public DemoContext(DbContextOptions<DemoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pokemon> Pokemons { get; set; }

    public virtual DbSet<Type> Types { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pokemon>(entity =>
        {
            entity.HasKey(e => e.PokedexNumber).HasName("PK__Pokemon__4A08D9D8336D7DD7");

            entity.ToTable("Pokemon");

            entity.Property(e => e.PokedexNumber).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasMany(d => d.Types).WithMany(p => p.PokedexNumbers)
                .UsingEntity<Dictionary<string, object>>(
                    "PokemonType",
                    r => r.HasOne<Type>().WithMany()
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PokemonTy__TypeI__03BB8E22"),
                    l => l.HasOne<Pokemon>().WithMany()
                        .HasForeignKey("PokedexNumber")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PokemonTy__Poked__02C769E9"),
                    j =>
                    {
                        j.HasKey("PokedexNumber", "TypeId").HasName("PK__PokemonT__0F1E29E31562B0D2");
                        j.ToTable("PokemonTypes");
                    });
        });

        modelBuilder.Entity<Type>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PK__Types__516F03B5CBE25D03");

            entity.HasIndex(e => e.TypeName, "UQ__Types__D4E7DFA8C36B254C").IsUnique();

            entity.Property(e => e.TypeName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
