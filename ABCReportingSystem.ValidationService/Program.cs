using System;
using System.IO;

namespace ABCReportingSystem.RecollectorService
{
    public class Program
    {
        static void Main(string[] args)
        {

            var rootPath = @"C:\Users\isaac\Documents\files";

            foreach (string file in Directory.EnumerateFiles(rootPath,"*.csv"))
            {
                
            }
        }
    }
}
