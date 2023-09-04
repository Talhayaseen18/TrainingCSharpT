using Newtonsoft.Json;
using OpenQA.Selenium.DevTools.V112.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingCSharp.DataObjects;

namespace TrainingCSharp
{
    public class CredentialHelper
    {
        public static Credentials ReadCredentials(string jsonFilePath)
        {
            try
            {
                string json = File.ReadAllText(jsonFilePath);
                return JsonConvert.DeserializeObject<Credentials>(json);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading credentials from JSON file: {ex.Message}");
            }
        }

    }
}
