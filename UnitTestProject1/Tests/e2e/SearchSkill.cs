using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Text;
using UnitTestProject1.PageObjects;
using UnitTestProject1.Tests;
using Assert = NUnit.Framework.Assert;

namespace Tests
{
    [TestFixture]
    public class SearchSkill : BaseTest
    {
        private const string country_to_found_1 = "3_56_3_19893"; //poland
        private const string area_to_found_1 = "3_67_3_194784"; //software engineering
        private const string skill_to_found_1 = "Knowledge and understanding of quality assurance and testing processes";
        private const string job_title_to_found_1 = "QA Automation Test Engineer";


        // "One of the "Require Skills & Qualification" for job offer: "QA Automation Test Engineer"
        // in Country: "Poland", Area od expertise: "Software Engineering" is:
        // "Knowledge and understanding of quality assurance and testing processes"
        // JIRA CES3333 >>link<<
        [Test, Category("e2e")]
        public void SearchQualification()
        {
            int counter = 0;

            HomePage home_page = new HomePage(session);
            home_page.SelectCareers();
            home_page.SelectTechnologist();

            TechnologistJobsPage jobs_page = new TechnologistJobsPage(session);
            SearchPage search_page = jobs_page.SelectSearchJobs();
            search_page.SetCountryToSearch(country_to_found_1);
            search_page.SetAreaOfExpertiseToSearch(area_to_found_1);
            search_page.SetKeywordToSearch(skill_to_found_1);
            search_page.SearchResults();
            var jobsTitleList = search_page.GetJobsTitleList();

            if (jobsTitleList.Count == 0) throw new Exception("No jobs with criteria found!");

            foreach (IWebElement job in jobsTitleList)
            {
                if (job.Text.Contains(job_title_to_found_1))
                {
                    job.Click();
                    break;
                }
                else
                {
                    counter++;
                }
            }
            if (counter == jobsTitleList.Count) throw new Exception("No jobs with criteria found!");

            JobDetailsPage details_page = new JobDetailsPage(session);
            var rawSkillsList = details_page.GetRawSkillList();
            StringBuilder allSkillsInText = new StringBuilder();

            foreach (IWebElement skill in rawSkillsList)
            {
                allSkillsInText.Append(skill.Text);
            }

            var result = allSkillsInText.ToString();
            Assert.True(result.Contains(skill_to_found_1));
        }
    }
}
