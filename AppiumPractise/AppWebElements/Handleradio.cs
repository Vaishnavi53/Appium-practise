using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using NUnit.Framework.Internal;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Appium.Interactions;
using PointerInputDevice = OpenQA.Selenium.Appium.Interactions.PointerInputDevice;
using Microsoft.Build.Tasks;

namespace AppiumPractise.AppWebElements
{
    public class HandleButton
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
            driverOptions.AddAdditionalAppiumOption("Application", appPath);
            driverOptions.AddAdditionalAppiumOption("noReset", "true");
            driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

        }
        [OneTimeTearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
        [Test]
        public void handleradiotest()
        {
            IWebElement view = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Views\"]"));
            view.Click();

            //scroll using w3 actions
            //var touchaction = new PointerInputDevice(PointerKind.Touch, "finger");
            //var actionBuilder = new ActionBuilder();
            //actionBuilder.ClearSequences();

            //var scrollaction = new Interaction[]
            //{
            //    touchaction.CreatePointerMove(CoordinateOrigin.Viewport,300,1550,TimeSpan.Zero),
            //    touchaction.CreatePointerDown(MouseButton.Touch),
            //    touchaction.CreatePointerMove(CoordinateOrigin.Viewport,115,2130,TimeSpan.FromMicroseconds(800)),
            //    touchaction.CreatePointerUp(MouseButton.Touch)


            //};
            //actionBuilder.AddActions(scrollaction);
            //driver.PerformActions(actionBuilder.ToActionSequenceList());
            //this deos not work

            // Perform scroll using Appium's Mobile Command
            var scrollObject = new Dictionary<string, object>
            {
                { "strategy", "accessibility id" },
                { "selector", "Radio Group" },  // Replace with the actual target element's ID
                { "direction", "down" }
            };
            driver.ExecuteScript("mobile: scroll", scrollObject);


            IWebElement radiogrup = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Radio Group\"]"));
            radiogrup.Click();

            IWebElement clearbtn = driver.FindElement(By.XPath("//android.widget.Button[@content-desc=\"Clear\"]"));
            clearbtn.Click();

            IWebElement selectoption = driver.FindElement(By.XPath("//android.widget.RadioButton[@content-desc=\"All of them\"]"));
            selectoption.Click();

        }

    }
}
