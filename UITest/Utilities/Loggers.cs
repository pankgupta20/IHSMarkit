using System;
using System.Globalization;

namespace TestProject.UITest.Utilities
{
    public static class Logger
    {
        public static void WriteInfo(string information)
        {
            Console.WriteLine(string.Format("{0} - {1}: {2}", "INFO",
                DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), information));
        }

        public static void WriteError(string error)
        {
            Console.WriteLine(string.Format("{0} - {1}: {2}", "ERROR",
                DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), error));
        }

        public static void WriteWarning(string warning)
        {
            Console.WriteLine(string.Format("{0} - {1}: {2}", "WARNING",
                DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), warning));
        }

        public static void WriteDebug(string debugMsg, bool toggleDebug)
        {
            if (toggleDebug)
            {
                Console.WriteLine(string.Format("{0} - {1}: {2}", "DEBUG",
                DateTime.UtcNow.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture), debugMsg));
            }
        }
    }
}
