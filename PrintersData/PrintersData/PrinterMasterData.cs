namespace PrintersData
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PrinterMasterData")]
    public partial class PrinterMasterData
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string PrinterName { get; set; }

        [StringLength(50)]
        public string IPAddress { get; set; }

        [StringLength(50)]
        public string PrintID { get; set; }

        public int? PrinterModeID { get; set; }

        public int BranchID { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public bool? Deleted { get; set; }

        [StringLength(100)]
        public string DNSName { get; set; }

        public virtual Branches Branches { get; set; }

        public virtual PrinterModels PrinterModels { get; set; }
    }
}
