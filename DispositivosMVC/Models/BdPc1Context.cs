using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DispositivosMVC.Models;

public partial class BdPc1Context : DbContext
{
    public BdPc1Context()
    {
    }

    public BdPc1Context(DbContextOptions<BdPc1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<DispositivoPc> DispositivoPcs { get; set; }

    public virtual DbSet<Fabricante> Fabricantes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=NINACODE\\SQLEXPRESS;Initial Catalog=bd_pc1;Integrated Security=True;TrustServerCertificate=True; User ID=sa;Password=1234;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCt).HasName("PK__Categori__00B7DEE71BA5354A");

            entity.Property(e => e.IdCt).HasColumnName("id_ct");
            entity.Property(e => e.DescripcionCt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_ct");
            entity.Property(e => e.EstadoCt).HasColumnName("estado_ct");
        });

        modelBuilder.Entity<DispositivoPc>(entity =>
        {
            entity.HasKey(e => e.IdDpc).HasName("PK__Disposit__D5EABA0F2CFFE046");

            entity.ToTable("Dispositivo_pc");

            entity.Property(e => e.IdDpc).HasColumnName("id_dpc");
            entity.Property(e => e.DescripcionDpc)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("descripcion_dpc");
            entity.Property(e => e.EstadoGarantiaDpc).HasColumnName("estado_garantia_dpc");
            entity.Property(e => e.IdCt).HasColumnName("id_ct");
            entity.Property(e => e.IdFb).HasColumnName("id_fb");
            entity.Property(e => e.PrecioDpc)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("precio_dpc");
            entity.Property(e => e.SerieDpc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("serie_dpc");

            entity.HasOne(d => d.IdCtNavigation).WithMany(p => p.DispositivoPcs)
                .HasForeignKey(d => d.IdCt)
                .HasConstraintName("FK__Dispositi__id_ct__3C69FB99");

            entity.HasOne(d => d.IdFbNavigation).WithMany(p => p.DispositivoPcs)
                .HasForeignKey(d => d.IdFb)
                .HasConstraintName("FK__Dispositi__id_fb__3B75D760");
        });

        modelBuilder.Entity<Fabricante>(entity =>
        {
            entity.HasKey(e => e.IdFb).HasName("PK__Fabrican__00B7F69BB4BC1158");

            entity.ToTable("Fabricante");

            entity.Property(e => e.IdFb).HasColumnName("id_fb");
            entity.Property(e => e.DescripcionFb)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion_fb");
            entity.Property(e => e.EstadoFb).HasColumnName("estado_fb");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
