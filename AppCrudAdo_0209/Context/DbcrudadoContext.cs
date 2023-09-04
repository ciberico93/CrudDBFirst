using System;
using System.Collections.Generic;
using AppCrudAdo_0209.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrudAdo_0209.Context;

public partial class DbcrudadoContext : DbContext
{
    public DbcrudadoContext()
    {
    }

    public DbcrudadoContext(DbContextOptions<DbcrudadoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contacto> Contactos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.IdContacto).HasName("PK__Contacto__A4D6BBFA085E1D05");

            entity.ToTable("Contacto");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
