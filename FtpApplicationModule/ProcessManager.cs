using Microsoft.Extensions.Hosting;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IProcessManager
{
    public ConcurrentQueue<string> Input { get; set; };
    public ConcurrentQueue<string> Output { get; set; };
  
    


}

public class ProcessManager: IProcessManager, IHostedService
{

    public ConcurrentQueue<string> Input { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ConcurrentQueue<string> Output { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public ProcessManager()
    {

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        while (cancellationToken.IsCancellationRequested == false)
        {
            this.Input.TryDequeue(out var request);
            string response = this.Activate(request);
            this.Output.Enqueue(response);
            await Task.Delay(100);
        }
       
    }

    public class AppRequest
    {
        public string Action { get; set; }
        public Dictionary<string,object> Pars { get; set; }
    }
    private string Activate(string request)
    {


        
    }

    public class JsonConvert
    {
        public static T DeseriallizeObject<T>(string text)
        {
            return System.Text.Json.JsonSerializer.Deserialize<T>(text);
        }
    }

    private void Activate(string request)
    {

        AppRequest Request = null;
        try
        {
            try
            {
                Request = JsonConvert.DeseriallizeObject<AppRequest>(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Исключение при десериаллизации теста сообщения")
            }
        }
        catch (Exception ex)
        {

        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new System.NotImplementedException();
    }

}