using Competition_Task.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace Competition_Task.Pages
{
    public class EducationTab:BaseClass
    {

        public ReadOnlyCollection<IWebElement> Rows => driver.FindElements(By.XPath("//div[@data-tab='third']//tbody"));
       
        public IWebElement AddNewButton => driver.FindElement(By.XPath("//thead/tr[1]/th[6]/div[1]"));
        private IWebElement CollegeNameTextbox => driver.FindElement(By.Name("instituteName"));
        private IWebElement CountryDropdown => driver.FindElement(By.Name("country"));
        private IWebElement TitleDropdown => driver.FindElement(By.Name("title"));
        private IWebElement DegreeTextbox => driver.FindElement(By.Name("degree"));
        private IWebElement GraduationYearDropdown => driver.FindElement(By.Name("yearOfGraduation"));
        private IWebElement AddButton => driver.FindElement(By.XPath("//input[@type=\"button\"][@value=\"Add\"]"));
        public IWebElement PopUpMsg => driver.FindElement(By.XPath("//DIV[@class='ns-box-inner']"));
        public IWebElement EditButton => driver.FindElement(By.XPath("//table[@class='ui fixed table']/tbody/tr/td[6]/span[1]/i"));
        public IWebElement UpdateButton => driver.FindElement(By.XPath("//input[@class='ui teal button'][@value='Update']"));
        public IWebElement CancelButton => driver.FindElement(By.XPath("//input[@type=\"button\"][@value=\"Cancel\"]"));           
        private IWebElement DeleteButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[2]/div/div/div/div[3]/form/div[4]/div/div[2]/div/table/tbody[last()]/tr/td[6]/span[2]/i "));


        public void DeleteExistingEducationRecords()
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

        public void AddEducation(string UniversityName, string Country, string Title, string Year, string Degree)
        {
           
            AddNewButton.Click();
            CollegeNameTextbox.SendKeys(UniversityName);

            //create select element object 
            var selectElement = new SelectElement(CountryDropdown);
            selectElement.SelectByValue(Country);

            selectElement = new SelectElement(TitleDropdown);
            selectElement.SelectByValue(Title);

            DegreeTextbox.SendKeys(Degree);

            selectElement = new SelectElement(GraduationYearDropdown);
            selectElement.SelectByValue(Year);

            AddButton.Click();
        }

        public void CancelAddingEducationRecord()
        {
            
            Thread.Sleep(3000);
            AddNewButton.Click();
            CancelButton.Click();
        }

        //Edit education
        public void EditEducationSingleField(string Value, string Fields)
        {
            Thread.Sleep(1000);
            EditButton.Click();

            switch (Fields)
            {
                case "UniversityName":
                    CollegeNameTextbox.Clear();
                    CollegeNameTextbox.SendKeys(Value);
                    break;
                case "Country":
                    var selectElement = new SelectElement(CountryDropdown);
                    selectElement.SelectByValue(Value);
                    break;
                case "Title":
                    selectElement = new SelectElement(TitleDropdown);
                    selectElement.SelectByValue(Value);
                    break;
                case "YearOfGraduation":
                    selectElement = new SelectElement(GraduationYearDropdown);
                    selectElement.SelectByValue(Value);
                    break;
                case "Degree":
                    DegreeTextbox.Clear();
                    DegreeTextbox.SendKeys(Value);
                    break;
            }
            UpdateButton.Click();
        }

        public void EditEducationRecord(string UpdatedName, string UpdatedCountry, string UpdatedTitle, string UpdatedYear, string UpdatedDegree)
        {
            Thread.Sleep(1000);
            EditButton.Click();
            CollegeNameTextbox.Clear();
            CollegeNameTextbox.SendKeys(UpdatedName);
            var selectElement = new SelectElement(CountryDropdown);
            selectElement.SelectByValue(UpdatedCountry);

            selectElement = new SelectElement(TitleDropdown);
            selectElement.SelectByValue(UpdatedTitle);

            selectElement = new SelectElement(GraduationYearDropdown);
            selectElement.SelectByValue(UpdatedYear);

            DegreeTextbox.Clear();
            DegreeTextbox.SendKeys(UpdatedDegree);
            UpdateButton.Click();
        }

        
        public void DeleteEducationRecord()
        {
            Thread.Sleep(3000);
            DeleteButton.Click();
        }

        public void AddNewEducationRecordWithoutRequirdFeilds(string UniversityName, string Country, string Title, string Year, string Degree)
        {
           
            AddNewButton.Click();
            if (UniversityName != null)
            {
                CollegeNameTextbox.SendKeys(UniversityName);
            }

            //create select element object 
            var selectElement = new SelectElement(CountryDropdown);
            if (Country != null)
            {
                selectElement.SelectByValue(Country);
            }

            selectElement = new SelectElement(TitleDropdown);
            if (Title != null)
            {
                selectElement.SelectByValue(Title);
            }

            if (Degree != null)
            {
                DegreeTextbox.SendKeys(Degree);
            }

            selectElement = new SelectElement(GraduationYearDropdown);
            if (Year != null)
            {
                selectElement.SelectByValue(Year);
            }
            AddButton.Click();
        }

       
    }
}



    

