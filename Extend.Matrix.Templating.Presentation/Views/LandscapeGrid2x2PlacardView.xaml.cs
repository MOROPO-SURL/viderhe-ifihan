using SmartSolucionesCuba.Viderhe.Extend.Common.Presentation.Views;
using SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Presenters;
using SmartSolucionesCuba.Viderhe.Extend.Common.Transitioning.Presentation.Transitions.Contract;
using SmartSolucionesCuba.Viderhe.Support.Extend.Templating.Presentation.Providers;
using SmartSolucionesCuba.Viderhe.Support.Extend.Transitioning.Presentation.Providers;

namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid2x2PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfFourScreenplayPresenter;

        private ScreenplayPresenter twoOfFourScreenplayPresenter;

        private ScreenplayPresenter threeOfFourScreenplayPresenter;

        private ScreenplayPresenter fourOfFourScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid2x2PlacardView(Models.View.LandscapeGrid2x2PlacardViewModel model)
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeGrid2x2PlacardViewModel;

            for (int i = 0; i < 4; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;

                    case 1:
                        twoOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;

                    case 2:
                        threeOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.ThreeOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;

                    case 3:
                    default:
                        fourOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.FourOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null);

                        break;
                }
            }

            oneOfFourScreenplayPresenter.BeginPresentation();
            twoOfFourScreenplayPresenter.BeginPresentation();
            threeOfFourScreenplayPresenter.BeginPresentation();
            fourOfFourScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            oneOfFourScreenplayPresenter.Dispose();
            twoOfFourScreenplayPresenter.Dispose();
            threeOfFourScreenplayPresenter.Dispose();
            fourOfFourScreenplayPresenter.Dispose();

            oneOfFourScreenplayPresenter = null;
            twoOfFourScreenplayPresenter = null;
            threeOfFourScreenplayPresenter = null;
            fourOfFourScreenplayPresenter = null;
        }

        private void ScreenplayPresenterEnded_Callback()
        {
            iterationCount++;

            if (iterationCount < 4) return;

            EndPresentation();
        }

        private BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            var result = PlacardPresentationViewProvider.Instance.GetFor(model, getOrientationFunction);

            (result as Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView).RelativeSizeScaleFactor = 1.0d / 4.0d;

            return result;
        }
    }
}