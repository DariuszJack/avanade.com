using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1.PageObjects
{
    class JobDetailsPage
    {
        IWebDriver driver;
        private readonly int timeout = 3000; // 3sec
        public JobDetailsPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = ("//div[@class='MSWordContent']//span"))] // all skills on page
        public IList<IWebElement> elem_skill_list;

        public IList<IWebElement> GetRawSkillList()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")); // wait for page full load 
            var rawSkillsList = elem_skill_list.ToList();

            return rawSkillsList;
        }
    }
}
