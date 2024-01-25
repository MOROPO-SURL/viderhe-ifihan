using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Factories;
using MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Managers;
using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Management.Dashboard.Presentation.Pages
{
    public partial class AVProductionGeneralDefinitionPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.BindingContextedContentPage<Models.Page.AVProductionGeneralDefinitionPageModel>, Support.Presentation.Dashboard.Pages.Contract.IValidableFormPage
    {
        private readonly System.Action definitionCallbackAction;
        private readonly Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target;

        private readonly System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior> validationBehaviors;

        private readonly bool isEditionMode;

        private bool hasChangesFlag;

        public AVProductionGeneralDefinitionPage(System.Action definitionCallbackAction, Service.Hotel.OTT.API.Common.Models.AVProductionDisplayModel target = null) : base(AVProductionDefinitionPageModelFactory.Build(target))
        {
            validationBehaviors = new System.Collections.Generic.List<Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior>();

            InitializeComponent();

            this.target = target;
            this.definitionCallbackAction = definitionCallbackAction;

            if (target != null)
            {
                isEditionMode = true;
                Title = "Generales";
            }

            IsEnabled = false;
        }            

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (IsEnabled) return;

            BindingContextPageModel.IsBusy = true;

            System.Threading.Tasks.Task.Run(async () =>
            {
                var categoryAPIConnectClient = new Service.Hotel.OTT.API.Connect.Clients.AVCategoriesAPIConnectClient(SessionManager.Instance);

                var availableCategories = await categoryAPIConnectClient.GetAsync();

                var countriesAPIConnectClient = new Service.Hotel.OTT.API.Connect.Clients.CountriesAPIConnectClient(SessionManager.Instance);

                var availableCountries = await countriesAPIConnectClient.GetAsync();

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    var index = -1;

                    foreach (var item in availableCategories)
                    {
                        BindingContextPageModel.AvailableCategories.Add(item);

                        index++;

                        if (isEditionMode && CategoryPicker.SelectedIndex == -1 && item.Id == target.Category.Id)
                        {
                            CategoryPicker.SelectedIndex = index;
                        }
                    }

                    //BindingContextPageModel.Category = target?.Category;

                    index = 0;

                    foreach (var item in availableCountries)
                    {
                        BindingContextPageModel.AvailableCountries.Add(item);

                        index++;
                        
                        if (isEditionMode && CountryPicker.SelectedIndex == -1 && item.Id == target.Country.Id)
                        {
                            CountryPicker.SelectedIndex = index;
                        }
                    }

                    //BindingContextPageModel.Country = target?.Country;
                });
            }).ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        BindingContextPageModel.IsBusy = false;

                        BindingContextPageModel.PropertyChanged += PageModel_PropertyChanged;
                    }
                    else
                    {
                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception, () =>
                        {
                            this.NavigationPopPageAsync();
                        });
                    }
                });
            });

            IsEnabled = true;
        }

        protected override bool OnBackButtonPressed()
        {
            CancelToolbarItem_Clicked(this, System.EventArgs.Empty);

            return true;
        }

        private void PageModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            hasChangesFlag = true;
        }

        private void ApplyToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (BindingContextPageModel.IsBusy) return;

            BindingContextPageModel.ResetValidationState();

            foreach (var validationBehavior in validationBehaviors)
            {
                if (!validationBehavior.Target.IsEnabled) continue;

                var result = validationBehavior.Evaluate();

                if (!BindingContextPageModel.IsValid) continue;

                if (!result) BindingContextPageModel.IsValid = false;
            }

            if (!BindingContextPageModel.IsValid) return;

            BindingContextPageModel.IsBusy = true;

            var model = new Service.Hotel.OTT.API.Common.Models.AVProductionInputModel
            {
                Id = BindingContextPageModel.Id,
                Title = BindingContextPageModel.Title,
                About = BindingContextPageModel.About,
                AgeEdge = BindingContextPageModel.AgeEdge,
                Argument = BindingContextPageModel.Argument,
                CategoryId = BindingContextPageModel.Category.Id,
                CountryId = BindingContextPageModel.Country.Id,
                Duration = (int)BindingContextPageModel.Duration.TotalSeconds,
                Enabled = BindingContextPageModel.Enabled,
                Language = BindingContextPageModel.Language,
                Rate = BindingContextPageModel.Rate,
                Year = BindingContextPageModel.Year,
                Countries = BindingContextPageModel.Countries.ToArray(),
                ProducerHouses = BindingContextPageModel.ProducerHouses.ToArray(),
                Genres = BindingContextPageModel.Genres.ToArray()
            };

            var apiConnectClient = new Service.Hotel.OTT.API.Connect.Clients.AVProductionsAPIConnectClient(SessionManager.Instance);

            var apiConnectClientTask = isEditionMode ? apiConnectClient.EditAsync(model) : apiConnectClient.CreateAsync(model);

            apiConnectClientTask.ContinueWith(task =>
            {
                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    if (task.Exception == null && !task.IsCanceled)
                    {
                        Xamarin.Forms.DependencyService.Get<Support.Presentation.Dashboard.Presenters.Facade.INotificationPresenterFacade>().PresentNotification("Información", "Cambios aplicados con éxito.");

                        this.NavigationPopPageAsync();

                        definitionCallbackAction.Invoke();
                    }
                    else
                    {
                        BindingContextPageModel.IsBusy = false;

                        (Xamarin.Forms.Application.Current as Support.Presentation.Helpers.Facade.IExceptionHandleHelperFacade).HandleException(task.Exception);
                    }
                });
            });
        }

        private void CancelToolbarItem_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!hasChangesFlag)
            {
                this.NavigationPopPageAsync();

                return;
            }

            DisplayAlert("Confirmar", "Está seguro que desea regresar sin guardar los cambios?", "Regresar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    this.NavigationPopPageAsync();
                });
            });
        }

        #region IValidableFormPage implementation

        public void AddValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Add(validationBehavior);
        }

        public void RemoveValidationBehavior(Support.Presentation.Dashboard.Behaviors.Contract.IFormFieldValidationBehavior validationBehavior)
        {
            validationBehaviors.Remove(validationBehavior);
        }

        public void AddValidationMessage(string label, string message)
        {
            BindingContextPageModel.ValidationMessages.Add(new Support.Presentation.Dashboard.Models.View.ValidationMessageViewModel
            {
                Caption = label,
                Message = message
            });
        }

        #endregion
    }
}