namespace Fina_DB_Test_Insert_From_Excel
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinaUsersDBContext : DbContext
    {
        public FinaUsersDBContext()
            : base("name=FinaUsersDBContext")
        {
        }

        public virtual DbSet<ADUser> ADUsers { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<KSC> KSCs { get; set; }
        public virtual DbSet<UserMasterData> UserMasterDatas { get; set; }

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
                .HasMany(e => e.ADUsers)
                .WithRequired(e => e.UserMasterData)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserMasterData>()
                .HasMany(e => e.KSCs)
                .WithRequired(e => e.UserMasterData)
                .HasForeignKey(e => e.UserID)
                .WillCascadeOnDelete(false);
        }
    }
}
