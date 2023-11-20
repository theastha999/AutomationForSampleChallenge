using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
namespace AutomationTestSample.TestingFramework.Reports;


public class ExtentReportUtils
{
    public static ExtentReports? extent;

    public static void InitializeReport()



    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string reportpath = currentDirectory.Split("bin")[0] + "TestingFramework/Reports/TestReports.html";

        var sparkReporter = new ExtentSparkReporter(reportpath);
        extent = new ExtentReports();
        extent.AttachReporter(sparkReporter);
    }

    public static void FlushReport()
    {
        extent.Flush();
    }
}


