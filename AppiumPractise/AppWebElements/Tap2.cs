//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium.Appium.Android;
//using OpenQA.Selenium.Appium.Enums;
//using OpenQA.Selenium.Appium;
//using OpenQA.Selenium.Appium.Interactions;
//using OpenQA.Selenium.Interactions;
//using PointerInputDevice = OpenQA.Selenium.Appium.Interactions.PointerInputDevice;
//using OpenQA.Selenium;

//namespace AppiumPractise.AppWebElements
//{
//    public class Tap2
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
//        }

//        [Test]
//        public void taptest2()
//        {
//            var touch = new PointerInputDevice(PointerKind.Touch, "finger");
//            var action = new ActionSequence(touch, 0);
//            IWebElement element = driver.FindElement(By.XPath("//android.widget.TextView[@content-desc='Views']"));
//            action.AddAction(touch.CreatePointerMove(element, 0, 0, TimeSpan.Zero));
//            action.AddAction(touch.CreatePointerDown(MouseButton.Touch));
//            action.AddAction(touch.CreatePointerUp(MouseButton.Touch));


//        }
//    }
//}

