using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public static class RegularExpressions
    {
        public static string GetAlphaCharacters(string sValue)
        {
            string sAlphaCharacters = null;
            System.Text.RegularExpressions.MatchCollection pAlphaCharacterMatches = System.Text.RegularExpressions.Regex.Matches(sValue, @"[a-zA-Z]+");
            if (pAlphaCharacterMatches.Count == 1)
            {
                sAlphaCharacters = pAlphaCharacterMatches[0].Value;
            }
            return sAlphaCharacters;
        }

        public static double? GetSignDigitsAndDecimal(string sValue,
                                                      string sMissingValue)
        {
            double? dValue = null;
            if (String.Compare(sValue, sMissingValue) == 0)
            {
                return dValue;
            }
            else
            {
                System.Text.RegularExpressions.MatchCollection pFloatingPointNumberMatches = System.Text.RegularExpressions.Regex.Matches(sValue, @"[+-]? *(?:\d+(?:\.\d*)?|\.\d+)");
                if (pFloatingPointNumberMatches.Count >= 1)
                {
                    return Convert.ToDouble(pFloatingPointNumberMatches[0].Value); 

                }
                else
                {
                    throw new Exception("could not extract double from string.");
                }
            }
        }

        public static double GetSignDigitsAndDecimal(string sValue)
        {
            System.Text.RegularExpressions.MatchCollection pFloatingPointNumberMatches = System.Text.RegularExpressions.Regex.Matches(sValue, @"[+-]? *(?:\d+(?:\.\d*)?|\.\d+)");
            if (pFloatingPointNumberMatches.Count >= 1)
            {
                return Convert.ToDouble(pFloatingPointNumberMatches[0].Value);

            }
            else
            {
                throw new Exception("could not extract double from string.");
            }
        }

        public static bool CheckIfContainsDigitsAndDecimal(string sValue)
        {
            bool bContains = false;
            System.Text.RegularExpressions.MatchCollection pFloatingPointNumberMatches = System.Text.RegularExpressions.Regex.Matches(sValue, @"[+-]? *(?:\d+(?:\.\d*)?|\.\d+)");
            if (pFloatingPointNumberMatches.Count >= 1){bContains = true;}
            return bContains;
        }

    }
}
