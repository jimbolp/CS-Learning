using System.ComponentModel;

namespace UserAccounts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KSC")]
    public partial class KSC
    {
        public int ID { get; set; }
        [DisplayName("Склад №")]
        public int BranchID { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Име Фамилия")]
        public string UserName { get; set; }
        [DisplayName("Потребител №")]
        public int UserID { get; set; }

        [Required]
        [StringLength(20)]
        public string TermID { get; set; }

        public int UID { get; set; }
        [DisplayName("FC права")]
        public bool AllowFC { get; set; }

        public virtual Branch Branch { get; set; }

        public virtual UserMasterData UserMasterData { get; set; }
    }
}
