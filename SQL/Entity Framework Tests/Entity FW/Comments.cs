using System.Linq;

namespace Entity_FW
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comments
    {
        public int ID { get; set; }

        [Required]
        public string Text { get; set; }

        public int? AuthorID { get; set; }

        [StringLength(100)]
        public string AuthorName { get; set; }

        public int PostID { get; set; }

        public virtual Posts Posts { get; set; }

        public virtual Users Users { get; set; }
        public override string ToString()
        {
            return string.Format($"\n\tComment -> {Text}\n\tAuthor: {Users.FullName}");
        }
    }
}
