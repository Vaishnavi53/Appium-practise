using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.DevTools.V85.WebAudio;

namespace AppiumPractise.AppWebElements
{
    [TestFixture]
    public class AppInvoke
    {
        public AndroidDriver driver;

        [OneTimeSetUp]
        public void setup()
        {
            var appPath = "C:\\Users\\vaman\\Downloads\\ApiDemos-debug (1).apk";
            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");
            var driverOptions = new AppiumOptions()
            {
                AutomationName = AutomationName.AndroidUIAutomator2,
                PlatformName = "Android",
                DeviceName = "emulator-5554",

            };
             driverOptions.AddAdditionalAppiumOption("avd", "medium_phone_api_35");
            //Initializign appium server 
            //desired capabilities
            driverOptions.AddAdditionalAppiumOption("Application", appPath);
            driverOptions.AddAdditionalAppiumOption("noReset", "true");
            driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
        [Test]
        public void AppInvoketest()
        {
            IWebElement View = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Views\"]"));
            View.Click();
        }
    }
}
