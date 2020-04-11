using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject.UITest.Settings;

namespace TestProject.UITest.Utilities
{
    public static class ConfigFile
    {
        public static readonly double PollingInterval = 500;

        public static readonly double ShortTimeout = 2000;

        public static readonly double DefaultTimeout = 45000;

        public static readonly double PageLoadTimeout = 30000;

        public static readonly double Timeout = 10000;
    }
}
