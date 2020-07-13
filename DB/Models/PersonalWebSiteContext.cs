using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DB.Models
{
    public partial class PersonalWebSiteContext : IdentityDbContext<ApplicationUser>
    {
        public PersonalWebSiteContext()
        {
        }

        public PersonalWebSiteContext(DbContextOptions<PersonalWebSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaim { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRole { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaim { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogin { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRole { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserToken { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUser { get; set; }
        public virtual DbSet<Basarilar> Basarilar { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Cv> Cv { get; set; }
        public virtual DbSet<Egitim> Egitim { get; set; }
        public virtual DbSet<Hobiler> Hobiler { get; set; }
        public virtual DbSet<Ilce> Ilce { get; set; }
        public virtual DbSet<Kisi> Kisi { get; set; }
        public virtual DbSet<MeslekiDeneyim> MeslekiDeneyim { get; set; }
        public virtual DbSet<Projeler> Projeler { get; set; }
        public virtual DbSet<Referanslar> Referanslar { get; set; }
        public virtual DbSet<Sehir> Sehir { get; set; }
        public virtual DbSet<Sertifikalar> Sertifikalar { get; set; }
        public virtual DbSet<SosyalMedya> SosyalMedya { get; set; }
        public virtual DbSet<YabanciDil> YabanciDil { get; set; }
        public virtual DbSet<YetenekKategori> YetenekKategori { get; set; }
        public virtual DbSet<Yetenekler> Yetenekler { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("PersonalWebSite");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.Property(e => e.NameSurname).HasMaxLength(256);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Basarilar>(entity =>
            {
                entity.Property(e => e.Aciklama).IsRequired();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Firma)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Tarih).HasMaxLength(255);
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.Property(e => e.Baslik)
                    .IsRequired()
                    .HasMaxLength(120);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.Detay).IsRequired();

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.GosterimBaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.GosterimBitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Ozet)
                    .IsRequired()
                    .HasMaxLength(400);
            });

            modelBuilder.Entity<Cv>(entity =>
            {
                entity.ToTable("CV");

                entity.Property(e => e.B64).IsRequired();

                entity.Property(e => e.CvAdi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Egitim>(entity =>
            {
                entity.HasIndex(e => e.IlceId);

                entity.HasIndex(e => e.SehirId);

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Bolum).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EgitimDili).HasMaxLength(255);

                entity.Property(e => e.EgitimSeviyesi)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Fakulte).HasMaxLength(255);

                entity.Property(e => e.MezuniyetDerecesi).HasMaxLength(50);

                entity.Property(e => e.OkulAdi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Ilce)
                    .WithMany(p => p.Egitim)
                    .HasForeignKey(d => d.IlceId)
                    .HasConstraintName("Egitim_Ilce_FK");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Egitim)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("Egitim_Sehir_FK");
            });

            modelBuilder.Entity<Hobiler>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ilce>(entity =>
            {
                entity.Property(e => e.IlceAdi)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kisi>(entity =>
            {
                entity.HasIndex(e => e.DogumIlceId);

                entity.HasIndex(e => e.DogumSehirId);

                entity.HasIndex(e => e.KonumIlceId);

                entity.HasIndex(e => e.KonumSehirId);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.AskerlikDurumu).HasMaxLength(50);

                entity.Property(e => e.CalismakIstenilenSehir).HasMaxLength(255);

                entity.Property(e => e.CepTelefonu)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Cinsiyet).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.Ehliyet).HasMaxLength(255);

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasColumnName("EPosta")
                    .HasMaxLength(255);

                entity.Property(e => e.Faks).HasMaxLength(255);

                entity.Property(e => e.IsAramaDurumu).HasMaxLength(255);

                entity.Property(e => e.KanGrubu).HasMaxLength(255);

                entity.Property(e => e.MedeniDurum).HasMaxLength(255);

                entity.Property(e => e.Meslek).HasMaxLength(255);

                entity.Property(e => e.SabitTelefonu).HasMaxLength(255);

                entity.Property(e => e.Soyadi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.TecilTarihi).HasColumnType("datetime");

                entity.Property(e => e.Telefon).HasMaxLength(255);

                entity.Property(e => e.UcretBeklentisi).HasMaxLength(255);

                entity.Property(e => e.Uyruk).HasMaxLength(255);

                entity.HasOne(d => d.DogumIlce)
                    .WithMany(p => p.KisiDogumIlce)
                    .HasForeignKey(d => d.DogumIlceId)
                    .HasConstraintName("Kisi_DogumIlce_Id");

                entity.HasOne(d => d.DogumSehir)
                    .WithMany(p => p.KisiDogumSehir)
                    .HasForeignKey(d => d.DogumSehirId)
                    .HasConstraintName("Kisi_DogumSehir_Id");

                entity.HasOne(d => d.KonumIlce)
                    .WithMany(p => p.KisiKonumIlce)
                    .HasForeignKey(d => d.KonumIlceId)
                    .HasConstraintName("Kisi_KonumIlce_Id");

                entity.HasOne(d => d.KonumSehir)
                    .WithMany(p => p.KisiKonumSehir)
                    .HasForeignKey(d => d.KonumSehirId)
                    .HasConstraintName("Kisi_KonumSehir_Id");
            });

            modelBuilder.Entity<MeslekiDeneyim>(entity =>
            {
                entity.Property(e => e.BaslangicTarih).HasColumnType("datetime");

                entity.Property(e => e.BitisTarih).HasColumnType("datetime");

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Firma)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Pozisyon)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Projeler>(entity =>
            {
                entity.Property(e => e.Aciklama).IsRequired();

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KullanilanDiller)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.YapilisNedeni).HasMaxLength(255);
            });

            modelBuilder.Entity<Referanslar>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .IsRequired()
                    .HasColumnName("EPosta")
                    .HasMaxLength(255);

                entity.Property(e => e.Firma).HasMaxLength(255);

                entity.Property(e => e.Meslek).HasMaxLength(255);

                entity.Property(e => e.Pozisyon).HasMaxLength(255);

                entity.Property(e => e.Soyadi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Telefon).HasMaxLength(255);
            });

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.Property(e => e.SehirAdi)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sertifikalar>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Brans)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Firma).HasMaxLength(255);

                entity.Property(e => e.GecerlilikSuresi).HasColumnType("datetime");

                entity.Property(e => e.Tarih).HasColumnType("datetime");
            });

            modelBuilder.Entity<SosyalMedya>(entity =>
            {
                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.SosyalMedyaAdi)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<YabanciDil>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KonusmaSeviyesi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.OkumaSeviyesi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Seviyesi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.YazmaSeviyesi)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<YetenekKategori>(entity =>
            {
                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Yetenekler>(entity =>
            {
                entity.HasIndex(e => e.KategoriId);

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.RenkKodu).HasMaxLength(7);

                entity.HasOne(d => d.Kategori)
                    .WithMany(p => p.Yetenekler)
                    .HasForeignKey(d => d.KategoriId)
                    .HasConstraintName("Yetenek_YetenekKategori_FK");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}