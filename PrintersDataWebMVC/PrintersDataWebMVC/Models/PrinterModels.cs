namespace PrintersDataWebMVC.Models
{
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PrinterModels
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrinterModels()
        {
            PrinterMasterData = new HashSet<PrinterMasterData>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string PrinterModel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrinterMasterData> PrinterMasterData { get; set; }
    }
}
