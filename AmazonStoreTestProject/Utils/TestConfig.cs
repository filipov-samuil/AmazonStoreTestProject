namespace AmazonStoreTestProject.Utils
{
    public static class TestConfig
    {
        // Timeouts for waits, in seconds
        public static int TimeoutFiveSeconds { get; } = 5;
        public static int TimeoutTenSeconds { get; } = 10;

        // Base URL for Amazon website
        public static string BaseUrl { get; } = "https://www.amazon.com";
    }
}
