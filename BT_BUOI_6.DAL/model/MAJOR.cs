namespace BT_BUOI_6.DAL.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MAJOR")]
    public partial class MAJOR
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MajorID { get; set; }
        public string MajorName { get; set; }
    }
}
