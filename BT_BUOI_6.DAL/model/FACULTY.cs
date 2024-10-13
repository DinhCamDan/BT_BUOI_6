namespace BT_BUOI_6.DAL.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FACULTY")]
    public partial class FACULTY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string FacultyID { get; set; }
        public string FacultyName { get; set; }
    }
}
