namespace UserAccounts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserMasterData")]
    public partial class UserMasterData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UserMasterData()
        {
            ADUsers = new HashSet<ADUser>();
            KSCs = new HashSet<KSC>();
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public int BranchID { get; set; }

        public int? PositionID { get; set; }

        [StringLength(50)]
        public string PharmosUserName { get; set; }

        [StringLength(50)]
        public string UADMUserName { get; set; }

        public bool? GI { get; set; }

        public bool? Purchase { get; set; }

        public bool? Tender { get; set; }

        public bool? Phibra { get; set; }

        public bool? Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADUser> ADUsers { get; set; }

        public virtual Branch Branch { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KSC> KSCs { get; set; }
    }
}
