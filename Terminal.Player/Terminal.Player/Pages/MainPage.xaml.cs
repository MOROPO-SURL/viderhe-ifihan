using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Essential.Descriptors;
using MOROPO.VIDERHE.Support.Extend.Templating.Presentation.Providers;
using MOROPO.VIDERHE.Support.Presentation.Extensions;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using MOROPO.VIDERHE.Support.Presentation.Managers;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Providers;
using MOROPO.VIDERHE.Terminal.Player.Enumerations;
using MOROPO.VIDERHE.Terminal.Player.Helpers.Facade;
using MOROPO.VIDERHE.Terminal.Player.Hubs.Client;
using MOROPO.VIDERHE.Terminal.Player.Managers;
using MOROPO.VIDERHE.Terminal.Player.Models.View;
using MOROPO.VIDERHE.Terminal.Player.Providers;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Contract;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Player.Pages
{
    public partial class MainPage : Xamarin.Forms.ContentPage
    {
        private PlacardViewModel[] placards;

        private ScheduledRelaunchDisplayModel scheduledRelaunche;

        private readonly System.Collections.Generic.Queue<ConfigurationStep> configurationStepQueue;

        private Extend.Common.Overlaying.Presentation.Views.BaseOverlayView overlayView;

        private readonly System.DateTime startUpAt;

        public MainPage()
        {
            startUpAt = System.DateTime.Now;

            InitializeComponent();

            CopyRightLabel.Text = string.Format("© 2022 - {0} Todos los derechos reservados", System.DateTime.Now.Year);

            configurationStepQueue = new System.Collections.Generic.Queue<ConfigurationStep>();

            IsEnabled = false;

            InitializeSteps();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(2)).ContinueWith(_ => Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentNextConfigurationStep));
            }

            IsEnabled = true;
        }

        private void BrandingSvgCachedImage_Finish(object sender, FFImageLoading.Forms.CachedImageEvents.FinishEventArgs e)
        {
            ForBrandingLabel.Opacity = 1;
            CopyRightLabel.Opacity = 1;
        }

        private void InitializeSteps()
        {
            configurationStepQueue.Enqueue(ConfigurationStep.Starting);
            configurationStepQueue.Enqueue(ConfigurationStep.PlayerRegistration);
            configurationStepQueue.Enqueue(ConfigurationStep.ScreenplayFetch);
        }

        private void PresentNextConfigurationStep()
        {
            if (configurationStepQueue.Count <= 0)
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        var accountInformationProvider = Xamarin.Forms.DependencyService.Get<Extend.Common.Presentation.Providers.Facade.IAccountInformationProviderFacade>();

                        overlayView = accountInformationProvider.AccountDefaultOverlayId == null ? null : OverlayPresentationViewProvider.Instance.GetOverlayPresentationView();

                        var screenplayPlayerPage = new Support.Presentation.Player.Pages.ScreenplayPlayerPage(placards, ScreenplayPresentationEnded_Callback, true, PlacardPlaying_Callback, ScreenplayPresentIterationComplete_Callback, overlayView, PlacardViewTransitionComplete_Callback)
                        {
                            BackgroundColor = SessionManager.Instance.Account.PrimaryColor,
                            BindingContext = Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Orientation == Xamarin.Essentials.DisplayOrientation.Portrait ? SessionManager.Instance.Account.VerticalSplashImageSource : SessionManager.Instance.Account.HorizontalSplashImageSource
                        };

                        this.NavigationPushModalPageAsync(screenplayPlayerPage);

                        PlayerHubClient.Instance.GetReady();
                    });
                });

                return;
            }

            var configurationStep = configurationStepQueue.Dequeue();

            ConfigurationStepViewModel model = null;

            switch (configurationStep)
            {
                case ConfigurationStep.PlayerRegistration:
                    model = new ConfigurationStepViewModel
                    {
                        Title = "Registro",
                        DetailContentView = new Views.ConfigurationStepPlayerRegistrationDetailView()
                    };

                    break;
                case ConfigurationStep.ScreenplayFetch:
                    model = new ConfigurationStepViewModel
                    {
                        Title = "Sincronización",
                        DetailContentView = new Views.ConfigurationStepScreenplayFetchingDetailView()
                    };

                    break;
                case ConfigurationStep.Starting:
                default:
                    model = new ConfigurationStepViewModel
                    {
                        Title = "Iniciando",
                        DetailContentView = new Views.ConfigurationStepStartingDetailView()
                    };

                    break;
            }

            model.DetailContentView.Opacity = 0;

            var storyboard = new Storyboard
            {
                IsParallel = true,
                Delay = "250"
            };

            storyboard.Animations.Add(new FadeInAnimation { Target = StepTitleLabel, Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down });
            storyboard.Animations.Add(new FadeInAnimation { Target = model.DetailContentView, Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up });

            ConfigurationStepViewModel completedConfigurationStepModel = null;

            if (BindingContext != null)
            {
                completedConfigurationStepModel = BindingContext as ConfigurationStepViewModel;
            }

            try
            {
                BindingContext = model;
            }
            catch (System.Exception exp)
            {

            }

            completedConfigurationStepModel?.Dispose();

            if (configurationStep == ConfigurationStep.Starting)
            {
                storyboard.Animations.Add(new FadeToAnimation { Target = CurrentTaskProgressBar, Opacity = 1 });

                System.Threading.Tasks.Task.Run(async () =>
                {
                    await storyboard.Begin();

                    await System.Threading.Tasks.Task.Delay(3000);

                    await RequestAccountAsync().ContinueWith(RequestAccount_Callback);
                });
            }
            else if (configurationStep == ConfigurationStep.PlayerRegistration)
            {
                storyboard.Begin();
            }
            else if (configurationStep == ConfigurationStep.ScreenplayFetch)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    await storyboard.Begin();

                    await System.Threading.Tasks.Task.Delay(3000);

                    await RequestPlaybackConfigurationAsyncAsync().ContinueWith(RequestPlaybackConfiguration_Callback);
                });
            }
        }

        private void CurrentStepAnimateOut_Completed(object sender, System.EventArgs eventArgs)
        {
            (sender as AbstractAnimation).Completed -= CurrentStepAnimateOut_Completed;

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1)).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentNextConfigurationStep);
            });
        }

        private void ScreenplayPresentationEnded_Callback()
        {
            this.NavigationPopModalPageAsync().ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    InitializeSteps();

                    PresentNextConfigurationStep();
                });
            });
        }

        private void PlacardPlaying_Callback(System.Guid placardId)
        {
            PlayerHubClient.Instance.NotifyPlayingPlacard(placardId);
        }

        private void PlacardViewTransitionComplete_Callback(Extend.Common.Presentation.Views.BasePlacardPresentationView incomingPlacardView, Extend.Common.Presentation.Views.BasePlacardPresentationView outgingPlacardView)
        {
            var incomingPlacardViewContext = incomingPlacardView.BindingContext as AbstractPlacardViewModel;

            if (!(outgingPlacardView?.BindingContext is AbstractPlacardViewModel outgoingPlacardViewContext))
            {
                if (incomingPlacardViewContext.RequireUnobstructedPresetation)
                {
                    overlayView?.ShowOut();
                }
            }
            else if (incomingPlacardViewContext.RequireUnobstructedPresetation != outgoingPlacardViewContext.RequireUnobstructedPresetation)
            {
                if (incomingPlacardViewContext.RequireUnobstructedPresetation)
                {
                    overlayView?.ShowOut();
                }
                else
                {
                    overlayView?.ShowIn();
                }
            }
        }

        #region Api Interaction Tasks and Callbacks

        private async System.Threading.Tasks.Task<AccountDisplayModel> RequestAccountAsync()
        {
            var client = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(SessionManager.Instance);

            return await client.GetAccountAsync();
        }

        private void RequestAccount_Callback(System.Threading.Tasks.Task<AccountDisplayModel> task)
        {
            if (task.IsCanceled || task.Exception != null)
            {
                if (task.Exception != null)
                {
                    System.Exception targetException = task.Exception;

                    while (targetException is System.AggregateException)
                    {
                        targetException = targetException.InnerException;
                    }

                    if (targetException is Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException && (targetException as Framework.Guama.Core.Presentation.API.Connect.UnspectedHttpStatusException).HttpStatusCode == System.Net.HttpStatusCode.Forbidden)
                    {
                        if (!((BindingContext as ConfigurationStepViewModel).DetailContentView is Views.ConfigurationStepPlayerRegistrationDetailView))
                        {
                            AnimateOutCurrentStep(CurrentStepAnimateOut_Completed);
                        }
                    }
                }

                if ((BindingContext as ConfigurationStepViewModel).DetailContentView is Views.ConfigurationStepStartingDetailView)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(((BindingContext as ConfigurationStepViewModel).DetailContentView as Views.ConfigurationStepStartingDetailView).PresentFallbackOptions);
                }

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith(delayTask =>
                {
                    RequestAccountAsync().ContinueWith(RequestAccount_Callback);
                });
            }
            else
            {
                SessionMemoryManager.Instance.Persist();

                SessionManager.Instance.Account = new AccountViewModel
                {
                    Id = task.Result.Id,
                    Name = task.Result.Name,
                    LogoImageSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildLogoUri()),
                    HorizontalSplashImageSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildSplashHorizontalUri()),
                    VerticalSplashImageSource = Xamarin.Forms.ImageSource.FromUri(ImageUriFactory.BuildSplashVerticalUri()),
                    PrimaryColor = Xamarin.Forms.Color.FromHex(task.Result.PrimaryColor),
                    SecoundaryColor = Xamarin.Forms.Color.FromHex(task.Result.SecoundaryColor),
                    DefaultOverlayId = task.Result.DefaultOverlayId,
                    SerializedOverlayContext = task.Result.SerializedOverlayContext,
                    Extensions = task.Result.Extensions
                };                

                if (configurationStepQueue.Count > 1)
                {
                    configurationStepQueue.Dequeue();
                }

                AnimateOutCurrentStep(CurrentStepAnimateOut_Completed);
            }
        }

        private async System.Threading.Tasks.Task<PlayerPlaybackConfigurationModel> RequestPlaybackConfigurationAsyncAsync()
        {
            var client = new Cloud.Api.Connect.Clients.PlayersApiConnectClient(SessionManager.Instance);

            return await client.GetPlaybackConfigurationAsync();
        }

        private async void RequestPlaybackConfiguration_Callback(System.Threading.Tasks.Task<PlayerPlaybackConfigurationModel> task)
        {
            if (task.IsCanceled || task.Exception != null || task.Result == null)
            {
                await System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10));

#pragma warning disable CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
                RequestPlaybackConfigurationAsyncAsync().ContinueWith(RequestPlaybackConfiguration_Callback);
#pragma warning restore CS4014 // Dado que no se esperaba esta llamada, la ejecución del método actual continuará antes de que se complete la llamada
            }
            else
            {
                // MotoTouch does not support dynamic assembly loading
                if (Xamarin.Forms.Device.RuntimePlatform != Xamarin.Forms.Device.iOS)
                {
                    var dynamicLoadExtensions = SessionManager.Instance.Account.Extensions.Where(item => item.Id != EssentialExtensionDescriptor.ID).ToArray();

                    var missingAccountExtensions = new System.Collections.Generic.List<ExtensionDisplayModel>();

                    foreach (var accountExtension in dynamicLoadExtensions)
                    {
                        if (System.IO.Directory.Exists(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Extensions", accountExtension.Id.ToString(), accountExtension.Version))) continue;

                        missingAccountExtensions.Add(accountExtension);
                    }

                    foreach (var missingAccountExtension in missingAccountExtensions)
                    {
                        var extensionDirectoryInfo = new System.IO.DirectoryInfo(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Extensions", missingAccountExtension.Id.ToString(), missingAccountExtension.Version));

                        var tempExtensionDirectoryInfo = new System.IO.DirectoryInfo(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Extensions", missingAccountExtension.Id.ToString(), string.Format("--{0}", missingAccountExtension.Version)));

                        await DownloadAccountExtensionBundleAsync(missingAccountExtension.Id, tempExtensionDirectoryInfo);

                        System.IO.Directory.Move(tempExtensionDirectoryInfo.FullName, extensionDirectoryInfo.FullName);
                    }

                    foreach (var accountExtension in dynamicLoadExtensions)
                    {
                        var extensionDirectoryInfo = new System.IO.DirectoryInfo(System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), "Extensions", accountExtension.Id.ToString(), accountExtension.Version));

                        var extensionLibraryFileInfos = extensionDirectoryInfo.GetFiles();

                        foreach (var extensionLibraryFileInfo in extensionLibraryFileInfos)
                        {
                            var assembly = System.Reflection.Assembly.LoadFrom(extensionLibraryFileInfo.FullName);

                            System.AppDomain.CurrentDomain.Load(assembly.GetName());

                            var attributes = assembly.GetCustomAttributesSafe(typeof(Xamarin.Forms.ExportFontAttribute));

                            if (attributes == null || attributes.Length == 0) continue;

                            var length = attributes.Length;

                            for (var i = 0; i < length; i++)
                            {
                                var a = attributes[i];

                                var attribute = a as Xamarin.Forms.HandlerAttribute;

                                if (attribute == null && (a is Xamarin.Forms.ExportFontAttribute fa))
                                {
                                    Xamarin.Forms.Internals.FontRegistrar.Register(fa, assembly);
                                }
                            }
                        }
                    }
                }

                var placardList = new System.Collections.Generic.List<PlacardViewModel>();

                foreach (var model in task.Result.Placards)
                {
                    var item = model.ToViewModel();

                    var completitionHelper = PlacardViewModelCompletitionHelperProvider.Instance.GetFor(model);

                    if (completitionHelper != null)
                    {
                        await completitionHelper.CompleteAsync(item);
                    }

                    placardList.Add(item);
                }

                placards = placardList.ToArray();
                
                if (task.Result.ScheduledRelaunches.Length > 0)
                {
                    var timeOfDay = System.DateTime.Now.TimeOfDay;

                    var orderScheduledRelaunches = task.Result.ScheduledRelaunches.OrderBy(entity => entity.Time).ToArray();

                    foreach (var item in orderScheduledRelaunches)
                    {
                        if (timeOfDay + ConstantProvider.RELAUNCH_PAUSE_TIME > item.Time) continue;

                        scheduledRelaunche = item;

                        break;
                    }

                    if (scheduledRelaunche == null) scheduledRelaunche = orderScheduledRelaunches[0];
                }

                var ffImageLoadingHttpClient = new System.Net.Http.HttpClient();

                ffImageLoadingHttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(task.Result.AuthenticationType, task.Result.AuthenticationToken);

                FFImageLoading.ImageService.Instance.Initialize(new FFImageLoading.Config.Configuration
                {
                    HttpClient = ffImageLoadingHttpClient
                });

                AnimateOutCurrentStep(CurrentStepAnimateOut_Completed);
            }
        }

        #endregion

        private void ScreenplayPresentIterationComplete_Callback()
        {
            if (scheduledRelaunche == null) return;

            var now = System.DateTime.Now;

            // Same day
            if (now.TimeOfDay >= startUpAt.TimeOfDay)
            {
                var runTimeSpan = now - startUpAt;

                if (runTimeSpan < ConstantProvider.RELAUNCH_PAUSE_TIME) return;

                if (now.TimeOfDay <= scheduledRelaunche.Time) return;

                Xamarin.Forms.DependencyService.Get<IPlatformControlHelperFacade>().Close(true);
            }
            // Other day
            else if (now.DayOfYear > startUpAt.DayOfYear)
            {
                var yesterdayElapsedTime = System.TimeSpan.FromHours(24) - startUpAt.TimeOfDay;

                var runTimeSpan = now.TimeOfDay + yesterdayElapsedTime;

                if (runTimeSpan < ConstantProvider.RELAUNCH_PAUSE_TIME) return;

                if (now.TimeOfDay <= scheduledRelaunche.Time) return;

                Xamarin.Forms.DependencyService.Get<IPlatformControlHelperFacade>().Close(true);
            }
        }

        private void AnimateOutCurrentStep(System.EventHandler completeEventHandler)
        {
            var model = BindingContext as ConfigurationStepViewModel;

            var animationsStoryboard = new Storyboard
            {
                IsParallel = true
            };

            var lastAnimation = new FadeOutAnimation { Target = model.DetailContentView, Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down };

            lastAnimation.Completed += completeEventHandler;

            animationsStoryboard.Animations.Add(new FadeOutAnimation { Target = StepTitleLabel, Direction = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up });
            animationsStoryboard.Animations.Add(lastAnimation);

            animationsStoryboard.Begin();
        }

        private async System.Threading.Tasks.Task DownloadAccountExtensionBundleAsync(System.Guid extensionId, System.IO.DirectoryInfo extensionDirectoryInfo)
        {
            if (!extensionDirectoryInfo.Exists)
            {
                extensionDirectoryInfo.Create();
            }

            var extensionsApiConnectClient = new Cloud.Api.Connect.Clients.ExtensionsApiConnectClient(SessionManager.Instance.HttpClientHelper);

            var extensionBundleModules = await extensionsApiConnectClient.GetPlayerBundleModulesAsync(extensionId);

            foreach (var extensionBundleModule in extensionBundleModules)
            {
                using (var extensionLibraryFileStream = System.IO.File.Create(System.IO.Path.Combine(extensionDirectoryInfo.FullName, extensionBundleModule.FileName)))
                {
                    extensionLibraryFileStream.Write(extensionBundleModule.FileContent, 0, extensionBundleModule.FileContent.Length);

                    extensionLibraryFileStream.Flush();
                }
            }
        }
    }
}
