using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UserManagment.Tests
{
    [TestClass]
    public class UserManagmentTests
    {
        public TestContext TestContext { set; get; }
        private UserManagment managment = new UserManagment();
        
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"TestData\correctUserData.xml",
            "User",
            DataAccessMethod.Sequential
            )]
        [TestMethod]
        public void Add_User_FromXML()
        {
            string id = Convert.ToString(TestContext.DataRow["id"]);
            string phone = Convert.ToString(TestContext.DataRow["phone"]);
            string email = Convert.ToString(TestContext.DataRow["email"]);

            bool result = managment.Add(id, phone, email);

            Assert.IsTrue(result, "Can't add this user");
        }

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML",
            @"TestData\failUserData.xml",
            "User",
            DataAccessMethod.Sequential)]
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void Fail_Add_User_FromXML()
        {
            string id = Convert.ToString(TestContext.DataRow["id"]);
            string phone = Convert.ToString(TestContext.DataRow["phone"]);
            string email = Convert.ToString(TestContext.DataRow["email"]);

            bool result = managment.Add(id, phone, email);
        }
    }
}
