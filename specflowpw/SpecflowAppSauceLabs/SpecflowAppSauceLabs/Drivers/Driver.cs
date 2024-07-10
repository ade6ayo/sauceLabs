using System;
using Microsoft.Playwright;

namespace SpecflowAppSauceLabs.Drivers
{
    public class Driver
    {
        private readonly Task<IPage> _page;
        private IBrowser? _browser;

        public Driver()
        {
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;
        
        private async Task<IPage> InitializePlaywright()
        {
            using var playwright = await Playwright.CreateAsync();
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            return await _browser.NewPageAsync();
        }

        public void Dispose()
        {
            _browser.CloseAsync();
        }
        
    }
}