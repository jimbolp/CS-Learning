namespace PrintersDataWebMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Branches
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Branches()
        {
            PrinterMasterData = new HashSet<PrinterMasterData>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string BranchName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrinterMasterData> PrinterMasterData { get; set; }
    }
}
