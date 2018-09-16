using System;
using ClassRoomDB.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestClassRoomDB
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        [TestMethod]
        public static void GetSchoolIdTest()
        {
            List<School_row> Schools;
            SchoolTB schooltable = new SchoolTB();
            string _schoolName = "MSCreative";
            string _cityName = "HYD";
            Schools = schooltable.GetSchools(_schoolName, _cityName);
            foreach(School_row sc in Schools)
                System.Console.WriteLine(sc.School_name + sc.School_cityname);
        }

        public static int Main(String[] args)
        {
            GetSchoolIdTest();
            return 0;
        }
    }
}
