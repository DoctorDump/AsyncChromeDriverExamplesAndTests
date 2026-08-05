using System.Threading;
using OpenQA.Selenium;
using Zu.SeleniumAdapter;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class WebDriverAdapter : WebDriverAdapterBase
    {
        protected Zu.Chrome.AsyncChromeDriver asyncChromeDriver;

        public WebDriverAdapter(CancellationToken ct)
            : this("", ct)
        {
        }
        public WebDriverAdapter(string profileName, CancellationToken ct)
        {
            asyncChromeDriver = string.IsNullOrWhiteSpace(profileName) ? new Zu.Chrome.AsyncChromeDriver() : new Zu.Chrome.AsyncChromeDriver(profileName);
            Create(asyncChromeDriver, ct);
        }

        public WebDriverAdapter(Zu.Chrome.AsyncChromeDriver asyncChromeDriver, CancellationToken ct)
        {
            this.asyncChromeDriver = asyncChromeDriver;
            Create(asyncChromeDriver, ct);
        }

        public WebDriverAdapter(Zu.Chrome.ChromeDriverConfig config, CancellationToken ct)
        {
            this.asyncChromeDriver = new Chrome.AsyncChromeDriver(config);
            Create(asyncChromeDriver, ct);
        }
        
        public WebDriverAdapter(DriverOptions options, CancellationToken ct)
        {
            var config = ConvertDriverOptionsToChromeDriverConfig(options);
            this.asyncChromeDriver = new Chrome.AsyncChromeDriver(config);
            Create(asyncChromeDriver, ct);
        }

        private Zu.Chrome.ChromeDriverConfig ConvertDriverOptionsToChromeDriverConfig(DriverOptions options)
        {
            var res = new Chrome.ChromeDriverConfig();
            //TODO Convert
            return res;
        }

        private void Create(Chrome.AsyncChromeDriver asyncChromeDriver, CancellationToken ct)
        {
            AsyncWebDriver = new Zu.AsyncWebDriver.Remote.WebDriver(asyncChromeDriver);
            SyncWebDriver = new Zu.AsyncWebDriver.Remote.SyncWebDriver(AsyncWebDriver);
            SyncWebDriver.Open(ct);
        }
    }
}
