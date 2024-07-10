using TechTalk.SpecFlow;
using Microsoft.Playwright;

namespace SauceLabsAuto.Hooks
{
    [Binding]
    public class PlaywrightHooks
    {
        private readonly Browser browser;
        private IPage page;

        public PlaywrightHooks(Browser browser)
        {
            this.browser = browser;
        }

        [BeforeScenario]
        public async Task BeforeScenario()
        {
            page = await browser.NewPageAsync();
        }

        [AfterScenario]
        public async Task AfterScenario()
        {
            if (page != null)
            {
                await page.CloseAsync();
            }
        }
    }
}