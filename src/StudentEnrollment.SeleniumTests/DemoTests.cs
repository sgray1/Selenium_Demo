using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using StudentEnrollment.SeleniumTests.Pages;
using Assert = NUnit.Framework.Assert;

namespace StudentEnrollment.SeleniumTests
{
    [TestClass]
    public class DemoTests
    {
        private HomePage _homePage;
        private ChromeDriver _browserWindow;
        
        [TestMethod]
        public void CreateStudent()
        {
            //1. Open the browser
            _browserWindow = new ChromeDriver();
            _browserWindow.Navigate().GoToUrl("http://azurestudentenrollmentdemo.cloudapp.net/");
            _homePage = new HomePage(_browserWindow);

            //2.	Select Create Student on the nav bar
            CreateStudentPage createStudentPage = _homePage.ClickCreateStudent();

            //3.	Enter student details on the Create Student Page
            createStudentPage.FirstName.SendKeys("Steve");
            createStudentPage.LastName.SendKeys("Gray");
            createStudentPage.EnrolmentDate.SendKeys("01/01/2015");

            //4.	Click Create
            createStudentPage.ClickCreate();
            
            //5.	Assert the student is shown on the homepage 
            //A future post will deal with this not being a very good test
            Assert.That(_homePage.GetStudentRow(1).Text, Is.EqualTo("Gray Steve 1/1/2015 Edit | Details | Delete"));
        }

        //Run after each test
        [TestCleanup]
        public void TestCleanup()
        {

            //Close the browser
             _browserWindow.Quit();
        }
      
    }
}
