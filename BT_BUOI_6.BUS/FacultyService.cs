using BT_BUOI_6.DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_BUOI_6.BUS
{
    public class FacultyService
    {
        public List<FACULTY> GetAll()
        {
            Model1 context = new Model1();
            return context.FACULTies.ToList();
        }

    }
}