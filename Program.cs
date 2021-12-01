using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
// See https://aka.ms/new-console-template for more information
string? trackingCode = null;
if (Environment.GetCommandLineArgs().Length > 1)
    trackingCode = Environment.GetCommandLineArgs()[1];
else
{
    Console.WriteLine("press enter your traking number");
    trackingCode = Console.ReadLine();
}
if (!string.IsNullOrEmpty(trackingCode))
{
    Console.WriteLine($"Your entry tracking code is:{trackingCode}!");
    using (IWebDriver driver = new EdgeDriver())
    {
        driver.Navigate().GoToUrl("https://tracking.post.ir/");
        // 
        // a id= btnSearch
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        var searchBoxElememt = wait.Until(webDriver => webDriver.FindElement(By.XPath("//input[(@id='txtbSearch')]")));
        searchBoxElememt.SendKeys(trackingCode);
        var btn = wait.Until(webDriver => webDriver.FindElement(By.XPath("//a[(@id='btnSearch')]")));
        btn.Click();
        Console.WriteLine("press any key to exit");
        Console.ReadKey();
    }
}
else
{
    Console.WriteLine("there is no tracking number!!");
    Console.WriteLine("press any key to exit");
    Console.ReadKey();
}
