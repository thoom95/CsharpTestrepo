﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3.Services
{
    public class IOService
    {
        public void WriteJsonToFile(string stringToWrite, string fileName)
        {
            System.IO.File.WriteAllText(@"C:\Users\Thomas-Laptop\source\repos\IntegrationTestTool\IntegrationTestTool\JSONs\" + fileName, stringToWrite);
        }
    }
}