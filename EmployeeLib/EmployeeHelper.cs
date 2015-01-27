using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeLib
{
    public class EmployeeHelper
    {
        public Employee GetByEmployeeID(int empId)
        {
            var db = new List<Employee>();
            for (int i = 0; i <= 100; i++)
            {
                db.Add(new Employee() { EmployeeID = i, LastName = "LastName_" + i, Address = "Address_" + i, BirthDate = DateTime.Today, City = "City_" + i, Country = "Country_" + i, FirstName = "FirstName_" + i });
            };

            var data = from item in db
                       where item.EmployeeID == empId
                       select item;
            return data.FirstOrDefault();
        }
    }
}
