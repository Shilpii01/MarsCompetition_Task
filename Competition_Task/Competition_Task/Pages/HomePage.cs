using Competition_Task.Utilities;
using OpenQA.Selenium;

namespace Competition_Task.Pages
{
    public class HomePage: BaseClass
    {
        private IWebElement EducationTab => driver.FindElement(By.XPath("//a[@data-tab=\"third\"]"));
        private IWebElement CertficationTab => driver.FindElement(By.XPath("//a[@data-tab=\"fourth\"]"));

        public void SelectEducationTab()
        {
            Thread.Sleep(4000);
            
            EducationTab.Click();

        }

        public void SelectCertficationTab()
        {
            Thread.Sleep(2000);

            CertficationTab.Click();
            Thread.Sleep(1000);
        }
    }
}
