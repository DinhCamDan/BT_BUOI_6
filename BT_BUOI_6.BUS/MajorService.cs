using BT_BUOI_6.DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_BUOI_6.BUS
{
    public class MajorService
    {
        public List<MAJOR> GetAll()
        {
            Model1 context = new Model1();
            return context.MAJORs.ToList();
        }

        public List<MAJOR> GetAllByFaculty(string majorID) 
        {
            Model1 context = new Model1();
            return context.MAJORs.Where(p => p.MajorID == majorID).ToList();
        }
    }
}