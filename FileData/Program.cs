using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        public static void GetFileVersion(string str, string path)
        {
            try
            {
                if (str.Equals("-v"))
                {
                    FileDetails objFileDetails = new FileDetails();
                    string fileVersion = objFileDetails.Version(path);
                    Console.WriteLine("File Version: {0}", fileVersion);
                    Console.ReadLine();
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public static void GetFileDetails(string str, string path)
        {
            try
            {
                var checkForVersion = new[] { "-v", "--v", "/v" };
                var checkForSize = new[] { "-s", "--s", "/s" };
                string methodType = checkForVersion.Any(str.Contains) ? "Version" : checkForSize.Any(str.Contains) ? "Size" : string.Empty;

                if (!string.IsNullOrEmpty(methodType))
                {
                    FileDetails objFileDetails = new FileDetails();
                    if (methodType == "Version")
                    {
                        Console.WriteLine("File details type: {0}", methodType);
                        string fileVersion = objFileDetails.Version(path);
                        Console.WriteLine("File Version: {0}", fileVersion);
                    }
                    else
                    {
                        Console.WriteLine("File details type: {0}", methodType);
                        int fileSize = objFileDetails.Size(path);
                        Console.WriteLine("File Size: {0}", fileSize);
                    }

                    Console.ReadLine();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("Enter file details type");
            string detailsType = Console.ReadLine();

            Console.WriteLine("Enter file path");
            string filePath = Console.ReadLine();

            Program.GetFileVersion(detailsType, filePath);

            Program.GetFileDetails(detailsType, filePath);
        }
    }
}
