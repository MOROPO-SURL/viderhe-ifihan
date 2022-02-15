using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages
{
    [System.ComponentModel.DesignTimeVisible(false)]
    public partial class MainPage : XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.MainPageModel>
    {
        private readonly Models.View.SessionActionViewModel sessionAction;

        public MainPage() : base(new Models.Page.MainPageModel { IsBusy = true })
        {
            sessionAction = new Models.View.SessionActionViewModel
            {
                Kind = Enumerations.ActionKind.SessionDetail,
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
                        Xamarin.Forms.DependencyService.Get<Managers.Facade.IApplicationManagerFacade>().Quit();
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
                    Managers.SessionManager.Instance.SignOut();

                    (Xamarin.Forms.Application.Current as App).PresentForUserAuthentication();
                });
            });
        }

        private void ActionFrame_Tapped(object sender, System.EventArgs eventArgs)
        {
            var action = (sender as Xamarin.Forms.BindableObject).BindingContext as Models.View.ActionViewModel;

            if (!action.Enabled) return;

            switch (action.Kind)
            {
                case Enumerations.ActionKind.ManageImages:
                    this.NavigationPushPageAsync(new ManageImagesPage());

                    break;

                case Enumerations.ActionKind.ManageVideos:
                    this.NavigationPushPageAsync(new ManageVideosPage());

                    break;

                case Enumerations.ActionKind.ManagePlayers:
                    this.NavigationPushPageAsync(new ManagePlayersPage());

                    break;

                case Enumerations.ActionKind.ManageScreenplays:
                    this.NavigationPushPageAsync(new ManageProgrammingPage());

                    break;

                case Enumerations.ActionKind.ConfigAccount:
                    this.NavigationPushPageAsync(new AccountIdentityConfigurationPage());

                    break;

                case Enumerations.ActionKind.ManageExtensions:
                    this.NavigationPushPageAsync(new ManageExtensionsPage());

                    break;

                case Enumerations.ActionKind.ManageModerators:
                    this.NavigationPushPageAsync(new ManageModeratorsPage());

                    break;

                case Enumerations.ActionKind.DashboardHelp:
                    this.NavigationPushPageAsync(new HelpPage());

                    break;

                case Enumerations.ActionKind.SessionDetail:
                    Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Popup.ModeratorDetailPopupPage(sessionAction.Moderator, UserSessionEditRequired_Callback));

                    break;

                case Enumerations.ActionKind.DashboardSettings:
                    this.NavigationPushModalPageAsync(new SettingsPage());

                    break;

                default:
                    DisplayAlert("Aviso", "Sección no disponible para esta versión", "Aceptar");

                    break;
            }
        }

        private void UserSessionEditRequired_Callback(Models.View.ModeratorViewModel target)
        {
            this.NavigationPushPageAsync(new EditUserProfilePage(ConfigureSession));
        }

        public void ConfigureSession()
        {
            sessionAction.Moderator = new Models.View.ModeratorViewModel { Model = Managers.SessionManager.Instance.Moderator };
        }

        private void ReloadActions()
        {
            BindingContextPageModel.Actions.Clear();

            var actions = new Models.View.ActionViewModel[]
            {
                sessionAction,
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ConfigAccount,
                    Caption = "Cuenta",
                    IconGlyph = "\uf0d6",
                    Enabled = Managers.SessionManager.Instance.Moderator.IsPrivileged
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageModerators,
                    Caption = "Control de Acceso",
                    IconGlyph = "\uf848",
                    Enabled = Managers.SessionManager.Instance.Moderator.IsPrivileged
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageExtensions,
                    Caption = "Extensiones",
                    IconGlyph = "\uF431",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageImages,
                    Caption = "Imágenes",
                    IconGlyph = "\uFC69",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageVideos,
                    Caption = "Videos",
                    IconGlyph = "\uF567",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManageScreenplays,
                    Caption = "Programación",
                    IconGlyph = "\uf939",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.ManagePlayers,
                    Caption = "Reproductores",
                    IconGlyph = "\uf448",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.DashboardSettings,
                    Caption = "Ajustes",
                    IconGlyph = "\uf66a",
                    Enabled = true
                },
                new Models.View.ActionViewModel
                {
                    Kind = Enumerations.ActionKind.DashboardHelp,
                    Caption = "Ayuda",
                    IconGlyph = "\uf87d",
                    Enabled = true
                }
            };

            foreach (var item in actions)
            {
                BindingContextPageModel.Actions.Add(item);
            }
        }
    }
}
