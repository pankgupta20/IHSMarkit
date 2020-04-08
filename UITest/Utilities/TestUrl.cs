using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.UITest.Settings;

namespace TestProject.UITest.Utilities
{
    public static class TestUrl
    {
        public static string GetUrl(TestContext testContext)
        {
            var testName = testContext.TestName.ToLower().Trim();
            switch (testName)
            {
                case "AutomationPractice":
                    return Url.Default.AutomationPracticeUrl;
                case "Expedia":
                    return Url.Default.ExpediaUrl;
                default:
                    return string.Empty;
            }
        }
    }
}
