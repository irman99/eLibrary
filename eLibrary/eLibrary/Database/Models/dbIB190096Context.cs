using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace eLibrary.Database.Models;

public partial class dbIB190096Context : DbContext
{
    public dbIB190096Context()
    {
    }

    public dbIB190096Context(DbContextOptions<dbIB190096Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Autor> Autors { get; set; }

    public virtual DbSet<FajloviKnjige> FajloviKnjiges { get; set; }

    public virtual DbSet<Kartica> Karticas { get; set; }

    public virtual DbSet<Knjiga> Knjigas { get; set; }

    public virtual DbSet<KnjigaKorisnik> KnjigaKorisniks { get; set; }

    public virtual DbSet<Komentari> Komentaris { get; set; }

    public virtual DbSet<Korisnik> Korisniks { get; set; }

    public virtual DbSet<KorisnikMedalja> KorisnikMedaljas { get; set; }

    public virtual DbSet<Medalja> Medaljas { get; set; }

    public virtual DbSet<Notifikacije> Notifikacijes { get; set; }

    public virtual DbSet<Ocjena> Ocjenas { get; set; }

    public virtual DbSet<TipKorisnika> TipKorisnikas { get; set; }

    public virtual DbSet<TipNotifikacije> TipNotifikacijes { get; set; }

    public virtual DbSet<Zanr> Zanrs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=IB190096;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE909FF3A2D32");

            entity.HasOne(d => d.IdKorisnikNavigation).WithOne(p => p.Autor).HasConstraintName("FK_Autor_Korisnik");
        });

        modelBuilder.Entity<FajloviKnjige>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__FajloviK__01E644E1C53A6723");

            entity.Property(e => e.SadrzajFilea).IsFixedLength();

            entity.HasOne(d => d.IdKnjigaNavigation).WithMany(p => p.FajloviKnjiges).HasConstraintName("FK_Fajlovi_Knjige");
        });

        modelBuilder.Entity<Kartica>(entity =>
        {
            entity.HasKey(e => e.KarticaId).HasName("PK__Kartica__8B34B3E9772AE18C");

            entity.Property(e => e.BrojKartice).IsFixedLength();

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Karticas).HasConstraintName("FK_Kartica_Korisnik");
        });

        modelBuilder.Entity<Knjiga>(entity =>
        {
            entity.HasOne(d => d.Autor).WithMany(p => p.Knjigas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Knjiga_Autor");

            entity.HasMany(d => d.Zanrs).WithMany(p => p.Knjigas)
                .UsingEntity<Dictionary<string, object>>(
                    "ZanroviKnjiga",
                    r => r.HasOne<Zanr>().WithMany()
                        .HasForeignKey("ZanrId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZK_Zanr"),
                    l => l.HasOne<Knjiga>().WithMany()
                        .HasForeignKey("KnjigaId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_ZK_Knjiga"),
                    j =>
                    {
                        j.HasKey("KnjigaId", "ZanrId").HasName("PK__ZanroviK__6341075C47E0A703");
                        j.ToTable("ZanroviKnjiga");
                        j.IndexerProperty<int>("KnjigaId").HasColumnName("KnjigaID");
                        j.IndexerProperty<int>("ZanrId").HasColumnName("ZanrID");
                    });
        });

        modelBuilder.Entity<KnjigaKorisnik>(entity =>
        {
            entity.HasKey(e => e.KnjigaKorisnikId).HasName("PK__KnjigaKo__20694ADD00A98B7C");

            entity.HasOne(d => d.Knjiga).WithMany(p => p.KnjigaKorisniks).HasConstraintName("FK_KK_Knjiga");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KnjigaKorisniks).HasConstraintName("FK_KK_Korisnik");
        });

        modelBuilder.Entity<Komentari>(entity =>
        {
            entity.HasKey(e => e.KomentarId).HasName("PK__Komentar__C0C304BCDCCCF195");

            entity.HasOne(d => d.Knjiga).WithMany(p => p.Komentaris).HasConstraintName("FK_Komentar_Knjiga");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Komentaris).HasConstraintName("FK_Komentar_Korisnik");
        });

        modelBuilder.Entity<Korisnik>(entity =>
        {
            entity.HasKey(e => e.IdKorisnik).HasName("PK__Korisnik__58FE570E47FC08DE");

            entity.HasOne(d => d.TipKorisnika).WithMany(p => p.Korisniks).HasConstraintName("FK_Korisnik_TipKorisnika");
        });

        modelBuilder.Entity<KorisnikMedalja>(entity =>
        {
            entity.HasKey(e => e.KorisnikMedaljaId).HasName("PK__Korisnik__14DBBC3D0204EBF6");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.KorisnikMedaljas).HasConstraintName("FK_KorisnikMedalja_Korisnik");

            entity.HasOne(d => d.Medalja).WithMany(p => p.KorisnikMedaljas).HasConstraintName("FK_KorisnikMedalja_Medalja");
        });

        modelBuilder.Entity<Medalja>(entity =>
        {
            entity.Property(e => e.MedaljaId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Notifikacije>(entity =>
        {
            entity.HasKey(e => e.NotifikacijaId).HasName("PK__Notifika__595D01C3706BE0DF");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Notifikacijes).HasConstraintName("FK_Notifikacije_Korisnik");

            entity.HasOne(d => d.TipNotifikacije).WithMany(p => p.Notifikacijes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Notifikacije_TipNotifikacije");
        });

        modelBuilder.Entity<Ocjena>(entity =>
        {
            entity.HasKey(e => e.OcjenaId).HasName("PK__Ocjena__E6FC7B49718B4227");

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Ocjenas).HasConstraintName("FK_Ocjena_Korisnik");
        });

        modelBuilder.Entity<TipKorisnika>(entity =>
        {
            entity.HasKey(e => e.IdTipKorisnika).HasName("PK__TipKoris__8AAF1E40BE47B039");

            entity.Property(e => e.IdTipKorisnika).ValueGeneratedNever();
        });

        modelBuilder.Entity<TipNotifikacije>(entity =>
        {
            entity.HasKey(e => e.TipNotifikacijeId).HasName("PK__TipNotif__A8350ACAF3315E83");
        });

        modelBuilder.Entity<Zanr>(entity =>
        {
            entity.HasKey(e => e.ZanrId).HasName("PK__Zanr__953868F360589D60");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
