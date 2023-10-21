using NUnit.Framework;
using System.Collections.Generic;
using static JawwyTV.Automation.Utils.HelperMethods;

namespace JawwyTV.Automation.Utils
{
    public class Assertion
    {
        public static void CheckListsAreEqual(List<string> expected, List<string> actual)
        {
            Log.Info("Asserting Lists are equal");
            Assert.That(expected.Count == actual.Count, $" {expected.Count} doesn't equal {actual.Count}");
            Assert.Multiple(() =>
            {
                for (int index = 0; index < expected.Count; index++)
                    Assert.That(expected[index] == actual[index], $" {expected[index]} doesn't equal {actual[index]}");
            });
          
        }
    }
}

