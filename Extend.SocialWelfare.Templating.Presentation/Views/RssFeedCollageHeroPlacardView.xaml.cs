using SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Extensions;
using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Presentation.Views
{
    public partial class RssFeedCollageHeroPlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private Models.Context.RssFeedCollageHeroContextModel placardContext;

        public RssFeedCollageHeroPlacardView(Models.Context.RssFeedCollageHeroContextModel model)
        {
            InitializeComponent();

            placardContext = model;

            BindingContext = new Models.View.RssFeedCollageHeroPlacardViewModel
            {
                ScreenPresentationTime = model.ScreenPresentationTime,
                RequireUnobstructedPresetation = model.RequireUnobstructedPresetation,
                IsBusy = true,
                TintColor = Xamarin.Forms.Color.FromHex(model.TintColor)
            };
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

            var concreteBindingContextModel = BindingContext as Models.View.RssFeedCollageHeroPlacardViewModel;

            CodeHollow.FeedReader.FeedReader.ReadAsync(placardContext.FeedUrl).ContinueWith(task =>
            {
                if (task.IsCanceled || task.Exception != null || task.Result.Items.Count <= 0)
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        EndPresentation();
                    });

                    return;
                }

                Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                {
                    concreteBindingContextModel.FeedTitle = task.Result.Title;
                    concreteBindingContextModel.FeedDescription = task.Result.Description;
                    concreteBindingContextModel.FeedLastUpdatedDateString = task.Result.LastUpdatedDateString;
                    concreteBindingContextModel.FeedImageSource = task.Result.ImageUrl == null ? null : Xamarin.Forms.ImageSource.FromUri(new System.Uri(task.Result.ImageUrl));

                    concreteBindingContextModel.HeroFeedItem = task.Result.Items.ElementAt(0).ToRssFeedItemViewModel();

                    if (task.Result.Items.Count > 1)
                    {
                        concreteBindingContextModel.SecoundFeedItem = task.Result.Items.ElementAt(1).ToRssFeedItemViewModel();

                        if (task.Result.Items.Count > 2)
                        {
                            concreteBindingContextModel.ThirdFeedItem = task.Result.Items.ElementAt(2).ToRssFeedItemViewModel();

                            if (task.Result.Items.Count > 3)
                            {
                                concreteBindingContextModel.FourthFeedItem = task.Result.Items.ElementAt(3).ToRssFeedItemViewModel();
                            }
                        }
                    }

                    concreteBindingContextModel.IsBusy = false;
                });
            });
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            placardContext = null;

            var concreteBindingContextModel = BindingContext as Models.View.RssFeedCollageHeroPlacardViewModel;

            concreteBindingContextModel.FeedImageSource = null;
            concreteBindingContextModel.HeroFeedItem = null;
            concreteBindingContextModel.SecoundFeedItem = null;
            concreteBindingContextModel.ThirdFeedItem = null;
            concreteBindingContextModel.FourthFeedItem = null;
        }
    }
}