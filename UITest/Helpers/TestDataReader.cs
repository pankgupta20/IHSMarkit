using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using TestProject.UITest.Utilities;

namespace TestProject.UITest.Helpers
{
    public static class TestDataReader
    {
        public static readonly string _projectBasePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug", "");

        public static string LoadTestDataFile(string filePath)
        {
            var jsonString = string.Empty;
            try
            {
                if (File.Exists(filePath))
                {
                    jsonString = File.ReadAllText(filePath);
                }
                return jsonString;
            }
            catch (FileNotFoundException ex)
            {
                Logger.WriteInfo(ex.Message);
                return jsonString;
            }
        }

        public static string GetTestDataFolder()
        {
            var testFolderPath = Path.Combine(_projectBasePath, "UITest\\TestData");
            return testFolderPath;
        }

        public static T DeserializefromTestDataFile<T>(string fileName)
        {
            var filePath = Path.Combine(GetTestDataFolder(), fileName);
            var jsonTestData = LoadTestDataFile(filePath);
            var jsonTestDataList = JsonConvert.DeserializeObject<T>(jsonTestData);
            return jsonTestDataList;
        }

        public static IList<T> DeserializeMultipleDatafromTestDataFile<T>(string fileName)
        {
            var filePath = Path.Combine(GetTestDataFolder(), fileName);
            var jsonTestData = LoadTestDataFile(filePath);
            var jsonTestDataList = JsonConvert.DeserializeObject<IList<T>>(jsonTestData);
            return jsonTestDataList;
        }
    }
}
