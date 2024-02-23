/*var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
*/



using Microsoft.AspNetCore.Hosting;
using yinghttpconnectiontest;

namespace yingtestproject
{
    public class Program
    {

        public static void Main(string[] args)
        {

            // Keep the listener around while you want the logging to continue, dispose it after.
            var listener = new HttpEventListener();

            Console.WriteLine($"{DateTime.UtcNow} start to do async tasks");
            AsyncSimpleTaskUtil.RunTasks();

            Thread.Sleep(1000*30);

        }
    }
}