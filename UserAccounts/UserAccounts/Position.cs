namespace UserAccounts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Position
    {
        public int ID { get; set; }

        [Column("Position")]
        [Required]
        [StringLength(50)]
        public string Position1 { get; set; }
    }
}
