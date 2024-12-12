using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models;
using MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Extensiones;
using System.Collections.Generic;
using System.Linq;

namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.SyncWorker.Workers
{
    public class FIDSSyncWorker : BackgroundService, Framework.Guama.Core.Presentation.API.Connect.Providers.Facade.IHttpClientHelperProviderFacade
    {
        private readonly Persistence.ORM.EF.FIDSDbContext dbContext;

        private readonly API.Connect.Backend.Clients.CarriersAPIConnectClient carriersAPIConnectClient;
        private readonly API.Connect.Backend.Clients.CategoriesAPIConnectClient categoriesAPIConnectClient;
        private readonly API.Connect.Backend.Clients.CountriesAPIConnectClient countriesAPIConnectClient;
        private readonly API.Connect.Backend.Clients.KindsAPIConnectClient kindsAPIConnectClient;
        private readonly API.Connect.Backend.Clients.OperationsAPIConnectClient operationsAPIConnectClient;
        private readonly API.Connect.Backend.Clients.StatusesAPIConnectClient statusesAPIConnectClient;
        private readonly API.Connect.Backend.Clients.TerminalsAPIConnectClient terminalsAPIConnectClient;
        private readonly API.Connect.Backend.Clients.CheckInsAPIConnectClient checkInsAPIConnectClient;

        private readonly System.Diagnostics.Stopwatch stopwatch;

        private readonly ILogger<FIDSSyncWorker> logger;
        private readonly Microsoft.Extensions.Options.IOptions<Options.TimeOptions> timingOptions;
        private readonly IConfiguration configuration;

        public FIDSSyncWorker(Microsoft.Extensions.Options.IOptions<Options.TimeOptions> timingOptions, IConfiguration configuration, ILogger<FIDSSyncWorker> logger)
        {
            this.logger = logger;
            this.timingOptions = timingOptions;
            this.configuration = configuration;

            stopwatch = new System.Diagnostics.Stopwatch();

            carriersAPIConnectClient = new API.Connect.Backend.Clients.CarriersAPIConnectClient(this);
            categoriesAPIConnectClient = new API.Connect.Backend.Clients.CategoriesAPIConnectClient(this);
            countriesAPIConnectClient = new API.Connect.Backend.Clients.CountriesAPIConnectClient(this);
            kindsAPIConnectClient = new API.Connect.Backend.Clients.KindsAPIConnectClient(this);
            operationsAPIConnectClient = new API.Connect.Backend.Clients.OperationsAPIConnectClient(this);
            statusesAPIConnectClient = new API.Connect.Backend.Clients.StatusesAPIConnectClient(this);
            terminalsAPIConnectClient = new API.Connect.Backend.Clients.TerminalsAPIConnectClient(this);
            checkInsAPIConnectClient = new API.Connect.Backend.Clients.CheckInsAPIConnectClient(this);

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<Persistence.ORM.EF.FIDSDbContext>();

            dbContextOptionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

            dbContext = new Persistence.ORM.EF.FIDSDbContext(dbContextOptionsBuilder.Options);
        }

        protected override async System.Threading.Tasks.Task ExecuteAsync(System.Threading.CancellationToken stoppingToken)
        {
            var countries = new List<CountryDisplayModel>(await countriesAPIConnectClient.GetAsync());

            try
            {
                if (countries.Count < 1)
                {
                    var defeaultCountryId = System.Guid.NewGuid();

                    var model = new CountryInputModel
                    {
                        Id = defeaultCountryId,
                        IsoCode = "CU",
                        Name = "Cuba"
                    };

                    await countriesAPIConnectClient.CreateAsync(model);

                    countries.Add(new CountryDisplayModel
                    {
                        Id = model.Id,
                        IsoCode = model.IsoCode,
                        Name = model.Name
                    });
                }
            }
            catch (System.Exception exception)
            {
                logger.LogError(exception, "Unexpected error on worker preconditions work!!");

                return;
            }

            while (!stoppingToken.IsCancellationRequested)
            {
                stopwatch.Start();

                #region Work Logic Block

                logger.LogInformation(">>>>>>>> Work iteration at: {time}", System.DateTimeOffset.Now);

                try
                {
                    var carriers = new List<CarrierDisplayModel>(await carriersAPIConnectClient.GetAsync());
                    var terminals = new List<TerminalDisplayModel>(await terminalsAPIConnectClient.GetAsync());
                    var categories = new List<CategoryDisplayModel>(await categoriesAPIConnectClient.GetAsync());
                    var kinds = new List<KindDisplayModel>(await kindsAPIConnectClient.GetAsync());
                    var statuses = new List<StatusDisplayModel>(await statusesAPIConnectClient.GetAsync());
                    var operations = new List<OperationDisplayModel>(await operationsAPIConnectClient.GetAsync());
                    
                    countries = new List<CountryDisplayModel>(await countriesAPIConnectClient.GetAsync());

                    if (!kinds.Any(model => model.Id == InterFIDS.Persistence.Enumerations.OperationKind.Departure))
                    {
                        await PersistKindAsync("D", InterFIDS.Persistence.Enumerations.OperationKind.Departure, kinds);
                    }

                    if (!kinds.Any(model => model.Id == InterFIDS.Persistence.Enumerations.OperationKind.Arrival))
                    {
                        await PersistKindAsync("A", InterFIDS.Persistence.Enumerations.OperationKind.Arrival, kinds);
                    }

                    var departureOperations = operations.Where(model => model.Kind.Id == InterFIDS.Persistence.Enumerations.OperationKind.Departure).ToList();

                    var fidsDepartures = dbContext.Set<Persistence.Entities.Departure>().Where(entity => entity.Mostrar == true).ToArray();

                    foreach (var item in fidsDepartures)
                    {
                        var operation = departureOperations.FirstOrDefault(model => model.Id == item.Idoper.Value);

                        var carrier = carriers.FirstOrDefault(model => model.Id.Equals(item.Compania, System.StringComparison.InvariantCultureIgnoreCase));

                        var terminal = terminals.FirstOrDefault(model => model.Discriminator.Equals(item.Terminal));

                        var category = categories.FirstOrDefault(model => model.Discriminator == item.Categoria.Value);

                        var status = statuses.FirstOrDefault(model => model.Discriminator == item.Estado.Value);

                        if (operation == null)
                        {
                            if (carrier == null)
                            {
                                carrier = await PersistCarrierAsync(item.Compania, countries.First(), carriers);
                            }

                            if (terminal == null)
                            {
                                terminal = await PersistTerminalAsync(item.Terminal, terminals);
                            }

                            if (category == null) {
                                category = await PersistCategoryAsync(item.Categoria.Value, categories);
                            }

                            if (status == null) {
                                status = await PersistStatusAsync(item.Estado.Value, statuses);
                            }

                            await operationsAPIConnectClient.CreateAsync(new OperationInputModel
                            {
                                Id = item.Idoper.Value,
                                Context = item.OrigDest,
                                Flight = int.Parse(item.NumeroVuelo),
                                PlannedAt = item.DateTimeP.Value,
                                EstimatedAt = item.DateTimeR,
                                Gate = item.Puerta,
                                CarrierId = carrier.Id,
                                TerminalId = terminal.Id,
                                CategoryId = category.Id,
                                StatusId = status.Id,
                                KindId = InterFIDS.Persistence.Enumerations.OperationKind.Departure
                            });
                        }
                        else if (operation.IsUpdateRequired(item))
                        {
                            await operationsAPIConnectClient.EditAsync(new OperationInputModel
                            {
                                Id = operation.Id,
                                Context = item.OrigDest,
                                Flight = int.Parse(item.NumeroVuelo),
                                PlannedAt = item.DateTimeP.Value,
                                EstimatedAt= item.DateTimeR,
                                Gate = item.Puerta,
                                CarrierId = carrier.Id,
                                TerminalId = terminal.Id,
                                CategoryId = category.Id,
                                StatusId = status.Id,
                                KindId = InterFIDS.Persistence.Enumerations.OperationKind.Departure
                            });
                        }

                        departureOperations.Remove(operation);
                    }

                    foreach (var operation in departureOperations)
                    {
                        await operationsAPIConnectClient.Delete(operation.Id);
                    }

                    var arraivalOperations = operations.Where(model => model.Kind.Id == InterFIDS.Persistence.Enumerations.OperationKind.Arrival).ToList();

                    var fidsArrivals = dbContext.Set<Persistence.Entities.Arraival>().Where(entity => entity.Mostrar == true).ToArray();

                    foreach (var item in fidsArrivals)
                    {
                        var operation = arraivalOperations.FirstOrDefault(model => model.Id == item.Idoper.Value);

                        var carrier = carriers.FirstOrDefault(model => model.Id.Equals(item.Compania, System.StringComparison.InvariantCultureIgnoreCase));

                        var terminal = terminals.FirstOrDefault(model => model.Discriminator.Equals(item.Terminal));

                        var category = categories.FirstOrDefault(model => model.Discriminator == item.Categoria.Value);

                        var status = statuses.FirstOrDefault(model => model.Discriminator == item.Estado.Value);

                        if (operation == null)
                        {
                            if (carrier == null)
                            {
                                carrier = await PersistCarrierAsync(item.Compania, countries.First(), carriers);
                            }

                            if (terminal == null)
                            {
                                terminal = await PersistTerminalAsync(item.Terminal, terminals);
                            }

                            if (category == null)
                            {
                                category = await PersistCategoryAsync(item.Categoria.Value, categories);
                            }

                            if (status == null)
                            {
                                status = await PersistStatusAsync(item.Estado.Value, statuses);
                            }

                            await operationsAPIConnectClient.CreateAsync(new OperationInputModel
                            {
                                Id = item.Idoper.Value,
                                Context = item.OrigDest,
                                Flight = int.Parse(item.NumeroVuelo),
                                PlannedAt = item.DateTimeP.Value,
                                EstimatedAt = item.DateTimeR,
                                Gate = item.Puerta,
                                CarrierId = carrier.Id,
                                TerminalId = terminal.Id,
                                CategoryId = category.Id,
                                StatusId = status.Id,
                                KindId = InterFIDS.Persistence.Enumerations.OperationKind.Arrival
                            });
                        }
                        else if (operation.IsUpdateRequired(item))
                        {
                            await operationsAPIConnectClient.EditAsync(new OperationInputModel
                            {
                                Id = operation.Id,
                                Context = item.OrigDest,
                                Flight = int.Parse(item.NumeroVuelo),
                                PlannedAt = item.DateTimeP.Value,
                                EstimatedAt = item.DateTimeR,
                                Gate = item.Puerta,
                                CarrierId = carrier.Id,
                                TerminalId = terminal.Id,
                                CategoryId = category.Id,
                                StatusId = status.Id,
                                KindId = InterFIDS.Persistence.Enumerations.OperationKind.Arrival
                            });
                        }

                        arraivalOperations.Remove(operation);
                    }

                    foreach (var operation in arraivalOperations)
                    {
                        await operationsAPIConnectClient.Delete(operation.Id);
                    }

                    var viderheCheckins = (await checkInsAPIConnectClient.GetAsync()).ToList();

                    var now = System.DateTime.Now;

                    var targetStartAt = now - timingOptions.Value.PreCheckInTime;

                    var targetEndAt = now + timingOptions.Value.PostCheckInTime;

                    var checkIns = dbContext.Set<Persistence.Entities.CheckIn>().Where(entity => entity.Habilitado == true && ((entity.FechaIni >= targetStartAt && entity.FechaIni <= targetEndAt) || (entity.FechaFin >= targetEndAt && entity.FechaFin <= targetEndAt))).ToArray();

                    await checkInsAPIConnectClient.ReplaceAsync(checkIns.Select(entity => new CheckInInputModel
                    {
                        Number = entity.IdMostrador.Value,
                        DepartureOperationId = long.Parse(entity.IdOper),
                        StartAt = entity.FechaIni.Value,
                        EndAt = entity.FechaFin.Value,
                        IsVIP = entity.Vip != null && entity.Vip.Value,
                        IsOpen = entity.Abierto != null && entity.Abierto.Value
                    }).ToArray());
                }
                catch (System.Exception exception)
                {
                    logger.LogError(exception, "Unexpected error on operations syncronization work!!");
                }
                #endregion

                var configurationDelayTime = timingOptions.Value.IterationElapseTime;

                stopwatch.Stop();

                logger.LogInformation(">>>>>>>>>>>>>>> Work iteration time cost: {time}", stopwatch.Elapsed);

                var delay = configurationDelayTime - stopwatch.Elapsed;

                stopwatch.Reset();

                if (delay >= System.TimeSpan.Zero)
                {
                    await System.Threading.Tasks.Task.Delay(delay, stoppingToken);
                }
            }
        }

        private async System.Threading.Tasks.Task<CarrierDisplayModel> PersistCarrierAsync(string id, CountryDisplayModel defaultCountry, List<CarrierDisplayModel> list)
        {
            var model = new CarrierInputModel
            {
                Id = id.ToUpperInvariant(),
                Name = id.ToUpperInvariant(),
                CountryId = defaultCountry.Id,
                PrimaryColor = System.Drawing.Color.IndianRed.ToString(),
                SecoundaryColor = System.Drawing.Color.Indigo.ToString()
            };

            await carriersAPIConnectClient.CreateAsync(model);

            var result = new CarrierDisplayModel
            {
                Id = model.Id
            };

            list.Add(result);

            return result;
        }

        private async System.Threading.Tasks.Task<TerminalDisplayModel> PersistTerminalAsync(string id, List<TerminalDisplayModel> list)
        {
            var model = new TerminalInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = string.Format("Terminal {0}", id.ToUpperInvariant()),
                Discriminator = id
            };

            await terminalsAPIConnectClient.CreateAsync(model);

            var result = new TerminalDisplayModel
            {
                Id = model.Id,
                Discriminator = model.Discriminator
            };

            list.Add(result);

            return result;
        }

        private async System.Threading.Tasks.Task<CategoryDisplayModel> PersistCategoryAsync(int id, List<CategoryDisplayModel> list)
        {
            var model = new CategoryInputModel
            {
                Id = System.Guid.NewGuid(),
                Name = string.Format("Categoría {0}", id),
                Discriminator = id
            };

            await categoriesAPIConnectClient.CreateAsync(model);

            var result = new CategoryDisplayModel
            {
                Id = model.Id,
                Discriminator = model.Discriminator
            };

            list.Add(result);

            return result;
        }

        private async System.Threading.Tasks.Task<StatusDisplayModel> PersistStatusAsync(int id, List<StatusDisplayModel> list)
        {
            var model = new StatusInputModel
            {
                Id = System.Guid.NewGuid(),
                Label = string.Format("Estado {0}", id),
                Discriminator = id
            };

            await statusesAPIConnectClient.CreateAsync(model);

            var result = new StatusDisplayModel
            {
                Id = model.Id,
                Discriminator = model.Discriminator
            };

            list.Add(result);

            return result;
        }

        private async System.Threading.Tasks.Task<KindDisplayModel> PersistKindAsync(string id, InterFIDS.Persistence.Enumerations.OperationKind operationKind, List<KindDisplayModel> list)
        {
            var model = new KindInputModel
            {
                Id = operationKind,
                Discriminator = id
            };

            await kindsAPIConnectClient.CreateAsync(model);

            var result = new KindDisplayModel
            {
                Id = model.Id,
                Discriminator = model.Discriminator
            };

            list.Add(result);

            return result;
        }

        #region IHttpClientHelperProviderFacade implementation

        public Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper HttpClientHelper 
        { 
            get
            {
                return new Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper(
                    string.Format("http://{0}/api/", configuration.GetSection("WebOlupin:Host").Value),
                    null,
                    () => { return new KeyValuePair<string, string>[] { new KeyValuePair<string, string>(API.Common.Constants.Authentication.API_KEY_HEADER_PROPERTY, configuration.GetSection("WebOlupin:APIKey").Value) }; });
            }
        }

        #endregion
    }
}