namespace BME.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int BlogId { get; set; }

        [StringLength(50)]
        public string BlogTitle { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BlogDate { get; set; }

        [StringLength(500)]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [StringLength(40)]
        public string UserName { get; set; }

        [StringLength(10)]
        public string Synced { get; set; }
    }
}
