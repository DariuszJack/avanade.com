using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Tests;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class SearchJobOffer : BaseTest
    {
        private const string country_to_found_1 = "POLAND";
        private const string city_to_found_1 = "WARSAW";
        private const string city_to_found_2 = "KRAKOW";
        private const string multiple_location = "MULTIPLE";
        private const int number_of_city1_occurance = 1;
        private const int number_of_city2_occurance = 8;

        public override void SetUp()
        {
            session = new ChromeDriver();
            session.Manage().Window.Maximize();
            session.Url = "https://careers.avanade.com/jobsengb/SearchJobs/";
        }


        // There is at least 1 result for Location "Warsaw"
        // JIRA CES1111 >>link<<
        [Test, Category("Smoke Test")]
        public void SearchWarsawJob()
        {
            int counter = 0;

            SearchPage search_page = new SearchPage(session);
            search_page.SetCityToSearch(city_to_found_1);
            search_page.SearchResults();
            var jobsCardList = search_page.GetJobsCardList();

            foreach (IWebElement job in jobsCardList)
            {

                if ((job.Text.Contains(country_to_found_1) && job.Text.Contains(city_to_found_1)) || (job.Text.Contains(country_to_found_1) && job.Text.Contains(multiple_location)))
                {
                    counter++;
                }
            }
            Assert.GreaterOrEqual(counter, number_of_city1_occurance);
        }

        // There is a total of 8 results on the first results page for Location/Cities: "Krakow"
        // JIRA CES2222 >>link<<
        [Test, Category("Smoke Test")]
        public void SearchKrakowJob()
        {
            int counter = 0;

            SearchPage search_page = new SearchPage(session);
            search_page.SetCityToSearch(city_to_found_2);
            search_page.SearchResults();
            var jobsCardList = search_page.GetJobsCardList();

            foreach (IWebElement job in jobsCardList)
            {

                if ((job.Text.Contains(country_to_found_1) && job.Text.Contains(city_to_found_2)) || (job.Text.Contains(country_to_found_1) && job.Text.Contains(multiple_location)))
                {
                    counter++;
                }
            }
            Assert.GreaterOrEqual(counter, number_of_city2_occurance);
        }
    }
}
