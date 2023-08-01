using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TallerCapacitacion.Models;

namespace TallerCapacitacion.Data;

public partial class TallerCapacitacionContext : DbContext
{
    public TallerCapacitacionContext(DbContextOptions<TallerCapacitacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Asistencia> Asistencias { get; set; }

    public virtual DbSet<Inscripcione> Inscripciones { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Tallere> Talleres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Asistencia>(entity =>
        {
            entity.HasKey(e => e.IdAsistencia).HasName("PRIMARY");

            entity.ToTable("asistencias");

            entity.HasIndex(e => e.IdInscripcion, "ID_Inscripcion");

            entity.Property(e => e.IdAsistencia).HasColumnName("ID_Asistencia");
            entity.Property(e => e.FechaAsistencia)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Asistencia");
            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");

            entity.HasOne(d => d.IdInscripcionNavigation).WithMany(p => p.Asistencia)
                .HasForeignKey(d => d.IdInscripcion)
                .HasConstraintName("asistencias_ibfk_1");
        });

        modelBuilder.Entity<Inscripcione>(entity =>
        {
            entity.HasKey(e => e.IdInscripcion).HasName("PRIMARY");

            entity.ToTable("inscripciones");

            entity.HasIndex(e => e.IdParticipante, "ID_Participante");

            entity.HasIndex(e => e.IdTaller, "ID_Taller");

            entity.Property(e => e.IdInscripcion).HasColumnName("ID_Inscripcion");
            entity.Property(e => e.FechaInscripcion)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_Inscripcion");
            entity.Property(e => e.IdParticipante).HasColumnName("ID_Participante");
            entity.Property(e => e.IdTaller).HasColumnName("ID_Taller");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("inscripciones_ibfk_1");

            entity.HasOne(d => d.IdTallerNavigation).WithMany(p => p.Inscripciones)
                .HasForeignKey(d => d.IdTaller)
                .HasConstraintName("inscripciones_ibfk_2");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PRIMARY");

            entity.ToTable("participantes");

            entity.Property(e => e.IdParticipante).HasColumnName("ID_Participante");
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Tallere>(entity =>
        {
            entity.HasKey(e => e.IdTaller).HasName("PRIMARY");

            entity.ToTable("talleres");

            entity.Property(e => e.IdTaller).HasColumnName("ID_Taller");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.FechaInicio).HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
