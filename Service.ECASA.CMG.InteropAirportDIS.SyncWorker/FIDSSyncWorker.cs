using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker
{
    public class FIDSSyncWorker : BackgroundService
    {
        private readonly ILogger<FIDSSyncWorker> _logger;

        public FIDSSyncWorker(ILogger<FIDSSyncWorker> logger)
        {
            _logger = logger;
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", System.DateTimeOffset.Now);
                
                await System.Threading.Tasks.Task.Delay(1000, stoppingToken);
            }
        }
    }
}