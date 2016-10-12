using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public static class Logging
    {
        public const string sOddPointsFilePath = @"U:\projects\survey\control-network\data\wrk\odd-points.txt";

        public static void OddPointsLog(string sOddPointsFilePath, string sPointName)
        {
            string sOddPointsFileContents = System.IO.File.ReadAllText(sOddPointsFilePath);
            var reMatches = System.Text.RegularExpressions.Regex.Match(sOddPointsFileContents, sPointName);
            if (reMatches.Captures.Count < 1)
            {
                using (System.IO.StreamWriter swOddPoints = new System.IO.StreamWriter(sOddPointsFilePath, true))
                {
                    swOddPoints.WriteLine(sPointName);
                }
            }
        }

    }
}
