using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.IO;

namespace JawwyTV.Automation.Utils
{
    public static class HelperMethods
    {
        public static NLog.Logger Log
        {

            get
            {
                return NLog.LogManager.GetCurrentClassLogger();
            }
        }

        public static T LoadJson<T>(string filename)
        {
            T contents = default(T);

            try
            {
                contents = JsonConvert.DeserializeObject<T>(File.ReadAllText($"{TestContext.CurrentContext.TestDirectory}\\TestData\\{filename}"));
            }
            catch (Exception e)
            {
                Log.Error($"Attempt to load JSON file from {filename} and parse to model {typeof(T).FullName} failed.", e);
            }

            return contents;
        }
    }

}

