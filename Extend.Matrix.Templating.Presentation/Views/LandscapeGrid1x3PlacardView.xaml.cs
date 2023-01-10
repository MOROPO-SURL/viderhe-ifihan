using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Presenters;
using SmartSolucionesCuba.Viderhe.Support.Extend.Transitioning.Presentation.Providers;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid1x3PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfThreeScreenplayPresenter;

        private ScreenplayPresenter twoOfThreeScreenplayPresenter;

        private ScreenplayPresenter threeOfThreeScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid1x3PlacardView(Models.View.LandscapeGrid1x3PlacardViewModel model)
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeGrid1x3PlacardViewModel;

            for (int i = 0; i < 3; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;

                    case 1:
                        twoOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;

                    case 2:
                    default:
                        threeOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.ThreeOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;
                }
            }

            oneOfThreeScreenplayPresenter.BeginPresentation();
            twoOfThreeScreenplayPresenter.BeginPresentation();
            threeOfThreeScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            oneOfThreeScreenplayPresenter.Dispose();
            twoOfThreeScreenplayPresenter.Dispose();
            threeOfThreeScreenplayPresenter.Dispose();
            oneOfThreeScreenplayPresenter = null;
            twoOfThreeScreenplayPresenter = null;
            threeOfThreeScreenplayPresenter = null;
        }

        private void ScreenplayPresenterEnded_Callback()
        {
            iterationCount++;

            if (iterationCount < 3) return;

            EndPresentation();
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            return Support.Extend.Templating.Presentation.Providers.PlacardPresentationViewProvider.Instance.GetFor(model);
        }
    }
}