using BT_BUOI_6.DAL.model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_BUOI_6.BUS
{
    public class StudentService
    {
        public List<STUDENT> GetAll()
        {
            Model1 context = new Model1();
            return context.STUDENTs.ToList();
        }

        public List<STUDENT> GetAllHasNoMajor()
        {
            Model1 context = new Model1();
            return context.STUDENTs.Where(p=>p.MajorID == null).ToList();
        }

        public List<STUDENT> GetAllHasNoMajor(string FacultyID)
        {
            Model1 context = new Model1();
            return context.STUDENTs.Where(p=> p.MajorID == null && p.FacultyID == FacultyID).ToList();
        }

        public STUDENT FindById (string StudentID)
        {
            Model1 context = new Model1 ();
            return context.STUDENTs.FirstOrDefault(p => p.StudentID == StudentID);
        }

        public void InserUpdate(STUDENT s)
        {
            Model1 context = new Model1();
            context.STUDENTs.AddOrUpdate(s);
            context.SaveChanges();
        }

        public void Delete(STUDENT s)
        { 
            Model1 context = new Model1();
            context.STUDENTs.Remove(s);
            context.SaveChanges();

        }

    }
}
