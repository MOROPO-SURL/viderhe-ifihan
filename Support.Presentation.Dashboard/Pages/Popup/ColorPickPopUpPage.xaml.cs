using MOROPO.VIDERHE.Support.Presentation.Dashboard.Extensions;

namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Pages.Popup
{
    public partial class ColorPickPopUpPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        private const string RECENT_PICKED_COLORS = "recent-picked-colors";

        private readonly System.Action<Xamarin.Forms.Color> pickCallbackAction;

        public ColorPickPopUpPage(System.Action<Xamarin.Forms.Color> pickCallbackAction, Xamarin.Forms.Color start)
        {
            this.pickCallbackAction = pickCallbackAction;

            InitializeComponent();

            BindingContext = new Models.Page.ColorPickPopUpPageModel
            {
                InColor = start,
                OutColor = start
            };

            PresentColorValues();
        }

        private Models.Page.ColorPickPopUpPageModel BindingContextModel => BindingContext as Models.Page.ColorPickPopUpPageModel;

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(RECENT_PICKED_COLORS))
            {
                var recentPickedColorListSerialization = Xamarin.Forms.Application.Current.Properties[RECENT_PICKED_COLORS] as string;

                var recentPickedHexColors = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(recentPickedColorListSerialization);

                foreach (var item in recentPickedHexColors)
                {
                    BindingContextModel.Recents.Add(Xamarin.Forms.Color.FromHex(item));
                }
            }
        }

        public void CloseButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();
        }

        public void ApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            var outColor = BindingContextModel.OutColor;

            var recentPickedHexColors = new System.Collections.Generic.List<string> { outColor.ToHex() };

            var count = 1;

            foreach (var item in BindingContextModel.Recents)
            {
                if (item == outColor) continue;

                recentPickedHexColors.Add(item.ToHex());

                count++;

                if (count >= 12) break;
            }

            Xamarin.Forms.Application.Current.Properties[RECENT_PICKED_COLORS] = Newtonsoft.Json.JsonConvert.SerializeObject(recentPickedHexColors.ToArray());

            Xamarin.Forms.Application.Current.SavePropertiesAsync();

            Rg.Plugins.Popup.Services.PopupNavigation.Instance.PopAsync();

            pickCallbackAction.Invoke(outColor);
        }

        private void ColorWheel_SelectedColorChanged(object sender, ColorPicker.BaseClasses.ColorPickerEventArgs.ColorChangedEventArgs eventArgs)
        {
            PresentColorValues();
        }

        private void OutColorHexApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!(sender as Xamarin.Forms.VisualElement).IsEnabled) return;

            var resultColor = Xamarin.Forms.Color.FromHex(OutColorHexEntry.Text);

            if (resultColor == Xamarin.Forms.Color.Default) return;

            BindingContextModel.OutColor = Xamarin.Forms.Color.FromRgb(resultColor.R, resultColor.G, resultColor.B);

            PresentColorValues();
        }

        private void OutColorRGBApplyButton_Clicked(object sender, System.EventArgs eventArgs)
        {
            if (!(sender as Xamarin.Forms.VisualElement).IsEnabled) return;

            BindingContextModel.OutColor = Xamarin.Forms.Color.FromRgb(StringToChannel(OutColorRedEntry.Text), StringToChannel(OutColorGreenEntry.Text), StringToChannel(OutColorBlueEntry.Text));

            PresentColorValues();
        }

        private void ColorBoxViewTapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            BindingContextModel.OutColor = (sender as Xamarin.Forms.BoxView).Color;
        }

        private void PresentColorValues()
        {
            OutColorHexEntry.IsEnabled = false;
            OutColorRedEntry.IsEnabled = false;
            OutColorGreenEntry.IsEnabled = false;
            OutColorBlueEntry.IsEnabled = false;

            OutColorHexEntry.Text = BindingContextModel.OutColor.ToSolidHex().Substring(1);
            OutColorRedEntry.Text = $"{System.Math.Floor(BindingContextModel.OutColor.R * 255)}";
            OutColorGreenEntry.Text = $"{System.Math.Floor(BindingContextModel.OutColor.G * 255)}";
            OutColorBlueEntry.Text = $"{System.Math.Floor(BindingContextModel.OutColor.B * 255)}";

            OutColorHexEntry.IsEnabled = true;
            OutColorRedEntry.IsEnabled = true;
            OutColorGreenEntry.IsEnabled = true;
            OutColorBlueEntry.IsEnabled = true;
        }

        private int StringToChannel(string channelStr)
        {
            if (int.TryParse(channelStr, out var ch))
            {
                return ch;
            }

            return 0;
        }
    }
}