using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SemOrder.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
#if DEBUG
                            .UseIISIntegration()
#endif
                    .UseUrls("http://localhost:4000")
                    .UseStartup<Startup>()
                    .Build();
                host.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

    }
}
