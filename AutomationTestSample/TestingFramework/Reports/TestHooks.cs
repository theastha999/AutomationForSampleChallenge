

namespace AutomationTestSample.TestingFramework.Reports
{
    public class TestHooks : IAsyncLifetime
    {
        public Task InitializeAsync()
        {
            ExtentReportUtils.InitializeReport();
            return Task.CompletedTask;
        }

        public Task DisposeAsync()
        {
            ExtentReportUtils.FlushReport();
            return Task.CompletedTask;
        }
    }
}

