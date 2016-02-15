namespace SpecDrill.Configuration
{
    public class Settings
    {
        public WebDriverConfiguration WebDriver { get; set; }

        public int MaxWait { get; set; }

        public int WaitPollingFrequency { get; set; }

        public Homepage[] Homepages { get; set; }
    }
}
