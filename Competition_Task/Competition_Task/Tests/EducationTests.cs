using Competition_Task.Pages;
using Competition_Task.TestData;
using Competition_Task.Utilities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Competition_Task.Tests
{
    [TestFixture]
    //[Parallelizable(ParallelScope.Fixtures)]
    public class EducationTests:BaseClass
    {
        
       
        
            LoginPage LoginPageObj = new LoginPage();
            HomePage HomePageObj = new HomePage();
            EducationTab EducationTabObj = new EducationTab();

           public static string json = File.ReadAllText(@"A:\Industry Connect\MarsCompetition_Task\Competition_Task\Competition_Task\TestData\Educations.json");     
           public static JArray educationsvalues = JArray.Parse(json);


            IList<Educations> educations = educationsvalues.Select(p => new Educations
            {
                UniversityName = (string)p["UniversityName"],
                Country = (string)p["Country"],
                Title = (string)p["Title"],
                Degree = (string)p["Degree"],
                YearOfGraduation = (string)p["YearOfGraduation"]
            }).ToList();

            [SetUp]
            public void SetUpEducationTest()
            {
                Initialize();
                
                LoginPageObj.LogInActions();
                Thread.Sleep(2000);
                driver.Navigate().Refresh();
                HomePageObj.SelectEducationTab();
                EducationTabObj.DeleteExistingEducationRecords();


            }

            [Test, Order(1), Description("Adding a new Education Record")]
            public void AddaNewEducationRecordwithValidData()
            {
                               
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
  
            }

            [Test, Order(2), Description("Adding Multiple Education Record")]

            public void AddMultipleEducationRecordswithValidData()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(educations[1].UniversityName, educations[1].Country, educations[1].Title, educations[1].YearOfGraduation, educations[1].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(educations[2].UniversityName, educations[2].Country, educations[2].Title, educations[2].YearOfGraduation, educations[2].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            }

            [Test, Order(3), Description("Adding a Duplicate Education Record")]
            public void AddDuplicateEducationRecord()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "This information is already exist.", "education has been added");

           


            }

            [Test, Order(4), Description("Adding a new Education Record with Special Characters")]
            public void AddanEducationRecordWithSpecialCharacters()
            {
                EducationTabObj.AddEducation(educations[3].UniversityName, educations[3].Country, educations[3].Title, educations[3].YearOfGraduation, educations[3].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              
            }

            [Test, Order(5), Description("Adding a new Education Record with Destructive Data(100 Characters)")]
            public void AddEducationRecordWithDestructiveData()
            {
                EducationTabObj.AddEducation(educations[4].UniversityName, educations[4].Country, educations[4].Title, educations[4].YearOfGraduation, educations[4].Degree);

            }
            [Test, Order(6), Description("Adding a new Education Record with Null University Data")]
            public void AddEducationRecordWithNullUniversity()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(null, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(7), Description("Adding a new Education Record with Null Country Data")]
            public void AddNewEducationRecordWithNullCountry()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].UniversityName, null, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(8), Description("Adding a new Education Record with Null Title Data")]
            public void AddEducationRecordWithNullTitle()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].UniversityName, educations[0].Country, null, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(9), Description("Adding a new Education Record with Null Year Data")]
            public void AddEducationRecordWithNullYear()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].UniversityName, educations[0].Country, educations[0].Title, null, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(10), Description("Adding a new Education Record with Null Degree Data")]
            public void AddEducationRecordWithNullDegree()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, null);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(11), Description("Adding a new Education Record with Null Data")]
            public void AddEducationRecordWithNullValues()
            {
                EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(null, null, null, null, null);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            

            [Test, Order(12), Description("Editing an Existing Education Record with Updating University")]
            public void EditEducationRecordwithUniversity()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
        

                EducationTabObj.EditEducationSingleField(educations[1].UniversityName, "UniversityName");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
         
            }

            [Test, Order(13), Description("Editing an Existing Education Record with Updating Country")]
            public void EditEducationRecordwithCountry()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              

                EducationTabObj.EditEducationSingleField(educations[1].Country, "CountryOfCollege");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
             
            }

            [Test, Order(14), Description("Editing an Existing Education Record with Updating Title")]
            public void EditEducationRecordwithTitle()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");


                EducationTabObj.EditEducationSingleField(educations[1].Title, "Title");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            }
            

            [Test, Order(15), Description("Editing an Existing Education Record with Updating Year")]
            public void EditEducationRecordwithYear()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            

                EducationTabObj.EditEducationSingleField(educations[1].YearOfGraduation, "YearOfGraduation");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
              
            }

            [Test, Order(16), Description("Editing an Existing Education Record with Updating Degree")]
            public void EditEducationRecordwithDegree()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

                EducationTabObj.EditEducationSingleField(educations[1].Degree, "Degree");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            }
             

            [Test, Order(17), Description("Editing an Existing Education Record with Updating All Fields")]
            public void EditEducationRecord()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              

                EducationTabObj.EditEducationRecord(educations[1].UniversityName, educations[1].Country, educations[1].Title, educations[1].YearOfGraduation, educations[1].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            
            }

            [Test, Order(18), Description("Deleting an Existing Education Record")]
            public void DeleteExistingEducationRecord()
            {
                EducationTabObj.AddEducation(educations[0].UniversityName, educations[0].Country, educations[0].Title, educations[0].YearOfGraduation, educations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              
                EducationTabObj.DeleteEducationRecord();
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education entry successfully removed", "Education entry not removed");
                Assert.That(EducationTabObj.Rows.Count == 0, "Education record is still appeared");
            }

    }
}           
        
   

    


