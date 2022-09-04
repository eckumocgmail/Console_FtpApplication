using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static InputApplicationProgram;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

public class FtpApplicationProgram
{
    internal static void Run(string[] args)
    {
        
        Clear();
        IHostBuilder build = Host.CreateDefaultBuilder();
        foreach (var arg in args)
            build.ConfigureServices((context, services) =>
            {
                services.AddHostedService<ProcessManager>();
            });                
        IHost host = build.Build();



        host.Run();
        
        /*switch (ProgramDialog.SingleSelect(

            "", new string[]{
            "Выполнить вешнюю программу",
            "Выполнить программу Dotnet",
            "Собрать рабочий стол",
            "Выход" }, ref args))
        {

            case "Выполнить вешнюю программу":
                RunExternalProgram(ref args); break;
            case "Выполнить программу Dotnet":
                RunDotnetProgram(ref args); break;
            case "Собрать рабочий стол":
                RunDesctopToolBuilder(ref args); break;
            case "Выход":
                Process.GetCurrentProcess().Kill();
                break;
            default:
                throw new NotImplementedException();
        }*/
    }
}

