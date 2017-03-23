namespace Entity_FW
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Comments = new HashSet<Comments>();
            Posts = new HashSet<Posts>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [MaxLength(64)]
        public byte[] Password { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }

        public override string ToString()
        {
            return string.Format(Environment.NewLine + ID + new string(' ', 5-ID.ToString().Length) + "| " + Username + 
                new string(' ', 15 - Username.Length) + "| " + FullName + new string(' ', 15 - FullName.Length));
        }
    }
}
