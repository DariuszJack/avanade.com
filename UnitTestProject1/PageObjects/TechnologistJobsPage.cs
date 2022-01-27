using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;

namespace UnitTestProject1.PageObjects
{
    class TechnologistJobsPage
    {
        IWebDriver driver;
        private readonly int timeout = 10000;
        public TechnologistJobsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.ClassName, Using = "career-tech-btn-search-jobs")] //search jobs button
        public IWebElement elem_search_button;

        public SearchPage SelectSearchJobs()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_search_button));
            elem_search_button.Click();

            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")); // wait for page full load  

            return new SearchPage(driver);
        }

    }
}
