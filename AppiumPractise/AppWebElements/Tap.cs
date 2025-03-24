using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AppiumPractise.AppWebElements
{
    public class Tap
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

            //Initializign appium server 
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
        public void taptest()
        {
            ActionBuilder actionBuilder = new ActionBuilder();
            var touch = new PointerInputDevice(PointerKind.Touch, "finger");

            IWebElement View = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Views\"]"));
            View.Click();

            // scroll to view the element

            // scroll to webview

            IList<AppiumElement> els = driver.FindElements(MobileBy.ClassName("android.widget.TextView"));
            var origin = els[14];
            var loc1 = origin.Location;
            var target = els[8];
            var loc2 = target.Location;

            actionBuilder.ClearSequences();


            //Interaction[] interactions = new Interaction[]
            //{
            //touch.CreatePointerMove(origin, 0, 0, TimeSpan.FromMilliseconds(800)),
            //touch.CreatePointerUp(MouseButton.Touch),
            //touch.CreatePause(TimeSpan.FromMilliseconds(800)),
            //touch.CreatePointerMove(target, 0, 0, TimeSpan.FromMilliseconds(800)),
            //touch.CreatePointerDown(MouseButton.Touch)
            //};

            //actionBuilder.AddActions(interactions);

            var sequenceActions = actionBuilder.ToActionSequenceList();
            driver.PerformActions(sequenceActions);

            Thread.Sleep(3000);

            //AppiumElement WebView = driver.FindElement(MobileBy.AccessibilityId("WebView"));

            //WebView.Click();

        }
    }
}

