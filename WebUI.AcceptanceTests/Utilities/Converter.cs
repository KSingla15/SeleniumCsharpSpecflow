using System.Collections.Generic;
using System.Linq;

namespace WebUI.AcceptanceTests.Utilities
{
    public class Converter
    {
        public static List<string> ConvertStringToList(string input)
        {
            if (input.Contains(";"))
            {
                return input.Split(';').ToList();
            }
            else
            {
                return new List<string>() { input };
            }
        }
    }
}
