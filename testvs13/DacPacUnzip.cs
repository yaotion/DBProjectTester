using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 

using System.Data.SqlClient;

using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Dac;
 using Microsoft.SqlServer.Management.Sdk;
using Microsoft.SqlServer.Management.Sdk.Sfc;
using Microsoft.SqlServer.Management.Smo;
 

using System.IO;
namespace DbUnitTest2000
{
    
 public   class DACExtracter

    {

        private List <string>GetDatabaseNames(SqlConnection conn)

        {

            //SqlCommand comm = new SqlCommand( "SELECT name FROM sys.databases where database_id>4",conn);

            List<string >dbNames = new List<string >();

            //try

            //{

            //    conn.Open();

            //    SqlDataReader reader= comm.ExecuteReader();

            //    while(reader.Read())

            //    {

            //       dbNames.Add("Database1");
            //       break;
            //    }
              dbNames.Add(conn.Database);
 

                return dbNames;

            //}

            //catch

            //{

            //    Console.WriteLine("connect dbfailed");

            //    throw(new Exception("connect db failed"));

            //}

            //finally

            //{

            //    if(conn!=null )

            //    {

            //        conn.Close();

            //        conn.Dispose();

            //    }

            //}

 

 

        }
        public static string filem = "";
        public void ExtractDAC(string connectionString, string extractFolderPath)

        {

            try

            {

                SqlConnection sqlConnection = new SqlConnection(connectionString);

               // ServerConnection conn = new ServerConnection(sqlConnection);

               // Server destServer =new Server(conn);

                List<string >dbNames = GetDatabaseNames(sqlConnection);

                string version ="1.0.0.1" ;
                Version v = new Version(version);

                foreach (string dbName in dbNames)

                {

                    ExtractDAC(connectionString, dbName, v, extractFolderPath);
                   
                }

            }

            catch(Exception )

            {

               Console.WriteLine("End with error" );

            }

        }

        public void ExtractDAC(string destServer, string databaseName, Version version, string extractFolderPath)

        {

            try
            {

              //  Console.WriteLine(destServer.Information.Version);
                Microsoft.SqlServer.Dac.DacServices dacUnit = new Microsoft.SqlServer.Dac.DacServices(destServer);

               // DacExtractionUnit dacUnit = new DacExtractionUnit(destServer, databaseName, databaseName, new Version(version));



                DirectoryInfo dir = new DirectoryInfo(extractFolderPath);

                if (!dir.Exists)
                {

                    dir.Create();

                }

                string dacFilePath = dir.FullName + @"\" + databaseName + ".dacpac";

                if (File.Exists(dacFilePath))
                {

                    File.Delete(dacFilePath);

                }
                dacUnit.Extract(dacFilePath, databaseName, databaseName, version);
                filem = dacFilePath;
              //  dacUnit.ExportBacpac(dacFilePath, databaseName);
               // dacUnit.Extract(dacFilePath);

               // Console.WriteLine("extract " + databaseName + "successfully");

            }

            catch (IOException)
            {

                Console.WriteLine("please check extract folder");

                Console.WriteLine("extract " + databaseName + "failed");

            }

            catch (Exception EXC)
            {

                Console.WriteLine("extract " + databaseName + "failed");

            }

          

        }
        

    }
    public  class testdac
    {
   
 //static void Main(string[] args)

 //       {

 //           String connectionString= "Data Source=88.88.88.88,18991;Initial Catalog=master;IntegratedSecurity=False;User ID=sa;Password=sa;";

 //           DACExtracter dacExtracter = new DACExtracter();

 //          dacExtracter.ExtractDAC(connectionString, @"E:\DBScript" );

 //          Console.WriteLine("press any key to close");

 //           Console.ReadLine();

 //       }
 

        }

 
}
