namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class InmersiveCityWeatherOverviewView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public InmersiveCityWeatherOverviewView(Models.View.InmersiveCityWeatherOverviewViewModel model)
        {
            InitializeComponent();

            BindingContext = model;
        }

        public override Xamarin.Forms.Layout<Xamarin.Forms.View> WrapLayout => Wrapper;

        public override Xamarin.Forms.View PlacardView => PlacardLayout;

        public override void ConfigureLayout(Xamarin.Forms.View view)
        {
            Xamarin.Forms.Grid.SetColumn(view, 0);
            Xamarin.Forms.Grid.SetRow(view, 0);
        }

        public override void PerformPlacardStarup()
        {
            base.PerformPlacardStarup();

            // TODO Connect to Viderhe Weather Micro Service API!
        }
    }
}