using System;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Website_QuanlyCTDT.Models
{
    public partial class QuanLyCTDTContext : DbContext
    {
        public QuanLyCTDTContext()
        {
        }

        public QuanLyCTDTContext(DbContextOptions<QuanLyCTDTContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChuanDauRa> ChuanDauRas { get; set; }
        public virtual DbSet<Chuong> Chuongs { get; set; }
        public virtual DbSet<ChuyenNganh> ChuyenNganhs { get; set; }
        public virtual DbSet<KhoaHoc> KhoaHocs { get; set; }
        public virtual DbSet<MhtienQuyet> MhtienQuyets { get; set; }
        public virtual DbSet<MonHoc> MonHocs { get; set; }
        public virtual DbSet<MonKhoa> MonKhoas { get; set; }
        public virtual DbSet<MonNganh> MonNganhs { get; set; }
        public virtual DbSet<MucTieu> MucTieus { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<PhanCongLop> PhanCongLops { get; set; }
        public virtual DbSet<PhanCongNha> PhanCongNhas { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Tuan> Tuans { get; set; }
        public virtual DbSet<getMHByKhoa_Result> getMHByKhoa_Results { get; set; }
        public virtual DbSet<getMonhoc> getMonhocs { get; set; }
        public virtual DbSet<getMHhasTQ__Result> getMHhasTQ__Results { get; set; }
        public virtual DbSet<getMHTQ_Result> getMHTQ_Results { get; set; }
        public virtual DbSet<getMH_Result> getMH_Results { get; set; }

        public IQueryable<getMHByKhoa_Result> getMHByKhoa(int id, string nganh)
        {
            SqlParameter kh = new SqlParameter("@id", id);
            SqlParameter ng = new SqlParameter("@nganh", nganh);
            return this.getMHByKhoa_Results.FromSqlRaw("SELECT * FROM dbo.getMHByKhoa(@id,@nganh)", kh, ng);
        }
        public IQueryable<getMH_Result> checkMHByKhoa(int id, string mamh)
        {
            SqlParameter kh = new SqlParameter("@idk", id);
            SqlParameter mh = new SqlParameter("@mamh", mamh);
            return this.getMH_Results.FromSqlRaw("EXECUTE checkMHByKhoa  @idk, @mamh", kh, mh);
        }
        public IQueryable<getMH_Result> checkMHByNganh(string idn, string mamh)
        {
            SqlParameter ng = new SqlParameter("@idn", idn);
            SqlParameter mh = new SqlParameter("@mamh", mamh);
            return this.getMH_Results.FromSqlRaw("EXECUTE checkMHByNganh  @idn, @mamh", ng, mh);
        }
        public IQueryable<MucTieu> getMuctieuByMH(string maMh)
        {
            SqlParameter id = new SqlParameter("@maMh", maMh);

            return this.MucTieus.FromSqlRaw("EXECUTE getMuctieuByMH @maMh", id);
        }
        public IQueryable<getMHhasTQ__Result> getMHhasTQ()
        {


            return this.getMHhasTQ__Results.FromSqlRaw("EXECUTE getMHhasTQ");
        }
        public IQueryable<getMHTQ_Result> getMHTQ(string maMh)
        {
            SqlParameter id = new SqlParameter("@maMh", maMh);

            return this.getMHTQ_Results.FromSqlRaw("EXECUTE getMHTQ @maMh", id);
        }
        public IQueryable<Chuong> getChuongMH(string maMh)
        {
            SqlParameter id = new SqlParameter("@maMh", maMh);

            return this.Chuongs.FromSqlRaw("EXECUTE getChuongMH @maMh", id);
        }
        public IQueryable<PhanCongLop> getPhancongLop(int idc)
        {
            SqlParameter id = new SqlParameter("@id", idc);

            return this.PhanCongLops.FromSqlRaw("EXECUTE getPhancongLop @id", id);
        }
        public IQueryable<PhanCongNha> getPhancongNha(int idc)
        {
            SqlParameter id = new SqlParameter("@id", idc);

            return this.PhanCongNhas.FromSqlRaw("EXECUTE getPhancongNha @id", id);
        }
        public IQueryable<getMHByKhoa_Result> searchSubjects(int id, string idn, string ten)
        {
            SqlParameter k = new SqlParameter("@idKH", id);
            SqlParameter ng = new SqlParameter("@idn", idn);
            SqlParameter t = new SqlParameter("@ten", ten);

            return this.getMHByKhoa_Results.FromSqlRaw("EXECUTE searchSubjects @idKH, @idn, @ten", k,ng,t);
        }
        public IQueryable<MonHoc> searchSubject( string ten)
        {
           
            SqlParameter t = new SqlParameter("@ten", ten);

            return this.MonHocs.FromSqlRaw("EXECUTE searchSubject @ten", t);
        }
        public IQueryable<getMonhoc> getMonhoc()
        {

            return this.getMonhocs.FromSqlRaw("EXECUTE getMonhoc");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=QuanLyCTDT;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChuanDauRa>(entity =>
            {
                entity.ToTable("ChuanDauRa");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdMuctieu).HasColumnName("id_muctieu");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.Mota)
                    .HasMaxLength(500)
                    .HasColumnName("mota");

                entity.HasOne(d => d.IdMuctieuNavigation)
                    .WithMany(p => p.ChuanDauRas)
                    .HasForeignKey(d => d.IdMuctieu)
                    .HasConstraintName("FK__ChuanDauR__id_mu__656C112C");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.ChuanDauRas)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__ChuanDauRa__maMH__66603565");
            });

            modelBuilder.Entity<Chuong>(entity =>
            {
                entity.ToTable("Chuong");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdTuan).HasColumnName("id_tuan");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .HasColumnName("ten");

                entity.HasOne(d => d.IdTuanNavigation)
                    .WithMany(p => p.Chuongs)
                    .HasForeignKey(d => d.IdTuan)
                    .HasConstraintName("FK__Chuong__id_tuan__51300E55");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.Chuongs)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__Chuong__maMH__5224328E");
            });

            modelBuilder.Entity<ChuyenNganh>(entity =>
            {
                entity.ToTable("ChuyenNganh");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TenCn)
                    .HasMaxLength(50)
                    .HasColumnName("tenCN");
            });

            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.ToTable("KhoaHoc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(20)
                    .HasColumnName("tenKH");
            });

            modelBuilder.Entity<MhtienQuyet>(entity =>
            {
                entity.HasKey(e => new { e.MaMh, e.MaMhtq })
                    .HasName("PK__MHTienQu__222C976EA5510951");

                entity.ToTable("MHTienQuyet");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.MaMhtq)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMHTQ");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.MhtienQuyetMaMhNavigations)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MHTienQuye__maMH__619B8048");

                entity.HasOne(d => d.MaMhtqNavigation)
                    .WithMany(p => p.MhtienQuyetMaMhtqNavigations)
                    .HasForeignKey(d => d.MaMhtq)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MHTienQuy__maMHT__628FA481");
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.HasKey(e => e.MaMh)
                    .HasName("PK__MonHoc__7A3EDFA6145A7DF8");

                entity.ToTable("MonHoc");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.IdChuyennganh).HasColumnName("id_chuyennganh");

                entity.Property(e => e.Mota)
                    .HasMaxLength(1000)
                    .HasColumnName("mota");

                entity.Property(e => e.Sotinchi).HasColumnName("sotinchi");

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .HasColumnName("ten")
                    .UseCollation("SQL_Latin1_General_CP1_CI_AI");

                entity.HasOne(d => d.IdChuyennganhNavigation)
                    .WithMany(p => p.MonHocs)
                    .HasForeignKey(d => d.IdChuyennganh)
                    .HasConstraintName("FK__MonHoc__id_chuye__5165187F");
            });

            modelBuilder.Entity<MonKhoa>(entity =>
            {
                entity.HasKey(e => new { e.MaMh, e.IdKhoahoc })
                    .HasName("PK__MonKhoa__0DEEC3FB398E0FFF");

                entity.ToTable("MonKhoa");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.IdKhoahoc).HasColumnName("id_khoahoc");

                entity.HasOne(d => d.IdKhoahocNavigation)
                    .WithMany(p => p.MonKhoas)
                    .HasForeignKey(d => d.IdKhoahoc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonKhoa__id_khoa__5535A963");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.MonKhoas)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonKhoa__maMH__5441852A");
            });

            modelBuilder.Entity<MonNganh>(entity =>
            {
                entity.HasKey(e => new { e.Manganh, e.MaMh })
                    .HasName("PK__MonNganh__EBBB684CA4C9329A");

                entity.ToTable("MonNganh");

                entity.Property(e => e.Manganh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("manganh");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.MonNganhs)
                    .HasForeignKey(d => d.MaMh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonNganh__maMH__59063A47");

                entity.HasOne(d => d.ManganhNavigation)
                    .WithMany(p => p.MonNganhs)
                    .HasForeignKey(d => d.Manganh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MonNganh__mangan__5812160E");
            });

            modelBuilder.Entity<MucTieu>(entity =>
            {
                entity.ToTable("MucTieu");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaMh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("maMH");

                entity.Property(e => e.Mota)
                    .HasMaxLength(500)
                    .HasColumnName("mota");

                entity.HasOne(d => d.MaMhNavigation)
                    .WithMany(p => p.MucTieus)
                    .HasForeignKey(d => d.MaMh)
                    .HasConstraintName("FK__MucTieu__maMH__5BE2A6F2");
            });

            modelBuilder.Entity<Nganh>(entity =>
            {
                entity.HasKey(e => e.Manganh)
                    .HasName("PK__Nganh__9C1885B6EDF7645A");

                entity.ToTable("Nganh");

                entity.Property(e => e.Manganh)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("manganh");

                entity.Property(e => e.Tennganh)
                    .HasMaxLength(100)
                    .HasColumnName("tennganh");
            });

            modelBuilder.Entity<PhanCongLop>(entity =>
            {
                entity.ToTable("PhanCongLop");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdChuong).HasColumnName("id_chuong");

                entity.Property(e => e.Mota)
                    .HasMaxLength(100)
                    .HasColumnName("mota");

                entity.HasOne(d => d.IdChuongNavigation)
                    .WithMany(p => p.PhanCongLops)
                    .HasForeignKey(d => d.IdChuong)
                    .HasConstraintName("FK__PhanCongL__id_ch__55009F39");
            });

            modelBuilder.Entity<PhanCongNha>(entity =>
            {
                entity.ToTable("PhanCongNha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdChuong).HasColumnName("id_chuong");

                entity.Property(e => e.Mota)
                    .HasMaxLength(100)
                    .HasColumnName("mota");

                entity.HasOne(d => d.IdChuongNavigation)
                    .WithMany(p => p.PhanCongNhas)
                    .HasForeignKey(d => d.IdChuong)
                    .HasConstraintName("FK__PhanCongN__id_ch__57DD0BE4");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("matkhau");

                entity.Property(e => e.Ten)
                    .HasMaxLength(50)
                    .HasColumnName("ten");

                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Tuan>(entity =>
            {
                entity.ToTable("Tuan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Ten).HasColumnName("ten");
            });
            modelBuilder.Entity<getMHByKhoa_Result>().ToTable("getMHByKhoa_Result").HasNoKey();
            //        modelBuilder.HasDbFunction(typeof(QuanLyCTDTContext).GetMethod(nameof(getMHByKhoa), new[] { typeof(int)
            //}));
            modelBuilder.Entity<getMHhasTQ__Result>().ToTable("getMHhasTQ__Result").HasNoKey();
            modelBuilder.Entity<getMHTQ_Result>().ToTable("getMHTQ_Result").HasNoKey();
            modelBuilder.Entity<getMonhoc>().ToTable("getMonhoc").HasNoKey();
            modelBuilder.Entity<getMH_Result>().ToTable("getMH_Result").HasNoKey();
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
