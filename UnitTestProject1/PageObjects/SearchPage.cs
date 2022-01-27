using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace UnitTestProject1.PageObjects
{
    class SearchPage
    {
        readonly IWebDriver driver;
        private readonly int timeout = 3000; // 3sec
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "3_188_3-search__field")] //cities
        public IWebElement elem_cities_input;

        [FindsBy(How = How.Id, Using = "3_56_3")] //country
        public IWebElement elem_country_input;

        [FindsBy(How = How.Id, Using = "3_67_3")] //areas of expertise
        public IWebElement elem_area_input;

        [FindsBy(How = How.ClassName, Using = "searchBoxField")] //keywords
        public IWebElement elem_keywords_input;

        [FindsBy(How = How.ClassName, Using = "saveButton")] //search button
        public IWebElement elem_search_button;

        [FindsBy(How = How.ClassName, Using = "listSingleColumnItemTitle")] // job title
        public IList<IWebElement> elem_job_titles;

        [FindsBy(How = How.ClassName, Using = "listSingleColumnItemMiscDataItem")] // job card item
        public IList<IWebElement> elem_job_card;

        public void SetCityToSearch(string city_search)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_cities_input));

            elem_cities_input.SendKeys(city_search);
            Thread.Sleep(timeout); // wait for selected city load
            elem_cities_input.SendKeys(Keys.Enter);
        }

        public void SetCountryToSearch(string country_search)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_country_input));
            elem_country_input.FindElement(By.Id(country_search)).Click();
        }

        public void SetAreaOfExpertiseToSearch(string area_search)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_area_input));
            elem_area_input.FindElement(By.Id(area_search)).Click();
        }

        public void SetKeywordToSearch(string input_search)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_keywords_input));
            elem_keywords_input.SendKeys(input_search);

        }
        public JobDetailsPage SearchResults()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromMilliseconds(timeout));
            wait.Until(ExpectedConditions.ElementToBeClickable(elem_search_button));
            elem_search_button.Submit(); 

            return new JobDetailsPage(driver);
        }

        public IList<IWebElement> GetJobsTitleList()
        {    
            var jobsList = elem_job_titles.ToList();

            return jobsList;
        }

        public IList<IWebElement> GetJobsCardList()
        {
            var jobsList = elem_job_card.ToList();

            return jobsList;
        }
    }
}
