using MOROPO.VIDERHE.Support.Extend.Management.Presentation.Helpers.Provisioning;
using MOROPO.VIDERHE.Support.Extend.Management.Providers;
using MOROPO.VIDERHE.Terminal.Dashboard.Enumerations;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers;
using MOROPO.VIDERHE.Terminal.Dashboard.Managers.Facade;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages
{
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class MainPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<MainPageModel>
    {
        private readonly SessionActionViewModel sessionAction;

        public MainPage() : base(new MainPageModel { IsBusy = true })
        {
            sessionAction = new SessionActionViewModel
            {
                Kind = ActionKind.SessionDetail,
                Enabled = true
            };

            InitializeComponent();

            ConfigureSession();

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            ReloadActions();

            BindingContextPageModel.IsBusy = false;

            IsEnabled = true;
        }

        protected override bool OnBackButtonPressed()
        {
            DisplayAlert("Aviso", "Está seguro que desea salir de la aplicación?", "Salir", "Cancelar").ContinueWith(task =>
            {
                if (task.Result)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        Xamarin.Forms.DependencyService.Get<IApplicationManagerFacade>().Quit();
                    });
                }
            });

            return true;
        }

        private void SignOutToolbarItem_Activated(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Confirmar", "Esta seguro que desea terminar la sesión?", "Cerrar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    SessionManager.Instance.SignOut();

                    (Xamarin.Forms.Application.Current as App).PresentForUserAuthentication();
                });
            });
        }

        private void ActionFrame_Tapped(object sender, System.EventArgs eventArgs)
        {
            var action = (sender as Xamarin.Forms.BindableObject).BindingContext as ActionViewModel;

            if (!action.Enabled) return;

            if (action is ManagementActionViewModel)
            {
                var managementSectionPage = ManagementSectionProvisioningHelper.Instance.GetFor((action as ManagementActionViewModel).Section);

                this.NavigationPushPageAsync(managementSectionPage);

                return;
            }

            switch (action.Kind)
            {
                case ActionKind.ManageImages:
                    this.NavigationPushPageAsync(new ManageImagesPage());

                    break;

                case ActionKind.ManageVideos:
                    this.NavigationPushPageAsync(new ManageVideosPage());

                    break;

                case ActionKind.ManagePlayers:
                    this.NavigationPushPageAsync(new ManagePlayersPage());

                    break;

                case ActionKind.ManageScreenplays:
                    this.NavigationPushPageAsync(new ManageProgrammingPage());

                    break;

                case ActionKind.ConfigAccount:
                    this.NavigationPushPageAsync(new AccountIdentityConfigurationPage());

                    break;

                case ActionKind.ManageExtensions:
                    this.NavigationPushPageAsync(new ManageExtensionsPage());

                    break;

                case ActionKind.ManageModerators:
                    this.NavigationPushPageAsync(new ManageModeratorsPage());

                    break;

                case ActionKind.DashboardHelp:
                    this.NavigationPushPageAsync(new HelpPage());

                    break;

                case ActionKind.SessionDetail:
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.ModeratorDetailPopupPage(sessionAction.Moderator, UserSessionEditRequired_Callback));

                    break;

                case ActionKind.DashboardSettings:
                    this.NavigationPushModalPageAsync(new SettingsPage());

                    break;

                case ActionKind.ManageGradients:
                    this.NavigationPushPageAsync(new ManageGradientsPage());

                    break;

                case ActionKind.ManageSounds:
                    this.NavigationPushPageAsync(new ManageSoundsPage());

                    break;

                case ActionKind.ManageTexts:
                    this.NavigationPushPageAsync(new ManageTextsPage());

                    break;

                case ActionKind.ManageTags:
                    this.NavigationPushPageAsync(new ManageTagsPage());

                    break;

                default:
                    DisplayAlert("Aviso", "Sección no disponible para esta versión", "Aceptar");

                    break;
            }
        }

        private void UserSessionEditRequired_Callback(ModeratorViewModel target)
        {
            this.NavigationPushPageAsync(new EditUserProfilePage(ConfigureSession));
        }

        public void ConfigureSession()
        {
            sessionAction.Moderator = new Models.View.ModeratorViewModel { Model = SessionManager.Instance.Moderator };
        }

        private void ReloadActions()
        {
            BindingContextPageModel.Actions.Clear();

            var actions = new System.Collections.Generic.List<ActionViewModel>
            {
                sessionAction,
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ConfigAccount,
                    Caption = "Cuenta",
                    IconGlyph = "\uf0d6",
                    Enabled = SessionManager.Instance.Moderator.IsPrivileged
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageModerators,
                    Caption = "Control de Acceso",
                    IconGlyph = "\uf848",
                    Enabled = SessionManager.Instance.Moderator.IsPrivileged
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageExtensions,
                    Caption = "Extensiones",
                    IconGlyph = "\uF431",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageImages,
                    Caption = "Imágenes",
                    IconGlyph = "\uFC69",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageGradients,
                    Caption = "Gradientes",
                    IconGlyph = "\uF69F",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageVideos,
                    Caption = "Videos",
                    IconGlyph = "\uF567",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageSounds,
                    Caption = "Audios",
                    IconGlyph = "\uF759",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageTexts,
                    Caption = "Textos",
                    IconGlyph = "\uFB53",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageTags,
                    Caption = "Etiquetas",
                    IconGlyph = "\uF4F9",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManageScreenplays,
                    Caption = "Programación",
                    IconGlyph = "\uf939",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = ActionKind.ManagePlayers,
                    Caption = "Reproductores",
                    IconGlyph = "\uf448",
                    Enabled = true
                }
            };

            var managementSections = ManagementSectionProvider.Instance.GetAll();

            foreach (var item in managementSections)
            {
                actions.Add(new Models.View.ManagementActionViewModel(item));
            }

            actions.Add(new Models.View.ActionViewModel
            {
                Kind = ActionKind.DashboardSettings,
                Caption = "Ajustes",
                IconGlyph = "\uf66a",
                // TODO Restore to spected behavior!!
                Enabled = false
            });
            actions.Add(new Models.View.ActionViewModel
            {
                Kind = ActionKind.DashboardHelp,
                Caption = "Ayuda",
                IconGlyph = "\uf87d",
                // TODO Restore to spected behavior!!
                Enabled = false
            });

            foreach (var item in actions)
            {
                BindingContextPageModel.Actions.Add(item);
            }
        }
    }
}
