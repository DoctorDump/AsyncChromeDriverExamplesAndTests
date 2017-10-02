﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Interactions;
using System.Collections;
using Zu.SeleniumAdapter;

namespace Zu.AsyncFirefoxDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        private Zu.Firefox.AsyncFirefoxDriver asyncFirefoxDriver;

        public WebDriverAdapter()
            :this(null)
        {

        }

        public WebDriverAdapter(string profileName)
        {
            asyncFirefoxDriver = profileName == null ? new Zu.Firefox.AsyncFirefoxDriver() : new Zu.Firefox.AsyncFirefoxDriver(profileName);
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncFirefoxDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open();
            //syncWebDriver.Options().Timeouts.SetImplicitWait(TimeSpan.FromMilliseconds(500));
        }
    }
}
