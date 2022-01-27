using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace UnitTestProject1.PageObjects
{
    class HomePage
    {
        IWebDriver driver;
        private readonly int timeout = 3000; // 3sec
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.PartialLinkText, Using = "CAREERS")] //navigation bar element
        public IWebElement elem_navibar_careers;

        [FindsBy(How = How.PartialLinkText, Using = "Technologist")] //technologist jobs
        public IWebElement elem_navibar_technologist;

        public void SelectCareers()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_navibar_careers));
            
            Actions actions = new Actions(driver);
            actions.MoveToElement(elem_navibar_careers).Perform();
        }
        public TechnologistJobsPage SelectTechnologist()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_navibar_technologist));

            Actions actions = new Actions(driver);
            actions.MoveToElement(elem_navibar_technologist).Perform();
            elem_navibar_technologist.Click();

            return new TechnologistJobsPage(driver);
        }
    }
}
