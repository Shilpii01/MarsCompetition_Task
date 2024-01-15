using Competition_Task.Pages;
using Competition_Task.TestData;
using Competition_Task.Utilities;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Competition_Task.Tests
{
    [TestFixture]
    
    public class CertificationsTests:BaseClass
    {

        LoginPage LoginPageObj;
        HomePage HomePageObj;
        CertificationsTab CertificationsTabObj;

        public CertificationsTests()
        {
            LoginPageObj = new LoginPage();
            HomePageObj = new HomePage();
            CertificationsTabObj = new CertificationsTab();

        }
        

            [SetUp]
        public void SetUpCertificateTest()
        {
            Initialize();

            LoginPageObj.LogInActions();
            Thread.Sleep(2000);
            driver.Navigate().Refresh();
            HomePageObj.SelectCertficationTab();
            CertificationsTabObj.DeleteExistingCertficationRecords();


        }

        [Test, Order(1), Description("Adding a new Certificate Record")]
            public void AddaNewCertificateRecordwithValidData()
            {

            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");


            CertificationsTabObj.AddCertficateRecord(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);


                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[0].CertificateName + " has been added to your certification", "Certificate has not been added");


            }
            //

            [Test, Order(2), Description("Adding Multiple Certificate Record")]

            public void AddMultipleCertificateRecordswithValidData()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[0].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(Addcertifications[1].CertificateName, Addcertifications[1].CertifiedFrom, Addcertifications[1].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[1].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(Addcertifications[2].CertificateName, Addcertifications[2].CertifiedFrom, Addcertifications[2].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[2].CertificateName + " has been added to your certification", "certificate has not been added");

            }

            [Test, Order(3), Description("Adding a Duplicate Certificate Record")]
            public void AddDuplicatecertificateRecord()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[0].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "This information is already exist.", "certificate has been added");



            }  //!@## has been updated to your certification

            [Test, Order(4), Description("Adding a new Certificate Record with Special Characters")]
            public void AddCertificateRecordWithSpecialCharacters()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[3].CertificateName, Addcertifications[3].CertifiedFrom, Addcertifications[3].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[3].CertificateName + " has been added to your certification", "certificate has not been added");

            }

            [Test, Order(5), Description("Adding a new Certificate Record with Destructive Data(100 Characters)")]
            public void AddCertificateRecordWithDestructiveData()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[4].CertificateName, Addcertifications[4].CertifiedFrom, Addcertifications[4].Year);
                //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[4].CertificateName + "  has been added to your certification", "certificate has not been added");
            }
            [Test, Order(6), Description("Adding a new Certificate Record with Null Certificate Name")]
            public void AddCertificateRecordWithNullCertficateName()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(null, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }

            [Test, Order(7), Description("Adding a new Certificate Record with Null Certified From")]
            public void AddNewCertificateRecordWithNullCertfiedFrom()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(Addcertifications[0].CertificateName, null, Addcertifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }

            [Test, Order(8), Description("Adding a new Certificate Record with Null Year")]
            public void AddCertificationRecordWithNullYear()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, null);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }



            [Test, Order(11), Description("Adding a new Certificate Record with all fields as Null ")]
            public void AddcertificateRecordWithNullValues()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(null, null, null);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }



            [Test, Order(12), Description("Editing an Existing Certificate Record with Updating Certificate Name")]
            public void EditCertficateRecordwithCertificateName()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");

            CertificationsTabObj.AddCertficateRecord(Addcertifications[0].CertificateName, Addcertifications[0].CertifiedFrom, Addcertifications[0].Year);

                Thread.Sleep(2000);
            // Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");

            List<Certification> Updatecertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateCertification.json");

            CertificationsTabObj.EditCertificateSingleField(Updatecertifications[2].CertificateName, "CertificateName");


                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Updatecertifications[2].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(13), Description("Editing an Existing certificate Record with Updating Certified From")]
            public void EditcertificateRecordwithCountry()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[1].CertificateName, Addcertifications[1].CertifiedFrom, Addcertifications[1].Year);

                Thread.Sleep(2000);
            //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");
            List<Certification> Updatecertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateCertification.json");

            CertificationsTabObj.EditCertificateSingleField(Updatecertifications[2].CertifiedFrom, "CertifiedFrom");

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[1].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(14), Description("Editing an Existing Certificate Record with Updating Year")]
            public void EditcertificateRecordwithYear()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[1].CertificateName, Addcertifications[1].CertifiedFrom, Addcertifications[1].Year);

                Thread.Sleep(2000);
            //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");

            List<Certification> Updatecertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateCertification.json");
            CertificationsTabObj.EditCertificateSingleField(Updatecertifications[2].Year, "Year");

                Thread.Sleep(3000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[1].CertificateName + " has been updated to your certification", "certificate has not been updated");
            }



            [Test, Order(17), Description("Editing an Existing Certificate Record with Updating All Fields")]
            public void EditCertificateRecord()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[1].CertificateName, Addcertifications[1].CertifiedFrom, Addcertifications[1].Year);

                Thread.Sleep(2000);
            //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");
            List<Certification> Updatecertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\UpdateCertification.json");
            CertificationsTabObj.EditCertificationRecord(Updatecertifications[2].CertificateName, Updatecertifications[2].CertifiedFrom, Updatecertifications[2].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Updatecertifications[2].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(18), Description("Deleting an Existing certificate Record")]
            public void DeleteExistingCertificateRecord()
            {
            List<Certification> Addcertifications = JsonReader.ReadTestDataFromJson<Certification>("A:\\Industry Connect\\MarsCompetition_Task\\Competition_Task\\Competition_Task\\TestData\\AddCertifications.json");
            CertificationsTabObj.AddCertficateRecord(Addcertifications[1].CertificateName, Addcertifications[1].CertifiedFrom, Addcertifications[1].Year);
                Thread.Sleep(2000);
                // Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");

                CertificationsTabObj.DeleteCertificationRecord();
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == Addcertifications[1].CertificateName + " has been deleted from your certification", "Certificate entry has not removed");
                Assert.That(CertificationsTabObj.Rows.Count == 0, "Certificate record is still appeared");
            }
        
    }
}
