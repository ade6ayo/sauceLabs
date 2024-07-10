using TechTalk.SpecFlow;
using SpecflowAppSauceLabs.Drivers;

namespace SauceLabsAuto.Hooks
{
    [Binding]
    public class PlaywrightHooks
    {
        private readonly Driver _driver;

        public PlaywrightHooks(Driver driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Dispose();
        }
    }
}