using SmartSolucionesCuba.Videre.Support.Presentation.Extensions;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations;
using System.Linq;

namespace SmartSolucionesCuba.Videre.Terminal.Player.Pages
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class MainPage : Xamarin.Forms.ContentPage
    {
        private System.Collections.Generic.List<Support.Presentation.Models.View.PlacardViewModel> Placards { get; set; }

        private readonly System.Collections.Generic.Queue<Enumerations.ConfigurationStep> configurationStepQueue;

        private Extend.Common.Overlaying.Presentation.Views.BaseOverlayView overlayView;

        public MainPage()
        {
            InitializeComponent();

            configurationStepQueue = new System.Collections.Generic.Queue<Enumerations.ConfigurationStep>();

            IsEnabled = false;

            InitializeSteps();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (!IsEnabled)
            {
                PresentNextConfigurationStep();
            }

            IsEnabled = true;
        }

        private void InitializeSteps()
        {
            if (Placards == null)
            {
                configurationStepQueue.Enqueue(Enumerations.ConfigurationStep.Starting);
                configurationStepQueue.Enqueue(Enumerations.ConfigurationStep.PlayerRegistration);
            }

            configurationStepQueue.Enqueue(Enumerations.ConfigurationStep.ScreenplayFetch);
        }

        private void PresentNextConfigurationStep()
        {
            if (configurationStepQueue.Count <= 0)
            {
                System.Threading.Tasks.Task.Run(() =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        overlayView = new Extend.Essential.Overlaying.Presentation.Views.SimpleHighlightsOverlayView(new Extend.Common.Overlaying.Presentation.Models.View.HighlightsViewModel { Header = Providers.AccountInformationProvider.Instance.Name, Highlights = "Fallece el destacado realizador y crítico de cine Enrique Colina || Eliminación de remesas, un golpe de Trump a la familia cubana || Equipo Cuba 1 de ajedrez marcha en cuarta posición del Mundial Universitario Online || En el municipio pinareño de Guane se arrecia la batalla contra la COVID- 19 || Enfrentan atípica cosecha de café en Granma || Aeropuerto de Holguín reiniciará operaciones aéreas el 3 de noviembre" });

                        var screenplayPlayerPage = new Support.Presentation.Player.Pages.ScreenplayPlayerPage(Placards.ToArray(), ScreenplayPresentationCompleteCallback, true, Providers.AccountInformationProvider.Instance, Managers.ConfigurationManager.Instance, PlacardPlayingCallback, overlayView, PlacardViewTransitionCompleteCallback)
                        {
                            BackgroundColor = Managers.SessionManager.Instance.AccountPrimaryColor,
                            BindingContext = Managers.SessionManager.Instance.AccountSplashImageSource
                        };

                        this.NavigationPushModalPageAsync(screenplayPlayerPage);

                        Hubs.Client.PlayerHubClient.Instance.GetReady();
                    });
                });

                return;
            }

            var configurationStep = configurationStepQueue.Dequeue();

            Models.View.ConfigurationStepViewModel model = null;

            switch (configurationStep)
            {
                case Enumerations.ConfigurationStep.PlayerRegistration:
                    model = new Models.View.ConfigurationStepViewModel
                    {
                        Title = "Registro",
                        DetailContentView = new Views.ConfigurationStepPlayerRegistrationDetailView()
                    };

                    break;
                case Enumerations.ConfigurationStep.ScreenplayFetch:
                    model = new Models.View.ConfigurationStepViewModel
                    {
                        Title = "Sincronización",
                        DetailContentView = new Views.ConfigurationStepScreenplayFetchingDetailView()
                    };

                    break;
                case Enumerations.ConfigurationStep.Starting:
                default:
                    model = new Models.View.ConfigurationStepViewModel
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

            storyboard.Animations.Add(new FadeInAnimation { Target = StepTitleLabel, Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down });
            storyboard.Animations.Add(new FadeInAnimation { Target = model.DetailContentView, Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up });

            Models.View.ConfigurationStepViewModel completedConfigurationStepModel = null;

            if (BindingContext != null)
            {
                completedConfigurationStepModel = BindingContext as Models.View.ConfigurationStepViewModel;
            }

            BindingContext = model;

            completedConfigurationStepModel?.Dispose();

            if (configurationStep == Enumerations.ConfigurationStep.Starting)
            {
                storyboard.Animations.Add(new FadeToAnimation { Target = ProductIdentityContainer, Opacity = 1 });
                storyboard.Animations.Add(new FadeToAnimation { Target = CurrentTaskProgressBar, Opacity = 1 });

                System.Threading.Tasks.Task.Run(async () =>
                {
                    await storyboard.Begin();

                    await System.Threading.Tasks.Task.Delay(3000);

                    await RequestAccountAsync().ContinueWith(OnRequestAccountCallback);
                });
            }
            else if (configurationStep == Enumerations.ConfigurationStep.PlayerRegistration)
            {
                storyboard.Begin();
            }
            else if (configurationStep == Enumerations.ConfigurationStep.ScreenplayFetch)
            {
                System.Threading.Tasks.Task.Run(async () =>
                {
                    await storyboard.Begin();

                    await System.Threading.Tasks.Task.Delay(3000);

                    await RequestScreenplayPlacardsAsync().ContinueWith(OnRequestScreenplayPlacardsCallback);
                });
            }
        }

        private void CurentStepAnimateOut_Completed(object sender, System.EventArgs eventArgs)
        {
            (sender as AbstractAnimation).Completed -= CurentStepAnimateOut_Completed;

            System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(1)).ContinueWith((System.Threading.Tasks.Task task) =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(PresentNextConfigurationStep);
            });
        }

        private void ScreenplayPresentationCompleteCallback()
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

        private void PlacardPlayingCallback(System.Guid placardId)
        {
            Hubs.Client.PlayerHubClient.Instance.NotifyPlayingPlacard(placardId);
        }

        private void PlacardViewTransitionCompleteCallback(Extend.Common.Presentation.Views.BasePlacardPresentationView incomingPlacardView, Extend.Common.Presentation.Views.BasePlacardPresentationView outgingPlacardView)
        {
            var incomingPlacardViewContext = incomingPlacardView.BindingContext as Extend.Common.Templating.Presentation.Models.View.AbstractPlacardViewModel;

            if (!(outgingPlacardView?.BindingContext is Extend.Common.Templating.Presentation.Models.View.AbstractPlacardViewModel outgoingPlacardViewContext))
            {
                if (incomingPlacardViewContext.RequireUnobstructedPresetation)
                {
                    overlayView.ShowOut();
                }
            }
            else if (incomingPlacardViewContext.RequireUnobstructedPresetation != outgoingPlacardViewContext.RequireUnobstructedPresetation)
            {
                if (incomingPlacardViewContext.RequireUnobstructedPresetation)
                {
                    overlayView.ShowOut();
                }
                else
                {
                    overlayView.ShowIn();
                }
            }
        }

        #region Api Interaction Tasks and Callbacks

        private async System.Threading.Tasks.Task<Cloud.Api.Common.Models.AccountDisplayModel> RequestAccountAsync()
        {
            var client = new Cloud.Api.Connect.Clients.PlayersApiClient(Managers.SessionManager.Instance);

            return await client.GetAccountAsync();
        }

        private void OnRequestAccountCallback(System.Threading.Tasks.Task<Cloud.Api.Common.Models.AccountDisplayModel> task)
        {
            if (task.Exception != null)
            {
                System.Exception targetException = task.Exception;

                while (targetException is System.AggregateException)
                {
                    targetException = targetException.InnerException;
                }

                if (targetException is SAPRESSC.Core.Api.Connect.UnspectedHttpStatusException && (targetException as SAPRESSC.Core.Api.Connect.UnspectedHttpStatusException).HttpStatusCode == System.Net.HttpStatusCode.Forbidden)
                {
                    if (!((BindingContext as Models.View.ConfigurationStepViewModel).DetailContentView is Views.ConfigurationStepPlayerRegistrationDetailView))
                    {
                        AnimateOutCurrentStep(CurentStepAnimateOut_Completed);
                    }
                }

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith((System.Threading.Tasks.Task delayTask) =>
                {
                    RequestAccountAsync().ContinueWith(OnRequestAccountCallback);
                });
            }
            else
            {
                Managers.SessionManager.Instance.AccountId = task.Result.Id;
                Managers.SessionManager.Instance.AccountName = task.Result.Name;
                Managers.SessionManager.Instance.AccountLogoImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Managers.ConfigurationManager.Instance, task.Result.LogoImageId));
                Managers.SessionManager.Instance.AccountSplashImageSource = Xamarin.Forms.ImageSource.FromUri(Support.Presentation.Factories.ImageUriFactory.BuildImageUri(Managers.ConfigurationManager.Instance, task.Result.SplashImageId));
                Managers.SessionManager.Instance.AccountPrimaryColor = Xamarin.Forms.Color.FromHex(task.Result.PrimaryColor);
                Managers.SessionManager.Instance.AccountSecoundaryColor = Xamarin.Forms.Color.FromHex(task.Result.SecoundaryColor);

                if (configurationStepQueue.Count > 1)
                {
                    configurationStepQueue.Dequeue();
                }

                AnimateOutCurrentStep(CurentStepAnimateOut_Completed);
            }
        }

        private async System.Threading.Tasks.Task<Cloud.Api.Common.Models.PlacardDisplayModel[]> RequestScreenplayPlacardsAsync()
        {
            var client = new Cloud.Api.Connect.Clients.PlayersApiClient(Managers.SessionManager.Instance);

            return await client.GetScreenplayPlacardsAsync();
        }

        private void OnRequestScreenplayPlacardsCallback(System.Threading.Tasks.Task<Cloud.Api.Common.Models.PlacardDisplayModel[]> task)
        {
            if (task.Exception != null || task.Result == null || task.Result.Count() <= 0)
            {
                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(10)).ContinueWith((System.Threading.Tasks.Task delayTask) =>
                {
                    RequestScreenplayPlacardsAsync().ContinueWith(OnRequestScreenplayPlacardsCallback);
                });
            }
            else
            {
                Placards = task.Result.Select(m => m.ToViewModel()).ToList();

                AnimateOutCurrentStep(CurentStepAnimateOut_Completed);
            }
        }

        #endregion

        private void AnimateOutCurrentStep(System.EventHandler completeEventHandler)
        {
            var model = BindingContext as Models.View.ConfigurationStepViewModel;

            var animationsStoryboard = new Storyboard
            {
                IsParallel = true
            };

            var lastAnimation = new FadeOutAnimation { Target = model.DetailContentView, Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Up };

            lastAnimation.Completed += completeEventHandler;

            animationsStoryboard.Animations.Add(new FadeOutAnimation { Target = StepTitleLabel, Direction = XFToolKit.Presentation.Transform.Enumerations.FadeDirection.Down });
            animationsStoryboard.Animations.Add(lastAnimation);

            animationsStoryboard.Begin();
        }
    }
}
