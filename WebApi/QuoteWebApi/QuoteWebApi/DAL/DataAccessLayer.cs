using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Reflection;


namespace QuoteWebApi
{
    /// <summary>
    /// This class is used for all the data operations
    /// </summary>
    public class DataAccessLayer
    {
        /// <summary>
        /// Gets the data from Quotes json file
        /// </summary>
        /// <returns></returns>
        public RootQuotes GetQuotesFromJsonFile()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filepath = exePath + "\\Data\\quotes.json";
            RootQuotes myDeserializedClass = JsonConvert.DeserializeObject<RootQuotes>(File.ReadAllText(filepath));
            return myDeserializedClass;
        }

        /// <summary>
        /// Gets all the person data
        /// </summary>
        /// <returns></returns>
        public RootPerson GetDummyPersonData()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filepath = exePath + "\\Data\\persons.json";
            RootPerson myDeserializedClass = JsonConvert.DeserializeObject<RootPerson>(File.ReadAllText(filepath));
            return myDeserializedClass;
        }

        /// <summary>
        /// Adds or deletes the additional insured data
        /// </summary>
        /// <param name="insured"></param>
        /// <param name="isAdded"></param>
        /// <returns></returns>
        public bool AddorDeleteAdditionalInsured(AdditionalInsured insured, bool isAdded)
        {
            var exePath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filepath = exePath + "\\Data\\AdditionalInsured.json";
            RootAdditionalInsured myDeserialized= JsonConvert.DeserializeObject<RootAdditionalInsured>(File.ReadAllText(filepath));
            if (isAdded && myDeserialized.AdditionalInsured.FirstOrDefault(r=>r.Id == insured.Id)  == null)
            {
                myDeserialized.AdditionalInsured.Add(insured);
            }
            else
            {
                myDeserialized.AdditionalInsured.Remove(insured);
            }
            var serialized= JsonConvert.SerializeObject(myDeserialized);
            File.WriteAllText(filepath, serialized);
            return true;
        }
    }
}
