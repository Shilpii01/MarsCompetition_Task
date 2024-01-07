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

            LoginPage LoginPageObj = new LoginPage();
            HomePage HomePageObj = new HomePage();
            CertificationsTab CertificationsTabObj = new CertificationsTab();


            public static string certificatedata = File.ReadAllText(@"A:\Industry Connect\MarsCompetition_Task\Competition_Task\Competition_Task\TestData\Certifications.json");
            public static JArray certificationvalues = JArray.Parse(certificatedata);


            IList<Certification> certifications = certificationvalues.Select(p => new Certification
            {
                CertificateName = (string)p["CertificateName"],
                CertifiedFrom = (string)p["CertifiedFrom"],
                Year = (string)p["Year"]
            }).ToList();

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

                CertificationsTabObj.AddCertficateRecord(certifications[0].CertificateName, certifications[0].CertifiedFrom, certifications[0].Year);


                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[0].CertificateName + " has been added to your certification", "Certificate has not been added");


            }
            //

            [Test, Order(2), Description("Adding Multiple Certificate Record")]

            public void AddMultipleCertificateRecordswithValidData()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[0].CertificateName, certifications[0].CertifiedFrom, certifications[0].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[0].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(certifications[1].CertificateName, certifications[1].CertifiedFrom, certifications[1].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(certifications[2].CertificateName, certifications[2].CertifiedFrom, certifications[2].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[2].CertificateName + " has been added to your certification", "certificate has not been added");

            }

            [Test, Order(3), Description("Adding a Duplicate Certificate Record")]
            public void AddDuplicatecertificateRecord()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[0].CertificateName, certifications[0].CertifiedFrom, certifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[0].CertificateName + " has been added to your certification", "certificate has not been added");
                CertificationsTabObj.AddCertficateRecord(certifications[0].CertificateName, certifications[0].CertifiedFrom, certifications[0].Year);
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "This information is already exist.", "certificate has been added");



            }  //!@## has been updated to your certification

            [Test, Order(4), Description("Adding a new Certificate Record with Special Characters")]
            public void AddCertificateRecordWithSpecialCharacters()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[3].CertificateName, certifications[3].CertifiedFrom, certifications[3].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[3].CertificateName + " has been added to your certification", "certificate has not been added");

            }

            [Test, Order(5), Description("Adding a new Certificate Record with Destructive Data(100 Characters)")]
            public void AddCertificateRecordWithDestructiveData()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[4].CertificateName, certifications[4].CertifiedFrom, certifications[4].Year);
                //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[4].CertificateName + "  has been added to your certification", "certificate has not been added");
            }
            [Test, Order(6), Description("Adding a new Certificate Record with Null Certificate Name")]
            public void AddCertificateRecordWithNullCertficateName()
            {
                CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(null, certifications[0].CertifiedFrom, certifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }

            [Test, Order(7), Description("Adding a new Certificate Record with Null Certified From")]
            public void AddNewCertificateRecordWithNullCertfiedFrom()
            {
                CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(certifications[0].CertificateName, null, certifications[0].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }

            [Test, Order(8), Description("Adding a new Certificate Record with Null Year")]
            public void AddCertificationRecordWithNullYear()
            {
                CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(certifications[0].CertificateName, certifications[0].CertifiedFrom, null);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }



            [Test, Order(11), Description("Adding a new Certificate Record with all fields as Null ")]
            public void AddcertificateRecordWithNullValues()
            {
                CertificationsTabObj.AddNewCertificationRecordWithoutRequirdFeilds(null, null, null);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == "Please enter Certification Name, Certification From and Certification Year", "certificate has been added");
            }



            [Test, Order(12), Description("Editing an Existing Certificate Record with Updating Certificate Name")]
            public void EditCertficateRecordwithCertificateName()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[0].CertificateName, certifications[0].CertifiedFrom, certifications[0].Year);

                Thread.Sleep(2000);
                // Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");


                CertificationsTabObj.EditCertificateSingleField(certifications[2].CertificateName, "CertificateName");


                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[2].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(13), Description("Editing an Existing certificate Record with Updating Certified From")]
            public void EditcertificateRecordwithCountry()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[1].CertificateName, certifications[1].CertifiedFrom, certifications[1].Year);

                Thread.Sleep(2000);
                //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");


                CertificationsTabObj.EditCertificateSingleField(certifications[2].CertifiedFrom, "CertifiedFrom");

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(14), Description("Editing an Existing Certificate Record with Updating Year")]
            public void EditcertificateRecordwithYear()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[1].CertificateName, certifications[1].CertifiedFrom, certifications[1].Year);

                Thread.Sleep(2000);
                //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");


                CertificationsTabObj.EditCertificateSingleField(certifications[2].Year, "Year");

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been updated to your certification", "certificate has not been updated");
            }



            [Test, Order(17), Description("Editing an Existing Certificate Record with Updating All Fields")]
            public void EditCertificateRecord()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[1].CertificateName, certifications[1].CertifiedFrom, certifications[1].Year);

                Thread.Sleep(2000);
                //Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");

                CertificationsTabObj.EditCertificationRecord(certifications[2].CertificateName, certifications[2].CertifiedFrom, certifications[2].Year);

                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[2].CertificateName + " has been updated to your certification", "certificate has not been updated");

            }

            [Test, Order(18), Description("Deleting an Existing certificate Record")]
            public void DeleteExistingCertificateRecord()
            {
                CertificationsTabObj.AddCertficateRecord(certifications[1].CertificateName, certifications[1].CertifiedFrom, certifications[1].Year);
                Thread.Sleep(2000);
                // Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been added to your certification", "certificate has not been added");

                CertificationsTabObj.DeleteCertificationRecord();
                Thread.Sleep(2000);
                Assert.That(CertificationsTabObj.PopUpMsg.Text == certifications[1].CertificateName + " has been deleted from your certification", "Certificate entry has not removed");
                Assert.That(CertificationsTabObj.Rows.Count == 0, "Certificate record is still appeared");
            }
        
    }
}
