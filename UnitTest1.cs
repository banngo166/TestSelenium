using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ApiTestProject
{
    class UnitTest1
    {
        IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver("D:\\Visual Studio Code\\ApiTestProject\\chromedriver");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

        }

        [Test]
        public void TestIWebDriver()
        {
            driver.Url = "https://www.bbc.com/news";

            String Title = driver.Title;
            int TitleLength = driver.Title.Length;

            Console.WriteLine("Title of the page is : " + Title);
            Console.WriteLine("Length of the Title is : " + TitleLength);

            String PageURL = driver.Url;
            int URLLength = PageURL.Length;

            Console.WriteLine("URL of the page is : " + PageURL);
            Console.WriteLine("Length of the URL is : " + URLLength);

            String PageSource = driver.PageSource;
            int PageSourceLength = driver.PageSource.Length;

            Console.WriteLine("Page Source of the page is : " + PageSource);
            Console.WriteLine("Length of the Page Source is : " + PageSourceLength);

            driver.Quit();
        }

        [Test]
        public void BasicBrowser()
        {

            driver.Navigate().GoToUrl("https://www.bbc.com/news");

            driver.FindElement(By.CssSelector("nav[class='sc-df0290d6-9 akwuv'] li:nth-child(3) div:nth-child(1) a:nth-child(1)")).Click();

            driver.Navigate().Back();

            driver.Navigate().Refresh();

            driver.Navigate().Forward();

            driver.Quit();
        }

        [Test]
        public void TestCookies()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/news");

            var cookie1 = new Cookie("hoang", "dasw");
            driver.Manage().Cookies.AddCookie(cookie1);
            driver.Manage().Cookies.AddCookie(new Cookie("test1", "cookie1"));

            Console.WriteLine("Đã thêm Cookie");

            var cookies = driver.Manage().Cookies.AllCookies;

            Console.WriteLine("Xem Cookie của driver hiện tại:");
            foreach (var i in cookies)
            {
                Console.WriteLine($"\tName: {i.Name}, Value: {i.Value}");
            }

            Console.WriteLine($"Đã lấy ra {cookies.Count} Cookies");

            driver.Manage().Cookies.DeleteCookieNamed("hoang");

            var cookieDeleted = driver.Manage().Cookies.AllCookies;
            Console.WriteLine($"Số cookies còn lại sau khi xóa: {cookieDeleted.Count}");
            Console.WriteLine("Xem Cookies còn lại của driver:");
            foreach (var i in cookieDeleted)
            {
                Console.WriteLine($"\tName: {i.Name}, Value: {i.Value}");
            }

            driver.Quit();
        }

        [Test]
        public void TestFrames()
        {

            driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/nested_frames");

            driver.SwitchTo().ParentFrame();
            Console.WriteLine("Đã tới Frame Đầu tiên");

            driver.SwitchTo().Frame("frame-top");
            Console.WriteLine("Đã tới Frame Top");

            driver.SwitchTo().Frame("frame-middle");
            Console.WriteLine("Đã tới Frame Middle");
            string middleText = driver.FindElement(By.XPath("//div[@id='content']")).Text;
            Console.WriteLine(middleText);

            driver.Quit();
        }

        [Test]
        public void TestRegister()
        {
            driver.Navigate().GoToUrl("https://www.bbc.com/news");

            driver.FindElement(By.CssSelector("button[class='sc-ec3ac5c8-2 sc-ec3ac5c8-3 eRCykh fsjdUI'] span[class='sc-ec3ac5c8-1 bABdmH']")).Click();

            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("tsasfras@gmail.com"); //Mỗi lần chạy phải đổi tk

            driver.FindElement(By.Id("submit-button")).Click();

            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("Qaz@1233");

            driver.FindElement(By.Id("submit-button")).Click();

            driver.FindElement(By.Id("dateOfBirthDay")).Clear();
            driver.FindElement(By.Id("dateOfBirthDay")).SendKeys("3");

            driver.FindElement(By.Id("dateOfBirthMonth")).Clear();
            driver.FindElement(By.Id("dateOfBirthMonth")).SendKeys("3");

            driver.FindElement(By.Id("dateOfBirthYear")).Clear();
            driver.FindElement(By.Id("dateOfBirthYear")).SendKeys("2000");

            driver.FindElement(By.Id("submit-button")).Click();

            driver.Quit();
        }

        [Test]
        public void TestLogin()
        {

            driver.Navigate().GoToUrl("https://www.bbc.com/news");

            driver.FindElement(By.CssSelector("button[class='sc-ec3ac5c8-2 sc-ec3ac5c8-5 eRCykh jKWpcL']")).Click();

            driver.FindElement(By.Id("user-identifier-input")).Clear();
            driver.FindElement(By.Id("user-identifier-input")).SendKeys("tsasfras@gmail.com");

            driver.FindElement(By.Id("submit-button")).Click();

            driver.FindElement(By.Id("password-input")).Clear();
            driver.FindElement(By.Id("password-input")).SendKeys("Qaz@1233");

            driver.FindElement(By.Id("submit-button")).Click();

            driver.Quit();
        }

    }
}