namespace UserAccountsMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserDBContext : DbContext
    {
        public UserDBContext()
            : base("name=UserDBContext")
        {
        }

        public virtual DbSet<ADUser> ADUsers { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<KSC> KSCs { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        public virtual DbSet<UserMasterData> UserMasterDatas { get; set; }
        public virtual DbSet<AD_User_Group> AD_User_Groups { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>()
                .HasMany(e => e.KSCs)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Branch>()
                .HasMany(e => e.UserMasterDatas)
                .WithRequired(e => e.Branch)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KSC>()
                .Property(e => e.TermID)
                .IsUnicode(false);

            modelBuilder.Entity<UserMasterData>()
                .Property(e => e.PharmosUserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserMasterData>()
                .Property(e => e.UADMUserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserMasterData>()
                .HasMany(e => e.ADUsers)
                .WithRequired(e => e.UserMasterData)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMasterData>()
                .HasMany(e => e.KSCs)
                .WithRequired(e => e.UserMasterData)
                .HasForeignKey(e => e.UserID);

            modelBuilder.Entity<AD_User_Group>()
                .Property(e => e.GroupName)
                .IsUnicode(false);

            modelBuilder.Entity<AD_User_Group>()
                .Property(e => e.Type)
                .IsUnicode(false);
        }
    }
}
