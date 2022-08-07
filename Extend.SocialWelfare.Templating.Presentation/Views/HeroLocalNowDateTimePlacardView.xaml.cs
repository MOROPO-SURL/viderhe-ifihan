namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class HeroLocalNowDateTimePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public HeroLocalNowDateTimePlacardView(Models.View.Placard.HeroLocalNowDateTimePlacardViewModel model)
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
    }
}