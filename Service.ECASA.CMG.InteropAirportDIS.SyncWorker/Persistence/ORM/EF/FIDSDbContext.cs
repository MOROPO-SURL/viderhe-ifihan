using Microsoft.EntityFrameworkCore;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Persistence.Entities;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Persistence.ORM.EF;

public partial class FIDSDbContext : DbContext
{
    public FIDSDbContext(DbContextOptions<FIDSDbContext> options) : base(options)
    {
    }

    public virtual DbSet<Arraival> Arraivals { get; set; }

    public virtual DbSet<Departure> Departures { get; set; }

    public virtual DbSet<CheckIn> CheckIns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Arraival>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ArrivosInf");

            entity.Property(e => e.AD)
                .HasMaxLength(1)
                .IsFixedLength()
                .HasColumnName("A_D");
            entity.Property(e => e.Compania)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.DateTimeP).HasColumnType("datetime");
            entity.Property(e => e.DateTimeR).HasColumnType("datetime");
            entity.Property(e => e.Estado).HasDefaultValueSql("((6))");
            entity.Property(e => e.Idoper).HasColumnName("IDOper");
            entity.Property(e => e.KeyCol).ValueGeneratedOnAdd();
            entity.Property(e => e.NumeroVuelo)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.OrigDest)
                .HasMaxLength(21)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Orig_Dest");
            entity.Property(e => e.Puerta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.Terminal)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Vuelo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<Departure>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("SalidasInf");

            entity.Property(e => e.Compania)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.DateTimeP).HasColumnType("datetime");
            entity.Property(e => e.DateTimeR).HasColumnType("datetime");
            entity.Property(e => e.Estado).HasDefaultValueSql("((6))");
            entity.Property(e => e.Idoper).HasColumnName("IDOper");
            entity.Property(e => e.KeyCol).ValueGeneratedOnAdd();
            entity.Property(e => e.NumeroVuelo)
                .HasMaxLength(5)
                .IsFixedLength();
            entity.Property(e => e.OrigDest)
                .HasMaxLength(21)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Orig_Dest");
            entity.Property(e => e.Puerta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasDefaultValueSql("((0))")
                .IsFixedLength();
            entity.Property(e => e.Terminal)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Vuelo)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength();
        });

        modelBuilder.Entity<CheckIn>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Check_in");

            entity.Property(e => e.Abierto).HasColumnName("abierto");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaIni)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ini");
            entity.Property(e => e.Habilitado).HasColumnName("habilitado");
            entity.Property(e => e.IdMostrador).HasColumnName("id_mostrador");
            entity.Property(e => e.IdOper)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("id_Oper");
            entity.Property(e => e.Vip).HasColumnName("vip");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
