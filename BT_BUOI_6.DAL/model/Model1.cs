using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BT_BUOI_6.DAL.model
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=StudentModel")
        {
        }

        public virtual DbSet<FACULTY> FACULTies { get; set; }
        public virtual DbSet<MAJOR> MAJORs { get; set; }
        public virtual DbSet<STUDENT> STUDENTs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FACULTY>()
                .Property(e => e.FacultyID)
                .IsFixedLength();

            modelBuilder.Entity<MAJOR>()
                .Property(e => e.MajorID)
                .IsFixedLength();

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.StudentID)
                .IsFixedLength();

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.FacultyID)
                .IsFixedLength();

            modelBuilder.Entity<STUDENT>()
                .Property(e => e.MajorID)
                .IsFixedLength();
        }
    }
}
