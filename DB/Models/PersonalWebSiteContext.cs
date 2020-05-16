using Microsoft.EntityFrameworkCore;

namespace DB.Models
{
    public partial class PersonalWebSiteContext : DbContext
    {
        public PersonalWebSiteContext()
        {
        }

        public PersonalWebSiteContext(DbContextOptions<PersonalWebSiteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Basarilar> Basarilar { get; set; }
        public virtual DbSet<Blog> Blog { get; set; }
        public virtual DbSet<Cv> Cv { get; set; }
        public virtual DbSet<Egitim> Egitim { get; set; }
        public virtual DbSet<Hesap> Hesap { get; set; }
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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=PersonalWebSite;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Basarilar>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Firma).HasMaxLength(255);

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

                entity.Property(e => e.Ozet).HasMaxLength(400);
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
                entity.Property(e => e.EgitimSeviyesi).HasMaxLength(50);

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.Bolum).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EgitimDili).HasMaxLength(255);

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Fakulte).HasMaxLength(255);

                entity.Property(e => e.MezuniyetDerecesi).HasMaxLength(50);

                entity.Property(e => e.OkulAdi).HasMaxLength(255);

                entity.HasOne(d => d.Ilce)
                    .WithMany(p => p.Egitim)
                    .HasForeignKey(d => d.IlceId)
                    .HasConstraintName("Egitim_Ilce_FK");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Egitim)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("Egitim_Sehir_FK");
            });

            modelBuilder.Entity<Hesap>(entity =>
            {
                entity.Property(e => e.KullaniciAdi).HasMaxLength(50);

                entity.Property(e => e.AdSoyad).HasMaxLength(50);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Hobiler>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

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
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.CalismakIstenilenSehir).HasMaxLength(255);

                entity.Property(e => e.CepTelefonu).HasMaxLength(255);

                entity.Property(e => e.Cinsiyet).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.DogumTarihi).HasColumnType("datetime");

                entity.Property(e => e.Ehliyet).HasMaxLength(255);

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .HasColumnName("EPosta")
                    .HasMaxLength(255);

                entity.Property(e => e.Faks).HasMaxLength(255);

                entity.Property(e => e.IsAramaDurumu).HasMaxLength(255);

                entity.Property(e => e.KanGrubu).HasMaxLength(255);

                entity.Property(e => e.MedeniDurum).HasMaxLength(255);

                entity.Property(e => e.Meslek).HasMaxLength(255);

                entity.Property(e => e.SabitTelefonu).HasMaxLength(255);

                entity.Property(e => e.Soyadi).HasMaxLength(255);

                entity.Property(e => e.AskerlikDurumu).HasMaxLength(50);

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

                entity.Property(e => e.Firma).HasMaxLength(255);

                entity.Property(e => e.Pozisyon).HasMaxLength(255);
            });

            modelBuilder.Entity<Projeler>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.BaslangicTarihi).HasColumnType("datetime");

                entity.Property(e => e.BitisTarihi).HasColumnType("datetime");

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KullanilanDiller).HasMaxLength(255);

                entity.Property(e => e.YapilisNedeni).HasMaxLength(255);
            });

            modelBuilder.Entity<Referanslar>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Eposta)
                    .HasColumnName("EPosta")
                    .HasMaxLength(255);

                entity.Property(e => e.Firma).HasMaxLength(255);

                entity.Property(e => e.Meslek).HasMaxLength(255);

                entity.Property(e => e.Pozisyon).HasMaxLength(255);

                entity.Property(e => e.Soyadi).HasMaxLength(255);

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
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.Brans).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.Firma).HasMaxLength(255);

                entity.Property(e => e.GecerlilikSuresi).HasColumnType("datetime");

                entity.Property(e => e.Tarih).HasColumnType("datetime");
            });

            modelBuilder.Entity<SosyalMedya>(entity =>
            {
                entity.Property(e => e.Adres).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.SosyalMedyaAdi).HasMaxLength(255);
            });

            modelBuilder.Entity<YabanciDil>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");

                entity.Property(e => e.KonusmaSeviyesi).HasMaxLength(255);

                entity.Property(e => e.OkumaSeviyesi).HasMaxLength(255);

                entity.Property(e => e.Seviyesi).HasMaxLength(255);

                entity.Property(e => e.YazmaSeviyesi).HasMaxLength(255);
            });

            modelBuilder.Entity<YetenekKategori>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(255);

                entity.Property(e => e.DegisimTarihi).HasColumnType("datetime");

                entity.Property(e => e.EklemeTarihi).HasColumnType("datetime");
            });

            modelBuilder.Entity<Yetenekler>(entity =>
            {
                entity.Property(e => e.Adi).HasMaxLength(100);

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