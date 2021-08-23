using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_API.Helper
{
    public class Connection
    {
        public static string testAPI { get; internal set; }

        private static string GetConnection()
        {
            var config = new ConfigurationBuilder()
           .SetBasePath(Directory.GetDirectoryRoot(@"\"))
           .AddJsonFile("appSettings.json", false)
           .Build();
            var connString = config.GetSection("connectionString").Value;
            return connString;
        }
    }
}
