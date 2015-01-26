using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLib
{
    public class EmployeeHelper
    {
        public Employee GetByEmployeeID(int empId)
        {
            NorthwindEntities db=new NorthwindEntities();
            var data = from item in db.Employees
                       where item.EmployeeID == empId
                       select item;
            return data.SingleOrDefault();
        }
    }
}
