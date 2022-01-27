using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTestProject1.Tests
{
    public class BaseTest
    {
        public IWebDriver session;

        [SetUp]
        public virtual void SetUp()
        {
            session = new ChromeDriver();
            session.Manage().Window.Maximize();
            session.Url = "https://avenade.com/";
        }

        [TearDown]
        public void Close()
        {
            session.Quit();
        }
    }
}
