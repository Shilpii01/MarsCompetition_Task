using Competition_Task.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Task.Pages
{
    public class LoginPage:BaseClass
    {
        private IWebElement SignInButton => driver.FindElement(By.XPath("//a[contains(text(),'Sign In')]"));
       
        private IWebElement emailAddress => driver.FindElement(By.XPath("//input[@placeholder='Email address']"));
        private IWebElement password => driver.FindElement(By.Name("password"));
        private IWebElement loginButton => driver.FindElement(By.XPath("//button[contains(text(),'Login')]"));

        public void SignInActions()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://localhost:5000/");
            Thread.Sleep(2000);
           

            SignInButton.Click();

        }
        public void LogInActions()
        {
            Thread.Sleep(3000);
            driver.Navigate().GoToUrl("http://localhost:5000/");
            Thread.Sleep(2000);
            SignInButton.Click();

            emailAddress.SendKeys("shilpicharu@gmail.com");

            password.SendKeys("qwerty");

            loginButton.Click();

            Thread.Sleep(3000);
        }
    }
}
