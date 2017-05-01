namespace UserAccountsMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Position
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Position()
        {
            UserMasterDatas = new HashSet<UserMasterData>();
        }

        public int ID { get; set; }

        [Column("Position")]
        [Required]
        [StringLength(50)]
        [DisplayName("Длъжност")]
        public string Position1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserMasterData> UserMasterDatas { get; set; }
    }
}
