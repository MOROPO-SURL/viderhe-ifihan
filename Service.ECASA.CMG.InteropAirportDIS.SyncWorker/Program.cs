using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<Workers.FIDSSyncWorker>();
                })
                .ConfigureHostOptions(options => options.BackgroundServiceExceptionBehavior = BackgroundServiceExceptionBehavior.Ignore)
                .Build();

            await host.RunAsync();
        }
    }
}