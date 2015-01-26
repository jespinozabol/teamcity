using System;
using NUnit.Framework;


namespace UnitTestsDemo
{
    [TestFixture]
    public class UnitTest1
    {
        [Test]
        public void TestGetEmployeeByID()
        {
            EmployeeLib.EmployeeHelper helper = new EmployeeLib.EmployeeHelper();
            EmployeeLib.Employee emp = helper.GetByEmployeeID(100);
            Assert.IsNotNull(emp);
        }
    }
}
