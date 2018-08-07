namespace PrintersData
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PrintersDBContext : DbContext
    {
        public PrintersDBContext()
            : base("name=PrintersDB")
        {
        }

        public virtual DbSet<Branches> Branches { get; set; }
        public virtual DbSet<PrinterMasterData> PrinterMasterData { get; set; }
        public virtual DbSet<PrinterModels> PrinterModels { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branches>()
                .HasMany(e => e.PrinterMasterData)
                .WithRequired(e => e.Branches)
                .HasForeignKey(e => e.BranchID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PrinterMasterData>()
                .Property(e => e.PrinterName)
                .IsUnicode(false);

            modelBuilder.Entity<PrinterMasterData>()
                .Property(e => e.IPAddress)
                .IsUnicode(false);

            modelBuilder.Entity<PrinterMasterData>()
                .Property(e => e.PrintID)
                .IsUnicode(false);

            modelBuilder.Entity<PrinterMasterData>()
                .Property(e => e.DNSName)
                .IsUnicode(false);

            modelBuilder.Entity<PrinterModels>()
                .Property(e => e.PrinterModel)
                .IsUnicode(false);

            modelBuilder.Entity<PrinterModels>()
                .HasMany(e => e.PrinterMasterData)
                .WithOptional(e => e.PrinterModels)
                .HasForeignKey(e => e.PrinterModelID);
        }
    }
}
