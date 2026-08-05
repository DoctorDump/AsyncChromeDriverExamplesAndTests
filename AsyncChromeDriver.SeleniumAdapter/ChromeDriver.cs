using System.Threading;
using OpenQA.Selenium;

namespace Zu.AsyncChromeDriver.SeleniumAdapter
{
    public class ChromeDriver: WebDriverAdapter
    {
        public ChromeDriver(CancellationToken ct)
            : this("", ct)
        {
        }
        public ChromeDriver(string profileName, CancellationToken ct)
            :base(profileName, ct)
        {
        }

        public ChromeDriver(Zu.Chrome.AsyncChromeDriver asyncChromeDriver, CancellationToken ct)
                : base(asyncChromeDriver, ct)
        {
        }

        public ChromeDriver(Zu.Chrome.ChromeDriverConfig config, CancellationToken ct)
                 : base(config, ct)
        {
        }

        public ChromeDriver(DriverOptions options, CancellationToken ct)
                  : base(options, ct)
        {
        }
    }
}
