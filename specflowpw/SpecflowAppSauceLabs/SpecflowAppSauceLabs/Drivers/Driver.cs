using Microsoft.Playwright;

namespace SpecflowAppSauceLabs.Drivers
{
    public class Driver : IDisposable
    {
        private readonly IPlaywright _playwright;
        private readonly IBrowser _browser;
        private readonly IPage _page;

        public Driver()
        {
            _playwright = Playwright.CreateAsync().GetAwaiter().GetResult();
            _browser = _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            }).GetAwaiter().GetResult();
            _page = _browser.NewPageAsync().GetAwaiter().GetResult();
        }

        public IPage Page => _page;

        public void Dispose()
        {
            _page.CloseAsync().GetAwaiter().GetResult();
            _browser.CloseAsync().GetAwaiter().GetResult();
            _playwright.Dispose();
        }
    }
}