//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium.Appium.Android;
//using OpenQA.Selenium.Appium.Enums;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium;
//using NUnit.Framework.Internal;
//using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
//using OpenQA.Selenium.Interactions;
//using OpenQA.Selenium.Appium.Interactions;
//using PointerInputDevice = OpenQA.Selenium.Appium.Interactions.PointerInputDevice;

//namespace AppiumPractise.AppWebElements
//{
//    public class HandleRadioButton
//    {
//        public AndroidDriver driver;

//        [OneTimeSetUp]
//        public void setup()
//        {
//            var appPath = "C:\\Users\\vaman\\Downloads\\ApiDemos-debug (1).apk";
//            var serverUri = new Uri(Environment.GetEnvironmentVariable("APPIUM_HOST") ?? "http://127.0.0.1:4723");
//            var driverOptions = new AppiumOptions()
//            {
//                AutomationName = AutomationName.AndroidUIAutomator2,
//                PlatformName = "Android",
//                DeviceName = "emulator-5554",

//            };

//            //Initializign appium server 
//            driverOptions.AddAdditionalAppiumOption("Application", appPath);
//            driverOptions.AddAdditionalAppiumOption("noReset", "true");
//            driver = new AndroidDriver(serverUri, driverOptions, TimeSpan.FromSeconds(180));

//        }
//        [OneTimeTearDown]
//        public void TearDown()
//        {
//            driver.Dispose();
//            driver.Quit();
//        }
//        [Test]
//        public void Handleradiotest()
//        {
//            ActionBuilder actionBuilder = new ActionBuilder();
//            var touch = new PointerInputDevice(PointerKind.Touch, "finger");

//            IWebElement View = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc=\"Views\"]"));
//            View.Click();

//            //Using UiScrollable (Best for Native Android Apps)
//            //var element = driver.FindElement(MobileBy.AndroidUIAutomator(
//            //"new UiScrollable(new UiSelector().scrollable(true)).scrollIntoView(new UiSelector().text(\"Radio Group\"));"
//            //));
//            //element.Click();


//            // Perform scrolling using W3C Actions API
//            //var actions = new W3CActions(driver);
//            //actions.PointerMove(0, 0, Origin.Viewport, 500, 1500) // Start position
//            //       .PointerDown(MouseButton.Left) // Press down
//            //       .Pause(TimeSpan.FromMilliseconds(500)) // Pause for effect
//            //       .PointerMove(0, 0, Origin.Viewport, 500, 500) // Move upwards (scroll)
//            //       .PointerUp(MouseButton.Left) // Release
//            //       .Perform(); //w3actions gives error
//            //       
//            // scroll to view the element

//            // scroll to webview

          
//            IList<AppiumElement> els = driver.FindElements(MobileBy.ClassName("android.widget.TextView"));
//            var origin = els[14];
//            //var loc1 = origin.Location;
//            var target = els[8];
//            //var loc2 = target.Location;

//            actionBuilder.ClearSequences(); 


//            touch.CreatePointerMove(origin, 0, 0, TimeSpan.FromMilliseconds(800));
//           touch.CreatePointerUp(MouseButton.Touch);
//            touch.CreatePause(TimeSpan.FromMilliseconds(800));
//            touch.CreatePointerMove(target, 0, 0, TimeSpan.FromMilliseconds(800));
//            touch.CreatePointerDown(MouseButton.Touch);

//            driver.PerformActions(actionBuilder.ToActionSequenceList());

//            //actionBuilder.AddAction(touch); // Add the touch action
//            //driver.PerformActions(actionBuilder.ToActionSequenceList()); // Execute the actions


//            Thread.Sleep(3000);

//            AppiumElement WebView = driver.FindElement(MobileBy.AccessibilityId("WebView"));

//            WebView.Click();

//            IWebElement dinner = driver.FindElement(By.XPath("//android.widget.RadioButton[@content-desc=\"Dinner\"]"));
//            dinner.Click();
          

//        }
//    }
//}
