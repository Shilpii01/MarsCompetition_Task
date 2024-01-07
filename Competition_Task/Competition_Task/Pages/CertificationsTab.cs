using Competition_Task.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Competition_Task.Pages
{
    public class CertificationsTab: BaseClass
    {

        public ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//div[@data-tab='fourth']//tbody"));
        private IWebElement CertificateNameTextbox => driver.FindElement(By.Name("certificationName"));
        private IWebElement AddNewButton => driver.FindElement(By.XPath("//thead/tr[1]/th[4]/div[1]"));
        private IWebElement CertifiedFromTextbox => driver.FindElement(By.Name("certificationFrom"));
        private IWebElement CertificationYearDropdown => driver.FindElement(By.Name("certificationYear"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@value=\"Add\"][@class=\"ui teal button \"]"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[4]/span[1]/i"));        
        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@value=\"Update\"]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        private IWebElement CancelButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[5]/div[1]/div[2]/div/div/div[3]/input[2]"));
 
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//tbody[last()]/tr[1]/td[4]/span[2]/i"));

        public void DeleteExistingCertficationRecords()
        {

            int records = Rows.Count();
            Console.WriteLine(records);
            //loop first delete icon
            for (int i = 0; i < records; i = i + 1)
            {

                DeleteButton.Click();
                Thread.Sleep(2000);
            }
        }

        public void AddCertficateRecord(string CertificateName, string CertifiedFrom, string Year)
        {

            AddNewButton.Click();
            CertificateNameTextbox.Click();
            CertificateNameTextbox.SendKeys(CertificateName);
            Thread.Sleep(1000);
            CertifiedFromTextbox.Click();
            CertifiedFromTextbox.SendKeys(CertifiedFrom);

            //create select element object 
            var selectElement = new SelectElement(CertificationYearDropdown);
            selectElement.SelectByValue(Year);

            AddButton.Click();
            Thread.Sleep(4000);
        }

        //Edit education
        public void EditCertificateSingleField(string Value, string Fields)
        {
            Thread.Sleep(1000);
            EditButton.Click();

            switch (Fields)
            {
                case "CertificateName":
                    CertificateNameTextbox.Clear();
                    CertificateNameTextbox.SendKeys(Value);
                    break;
                case "CertifiedFrom":
                    CertifiedFromTextbox.Clear();
                    CertifiedFromTextbox.SendKeys(Value);
                    break;
                case "Year":
                    var selectElement = new SelectElement(CertificationYearDropdown);
                    selectElement.SelectByValue(Value);
                    break;
            }
            Thread.Sleep(3000);
            UpdateButton.Click();
        }

        public void EditCertificationRecord(string UpdatedName, string UpdatedCertifiedFrom, string UpdatedYear)
        {
            Thread.Sleep(1000);
            EditButton.Click();
            CertificateNameTextbox.Clear();
            CertificateNameTextbox.SendKeys(UpdatedName);
            CertifiedFromTextbox.Clear();
            CertifiedFromTextbox.SendKeys(UpdatedCertifiedFrom);
            var selectElement = new SelectElement(CertificationYearDropdown);
            selectElement.SelectByValue(UpdatedYear);
            UpdateButton.Click();
        }


        public void DeleteCertificationRecord()
        {
            Thread.Sleep(3000);
            DeleteButton.Click();
        }

        public void AddNewCertificationRecordWithoutRequirdFeilds(string CertificateName,  string CertifiedFrom, string Year)
        {

            AddNewButton.Click();
            if (CertificateName != null)
            {
                CertificateNameTextbox.SendKeys(CertificateName);
            }
            if (CertifiedFrom != null)
            {
                CertifiedFromTextbox.SendKeys(CertifiedFrom);
            }

            //create select element object 
            var selectElement = new SelectElement(CertificationYearDropdown);
            if (Year != null)
            {
                selectElement.SelectByValue(Year);
            }
            AddButton.Click();
            Thread.Sleep(3000);
        }

    }
}
