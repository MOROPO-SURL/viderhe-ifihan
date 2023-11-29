using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Pages.Popup
{
    public partial class FilterPlayerPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly System.Action<PlayerFilterModel> filterCallbackAction;

        public FilterPlayerPopupPage(PlayerFilterModel filter, System.Action<PlayerFilterModel> filterCallbackAction)
        {
            InitializeComponent();

            this.filterCallbackAction = filterCallbackAction;

            if (filter == null)
            {
                BindingContext = new Models.Page.FilterPlayerPopupPageModel();
            }
            else
            {
                BindingContext = new Models.Page.FilterPlayerPopupPageModel
                {
                    Name = filter.Name
                };

                foreach (var item in filter.Tags)
                {
                    BindingContextPageModel.Tags.Add(item);
                }
            }
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(TagGroup.Player, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de este reproductor?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as TagDisplayModel));
            });
        }

        public void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            filterCallbackAction.Invoke(new Cloud.Api.Common.Models.Filter.PlayerFilterModel
            {
                Name = BindingContextPageModel.Name,
                Tags = BindingContextPageModel.Tags.ToArray()
            });
        }

        private void PickTagSuccess_Callback(TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private Models.Page.FilterPlayerPopupPageModel BindingContextPageModel
        {
            get => BindingContext as Models.Page.FilterPlayerPopupPageModel;
        }
    }
}