using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Models.View.Placard;
using MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Views.Background;

namespace MOROPO.VIDERHE.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class HeroLocalNowDateTimePlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        public HeroLocalNowDateTimePlacardView(HeroLocalNowDateTimePlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            BindingContext = model;

            if (model.TextFontFamily != null)
            {
                DayOWeekLabel.FontFamily = model.TextFontFamily;
                MonthAndDayLabel.FontFamily = model.TextFontFamily;
                TimeLabel.FontFamily = model.TextFontFamily;
            }    

            var now = System.DateTime.Now;

            DayOWeekLabel.Text = now.ToString("dddd", model.Culture).ToUpper();
            MonthAndDayLabel.Text = now.ToString("MMMM dd", model.Culture).ToUpper();
            TimeLabel.Text = now.ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);

            DayOWeekLabel.Opacity = 0;
            MonthAndDayLabel.Opacity = 0;
            TimeLabel.Opacity = 0;
            SeparatorBoxView.Opacity = 0;
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

            DayOWeekLabel.TranslationX = MonthAndDayLabel.TranslationX = (DayOWeekLabel.Parent as Xamarin.Forms.View).Width;
            TimeLabel.TranslationX = (TimeLabel.Parent as Xamarin.Forms.View).Width * -1;
            DayOWeekLabel.Opacity = 1;
            MonthAndDayLabel.Opacity = 1;
            TimeLabel.Opacity = 1;

            var showInStoryboard = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.Storyboard
            {
                IsParallel = true
            };

            showInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.FadeToAnimation
            {
                Target = SeparatorBoxView,
                Opacity = 1,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicIn,
                Duration = "600"
            });

            showInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = DayOWeekLabel,
                TranslateX = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = "700",
                Delay = "900"
            });
            showInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = MonthAndDayLabel,
                TranslateX = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = "700",
                Delay = "1200"
            });
            showInStoryboard.Animations.Add(new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToXAnimation
            {
                Target = TimeLabel,
                TranslateX = 0,
                EasingType = SmartSolucionesCuba.XFToolKit.Presentation.Transform.Enumerations.EasingType.CubicOut,
                Duration = "700",
                Delay = "1500"
            });

            showInStoryboard.Begin();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if (BackgroundContentView.Content is ImageBackgroundView)
            {
                (BackgroundContentView.Content as ImageBackgroundView).Source = null;
            }
            else if (BackgroundContentView.Content is GradientBackgroundView)
            {
                (BackgroundContentView.Content as GradientBackgroundView).GradientSource = null;
            }
        }
    }
}