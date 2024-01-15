using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition_Task.Utilities
{
    public class JsonReader
    {

        public static List<T> ReadTestDataFromJson<T>(string jsonFilePath)
        {
            string jsonContent = File.ReadAllText(jsonFilePath);
            List<T> testData = JsonConvert.DeserializeObject<List<T>>(jsonContent);
            return testData;
        }
    }
}
