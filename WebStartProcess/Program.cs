using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebStartProcess
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //var pathToExe = Process.GetCurrentProcess().MainModule.FileName;
      //var pathToContentRoot = Path.GetDirectoryName(pathToExe);

      //var host = WebHost.CreateDefaultBuilder(args)
      //    .UseContentRoot(pathToContentRoot)
      //    .UseStartup<Startup>()
      //    .UseApplicationInsights()
      //    .Build();

      //host.RunAsService();


      BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .Build();
  }
}
