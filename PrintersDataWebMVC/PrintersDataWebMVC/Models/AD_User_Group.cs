namespace UserAccountsMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AD User Groups")]
    public partial class AD_User_Group
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(80)]
        public string GroupName { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
