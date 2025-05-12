using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Service.Options;
using OpenQA.Selenium.Appium.Service;

namespace AppiumPractise.AppWebElements
{
    [TestFixture]
    public class AppInvoke
    {
        private AppiumLocalService _appiumService = null!;
        private AndroidDriver _androidDriver = null!;

        [SetUp]
        public void SetUp()
        {
            _appiumService = StartAppiumServer();
            _androidDriver = LaunchApp(_appiumService);
        }

        [TearDown]
        public void TearDown()
        {
            _androidDriver?.Dispose();
            _appiumService?.Dispose();
        }

        private AppiumLocalService StartAppiumServer(int? port = null)
        {
            var options = new OptionCollector();
            options.AddArguments(GeneralOptionList.NoPermsCheck());
            options.AddArguments(new KeyValuePair<string, string>("--allow-insecure", "adb_shell"));

            var builder = new AppiumServiceBuilder().WithArguments(options);
            var service = port.HasValue ? builder.UsingPort(port.Value).Build() : builder.UsingAnyFreePort().Build();
            service.Start();
            return service;
        }

        private AndroidDriver LaunchApp(AppiumLocalService service)
        {
            var appPath = @"C:\Users\vaman\Downloads\ApiDemos-debug (1).apk";  // Make sure this path is valid
            var caps = new AppiumOptions();
            caps.PlatformName = "Android";
            caps.DeviceName = "emulator-5554";
            caps.AutomationName = "UiAutomator2";
            caps.App = appPath;
            caps.AddAdditionalAppiumOption("newCommandTimeout", 300);
            caps.AddAdditionalAppiumOption("adbExecTimeout", 30000);
            caps.AddAdditionalAppiumOption("appPackage", "io.appium.android.apis");
            caps.AddAdditionalAppiumOption("appActivity", ".ApiDemos");

            return new AndroidDriver(service, caps);
        }

        [Test]
        public void AppInvoketest()
        {
            // Ensure the app has launched and the "Views" element is visible
            IWebElement View = _androidDriver.FindElement(By.XPath("//android.widget.TextView[@content-desc='Views']"));
            View.Click();
        }

    }
}
