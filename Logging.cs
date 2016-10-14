using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_network_processing
{
    public static class Logging
    {
        public const string sOddPointsFilePath = @"U:\projects\survey\control-network\data\wrk\odd-points.txt";
        public const string sDB_Connection = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=U:\projects\survey\control-network\scripts\wrk\c-sharp\control-network-processing\control-network-processing\Control-Network-Test.mdf;Integrated Security=True";

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

        public static void InsertToOddPointsDB(string sPointName)
        {
            bool bInDB = CheckIfPointInDB(sPointName);

            if (bInDB == false)
            {
                string sStatement = @"INSERT INTO dbo.OddPoints(PointName)
                                      VALUES(@PointName)";
                using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(sDB_Connection))
                {
                    using (System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                    {
                        dbCommand.Parameters.Add("PointName", System.Data.SqlDbType.Text).Value = sPointName;

                        dbConn.Open();
                        int iResult = dbCommand.ExecuteNonQuery();
                    }
                }
            }

        }

        private static bool CheckIfPointInDB(string sPointName)
        {
            bool bInDB = false;
            string sStatement = String.Format(@"SELECT PointName
                                                    FROM dbo.OddPoints
                                                    WHERE PointName LIKE '{0}'", sPointName);
            using (System.Data.SqlClient.SqlConnection dbConn = new System.Data.SqlClient.SqlConnection(sDB_Connection))
            {
                using(System.Data.SqlClient.SqlCommand dbCommand = new System.Data.SqlClient.SqlCommand(sStatement, dbConn))
                {
                    dbConn.Open();
                    System.Data.SqlClient.SqlDataReader dbReader = dbCommand.ExecuteReader();
                    if (dbReader.HasRows == true)
                    {
                        bInDB = true;
                    }
                }
            }
            return bInDB;
        }

    }
}
