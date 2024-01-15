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



        LoginPage LoginPageObj;
        HomePage HomePageObj;
        EducationTab EducationTabObj;
        public EducationTests()
        {
            LoginPageObj = new LoginPage();
            HomePageObj = new HomePage();
            EducationTabObj = new EducationTab();


        }
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

            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");


            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
  
            }

            [Test, Order(2), Description("Adding Multiple Education Record")]

            public void AddMultipleEducationRecordswithValidData()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(Addeducations[1].UniversityName, Addeducations[1].Country, Addeducations[1].Title, Addeducations[1].YearOfGraduation, Addeducations[1].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(Addeducations[2].UniversityName, Addeducations[2].Country, Addeducations[2].Title, Addeducations[2].YearOfGraduation, Addeducations[2].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            }

            [Test, Order(3), Description("Adding a Duplicate Education Record")]
            public void AddDuplicateEducationRecord()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
                EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "This information is already exist.", "education has been added");

           


            }

            [Test, Order(4), Description("Adding a new Education Record with Special Characters")]
            public void AddanEducationRecordWithSpecialCharacters()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[3].UniversityName, Addeducations[3].Country, Addeducations[3].Title, Addeducations[3].YearOfGraduation, Addeducations[3].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              
            }

            [Test, Order(5), Description("Adding a new Education Record with Destructive Data(100 Characters)")]
            public void AddEducationRecordWithDestructiveData()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[4].UniversityName, Addeducations[4].Country, Addeducations[4].Title, Addeducations[4].YearOfGraduation, Addeducations[4].Degree);

            }
            [Test, Order(6), Description("Adding a new Education Record with Null University Data")]
            public void AddEducationRecordWithNullUniversity()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(null, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(7), Description("Adding a new Education Record with Null Country Data")]
            public void AddNewEducationRecordWithNullCountry()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(Addeducations[0].UniversityName, null, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(8), Description("Adding a new Education Record with Null Title Data")]
            public void AddEducationRecordWithNullTitle()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(Addeducations[0].UniversityName, Addeducations[0].Country, null, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(9), Description("Adding a new Education Record with Null Year Data")]
            public void AddEducationRecordWithNullYear()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, null, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(10), Description("Adding a new Education Record with Null Degree Data")]
            public void AddEducationRecordWithNullDegree()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, null);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            [Test, Order(11), Description("Adding a new Education Record with Null Data")]
            public void AddEducationRecordWithNullValues()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddNewEducationRecordWithoutRequirdFeilds(null, null, null, null, null);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Please enter all the fields", "education has been added");
            }

            

            [Test, Order(12), Description("Editing an Existing Education Record with Updating University")]
            public void EditEducationRecordwithUniversity()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            EducationTabObj.EditEducationSingleField(Updateeducations[1].UniversityName, "UniversityName");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
         
            }

            [Test, Order(13), Description("Editing an Existing Education Record with Updating Country")]
            public void EditEducationRecordwithCountry()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            EducationTabObj.EditEducationSingleField(Updateeducations[1].Country, "Country");

                Thread.Sleep(3000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
             
            }

            [Test, Order(14), Description("Editing an Existing Education Record with Updating Title")]
            public void EditEducationRecordwithTitle()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            EducationTabObj.EditEducationSingleField(Updateeducations[1].Title, "Title");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            }
            

            [Test, Order(15), Description("Editing an Existing Education Record with Updating Year")]
            public void EditEducationRecordwithYear()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");

            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            EducationTabObj.EditEducationSingleField(Updateeducations[1].YearOfGraduation, "YearOfGraduation");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
              
            }

            [Test, Order(16), Description("Editing an Existing Education Record with Updating Degree")]
            public void EditEducationRecordwithDegree()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            EducationTabObj.EditEducationSingleField(Updateeducations[1].Degree, "Degree");

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            }
             

            [Test, Order(17), Description("Editing an Existing Education Record with Updating All Fields")]
            public void EditEducationRecord()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

            List<Educations> Updateeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateEducations.json");
            Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
              

                EducationTabObj.EditEducationRecord(Updateeducations[1].UniversityName, Updateeducations[1].Country, Updateeducations[1].Title, Updateeducations[1].YearOfGraduation, Updateeducations[1].Degree);

                Thread.Sleep(3000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education as been updated", "education has not been updated");
            
            }

            [Test, Order(18), Description("Deleting an Existing Education Record")]
            public void DeleteExistingEducationRecord()
            {
            List<Educations> Addeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddEducations.json");
            EducationTabObj.AddEducation(Addeducations[0].UniversityName, Addeducations[0].Country, Addeducations[0].Title, Addeducations[0].YearOfGraduation, Addeducations[0].Degree);

                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education has been added", "education has not been added");
            List<Educations> Deleteeducations = Utilities.JsonReader.ReadTestDataFromJson<Educations>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\DeleteEducation.json");
            EducationTabObj.DeleteEducationRecord();
                Thread.Sleep(2000);
                Assert.That(EducationTabObj.PopUpMsg.Text == "Education entry successfully removed", "Education entry not removed");
                Assert.That(EducationTabObj.Rows.Count == 0, "Education record is still appeared");
            }

    }
}           
        
   

    


