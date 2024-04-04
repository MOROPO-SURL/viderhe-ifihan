using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page.Popup;
using System.Linq;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Pages.Popup
{
    public partial class PlacardFilterPopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private readonly System.Action<PlacardFilterModel> filterCallbackAction;

        public PlacardFilterPopupPage(PlacardFilterModel filter, System.Action<PlacardFilterModel> filterCallbackAction)
        {
            InitializeComponent();

            this.filterCallbackAction = filterCallbackAction;

            if (filter == null)
            {
                BindingContext = new PlacardFilterPopupPageModel();
            }
            else
            {
                BindingContext = new PlacardFilterPopupPageModel
                {
                    Label = filter.Label
                };

                foreach (var item in filter.Tags)
                {
                    BindingContextPageModel.Tags.Add(item);
                }
            }
        }

        private void AddTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new Support.Presentation.Dashboard.Pages.Popup.TagPickPopupPage(TagGroup.Placard, PickTagSuccess_Callback, BindingContextPageModel.Tags.ToArray()));
        }

        private void RemoveTagButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            DisplayAlert("Quitar Etiqueta", "Está seguro quitar esta etiqueta de los parámetros de filtrado?", "Quitar", "Cancelar").ContinueWith(task =>
            {
                if (!task.Result) return;

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() => BindingContextPageModel.Tags.Remove((sender as Xamarin.Forms.BindableObject).BindingContext as Cloud.Api.Common.Models.TagDisplayModel));
            });
        }

        public void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            filterCallbackAction.Invoke(new PlacardFilterModel
            {
                Label = BindingContextPageModel.Label,
                Tags = BindingContextPageModel.Tags.ToArray()
            });
        }

        private void PickTagSuccess_Callback(Cloud.Api.Common.Models.TagDisplayModel model)
        {
            BindingContextPageModel.Tags.Add(model);
        }

        private PlacardFilterPopupPageModel BindingContextPageModel
        {
            get => BindingContext as PlacardFilterPopupPageModel;
        }
    }
}