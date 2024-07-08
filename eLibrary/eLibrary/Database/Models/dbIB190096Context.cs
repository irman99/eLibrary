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

    public virtual DbSet<Ocjene> Ocjenes { get; set; }

    public virtual DbSet<TipKorisnika> TipKorisnikas { get; set; }

    public virtual DbSet<TipNotifikacije> TipNotifikacijes { get; set; }

    public virtual DbSet<Zanr> Zanrs { get; set; }

    public virtual DbSet<ZanroviKnjiga> ZanroviKnjigas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=IB190096;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Latin1_General_CI_AS");

        modelBuilder.Entity<Autor>(entity =>
        {
            entity.HasKey(e => e.AutorId).HasName("PK__Autor__F58AE909C6B597BE");

            entity.Property(e => e.AutorId).ValueGeneratedNever();

            entity.HasOne(d => d.Korisnik).WithMany(p => p.Autors).HasConstraintName("FK__Autor__KorisnikI__2CF2ADDF");
        });

        modelBuilder.Entity<FajloviKnjige>(entity =>
        {
            entity.HasKey(e => e.IdFile).HasName("PK__FajloviK__01E644E18C3C6F9A");

            entity.HasOne(d => d.IdKnjigaNavigation).WithMany(p => p.FajloviKnjiges).HasConstraintName("FK_FajloviKnjige_Knjiga");
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

        modelBuilder.Entity<Ocjene>(entity =>
        {
            entity.HasKey(e => e.OcjenaId).HasName("PK__Ocjene__E6FC7B494960E30A");

            entity.HasOne(d => d.IdKnjigaNavigation).WithMany(p => p.Ocjenes).HasConstraintName("FK__Ocjene__IdKnjiga__25518C17");

            entity.HasOne(d => d.IdKorisnikNavigation).WithMany(p => p.OcjeneIdKorisnikNavigations).HasConstraintName("FK__Ocjene__IdKorisn__245D67DE");

            entity.HasOne(d => d.IdKorisnikPosiljalacNavigation).WithMany(p => p.OcjeneIdKorisnikPosiljalacNavigations)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Ocjene__IdKorisn__2645B050");
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

        modelBuilder.Entity<ZanroviKnjiga>(entity =>
        {
            entity.HasKey(e => e.ZanroviKnjigaId).HasName("PK__ZanroviK__1B7D23DBE4800B7D");

            entity.HasOne(d => d.Knjiga).WithMany(p => p.ZanroviKnjigas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ZanroviKn__Knjig__123EB7A3");

            entity.HasOne(d => d.Zanr).WithMany(p => p.ZanroviKnjigas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ZanroviKn__ZanrI__1332DBDC");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
