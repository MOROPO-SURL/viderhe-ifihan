namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class ResponsivePicturePlacardView : Common.Presentation.Views.BasePlacardPresentationView
    {
        public ResponsivePicturePlacardView(Models.View.ResponsivePicturePlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            InitializeComponent();

            PlacardLayout.BackgroundColor = accountInformationProvider.PrimaryColor;

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void ShowInTransitionCompleteCallback()
        {
            base.ShowInTransitionCompleteCallback();

            if ((BindingContext as Models.View.ResponsivePicturePlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            Xamarin.Forms.Device.StartTimer((BindingContext as Models.View.ResponsivePicturePlacardViewModel).ScreenPresentationTime, () =>
            {
                EndPresentation();

                return true;
            });
        }
    }
}