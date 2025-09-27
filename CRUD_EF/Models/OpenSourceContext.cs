using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUD_EF.Models;

public partial class OpenSourceContext : DbContext
{
    public OpenSourceContext()
    {
    }

    public OpenSourceContext(DbContextOptions<OpenSourceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarea__3214EC07B0FBFD3F");

            entity.ToTable("Tarea");

            entity.Property(e => e.Titulo).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
