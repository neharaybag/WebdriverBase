using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestUtilities;

namespace Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        private string _browser;
        private string _server;
        private string _baseUrl;
        protected string userName;
        protected string password;

        /// <summary>
        /// Setup
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            LoadConfigurationValues();
            GetDriver();
        }


        /// <summary>
        /// Tear Down
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }



        /// <summary>
        /// Load configuration values
        /// </summary>
        public void LoadConfigurationValues()
        {
            var configReader = new AppSettingsReader();
            _browser = (string)configReader.GetValue("browser", typeof(string));
            _server = (string)configReader.GetValue("remoteServer", typeof(string));
            _baseUrl = (string)configReader.GetValue("baseUrl", typeof(string));
            userName = (string)configReader.GetValue("username", typeof(string));
            password = (string)configReader.GetValue("password", typeof(string));

        }


        /// <summary>
        /// Initialize webdriver
        /// </summary>
        private void GetDriver()
        {
            Driver driver = new Driver();
            if(string.IsNullOrEmpty(_server))
            {
                Driver = driver.InitializeLocalDriver(_browser);
            }
            else
            {
                Driver = driver.InitializeRemoteDriver(_server, _server);
            }
        }


        /// <summary>
        /// Return current date time stamp
        /// </summary>
        /// <returns></returns>
        public string GetUniqueDateTimeStamp()
        {
            return $"{DateTime.Now:ddMMMyyHHmmss}";
        }
    }

}
