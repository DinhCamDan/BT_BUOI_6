namespace BT_BUOI_6.DAL.model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("STUDENT")]
    public partial class STUDENT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        public double DTB { get; set; }
        [StringLength(10)]
        public string FacultyID { get; set; }

        [StringLength(10)]
        public string MajorID { get; set; }

        [Column(TypeName = "image")]
        public byte[] Avata { get; set; }

        [ForeignKey("FacultyID")]
        public virtual FACULTY Faculty { get; set; }

        [ForeignKey("MajorID")]
        public virtual MAJOR Major { get; set; }
    }
}
