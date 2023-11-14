using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<FIDSSyncWorker>();
                })
                .Build();

            await host.RunAsync();
        }
    }
}