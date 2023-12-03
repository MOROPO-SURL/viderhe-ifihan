using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;
using MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Extend.Transitioning.Presentation.Providers;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid2x2PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfFourScreenplayPresenter;

        private ScreenplayPresenter twoOfFourScreenplayPresenter;

        private ScreenplayPresenter threeOfFourScreenplayPresenter;

        private ScreenplayPresenter fourOfFourScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid2x2PlacardView(LandscapeGrid2x2PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            var concreteBindingContext = BindingContext as LandscapeGrid2x2PlacardViewModel;

            var relativeSizeScaleFactor = RelativeSizeScaleFactor * 1.0d / 3.0d;

            for (int i = 0; i < 4; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

                        break;

                    case 1:
                        twoOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

                        break;

                    case 2:
                        threeOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.ThreeOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

                        break;

                    case 3:
                    default:
                        fourOfFourScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.FourOfFourTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

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

        private Common.Presentation.Views.BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return Support.Extend.Templating.Presentation.Helpers.Provisioning.PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }
    }
}