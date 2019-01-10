using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUtilities
{
    public class Driver
    {
        private IWebDriver _webDriver;

        /// <summary>
        /// Return remote webdriver
        /// </summary>
        /// <param name="remoteServer"></param>
        /// <param name="browser"></param>
        /// <returns></returns>
        public IWebDriver InitializeRemoteDriver(string remoteServer, string browser)
        {
          
                ICapabilities options = null;
                switch (browser.ToLower())
                {
                    case "chrome":
                        var firefoxOptions = new FirefoxOptions();
                        options = firefoxOptions.ToCapabilities();
                        break;

                    case "firefox":
                        var chromeOptions = new ChromeOptions();
                        options = chromeOptions.ToCapabilities();
                        break;
                }

                _webDriver = new RemoteWebDriver(new Uri(remoteServer), options);
                var allowsDetection = (IAllowsFileDetection)_webDriver;
                allowsDetection.FileDetector = new LocalFileDetector();          

                return _webDriver;
        }


        /// <summary>
        /// Return local driver
        /// </summary>
        /// <param name="browser"></param>
        /// <returns></returns>
        public IWebDriver InitializeLocalDriver(string browser)
        {
            switch (browser.ToLower())
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");
                    _webDriver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    var firefoxOptions = new FirefoxOptions();
                    _webDriver = new FirefoxDriver(firefoxOptions);
                    break;
            }
            return _webDriver;
        }
    }
}
