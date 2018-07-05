using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace MvcCoreCRUDApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string s = "ABCD";

            s = new string(s.ToCharArray().Reverse().ToArray());

            StringBuilder builder = new StringBuilder(s.Length);

            for (int i = s.Length - 1; i >= 0; i--)
            {
                builder.Append(s[i]);
            }
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
