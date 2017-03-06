namespace UserAccounts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ADUser
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        [StringLength(100)]
        public string ADName { get; set; }

        public virtual UserMasterData UserMasterData { get; set; }
    }
}
