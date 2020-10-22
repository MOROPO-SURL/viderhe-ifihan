namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Views
{
    public partial class FloatLeftDetailedHorizontalPhotoEventPlacardView : Common.Presentation.Views.BasePlacardPresentationView
    {
        public FloatLeftDetailedHorizontalPhotoEventPlacardView(Models.View.PhotoEventPlacardViewModel model, Common.Presentation.Providers.Facade.IAccountInformationProviderFacade accountInformationProvider)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayoutView;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void ShowInTransitionCompleteCallback()
        {
            base.ShowInTransitionCompleteCallback();

            if ((BindingContext as Models.View.PhotoEventPlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            Xamarin.Forms.Device.StartTimer((BindingContext as Models.View.PhotoEventPlacardViewModel).ScreenPresentationTime, () =>
            {
                EndPresentation();

                return true;
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            EventImage.Source = null;
        }
    }
}