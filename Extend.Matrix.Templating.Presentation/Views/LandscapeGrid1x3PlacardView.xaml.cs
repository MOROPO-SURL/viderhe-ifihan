using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;
using MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Models.View;
using MOROPO.VIDERHE.Support.Extend.Transitioning.Presentation.Providers;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid1x3PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfThreeScreenplayPresenter;

        private ScreenplayPresenter twoOfThreeScreenplayPresenter;

        private ScreenplayPresenter threeOfThreeScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid1x3PlacardView(LandscapeGrid1x3PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            var concreteBindingContext = BindingContext as LandscapeGrid1x3PlacardViewModel;

            var relativeSizeScaleFactor = RelativeSizeScaleFactor * 1.0d / 3.0d;

            for (int i = 0; i < 3; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, () => Xamarin.Essentials.DisplayOrientation.Portrait, relativeSizeScaleFactor);

                        break;

                    case 1:
                        twoOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, () => Xamarin.Essentials.DisplayOrientation.Portrait, relativeSizeScaleFactor);

                        break;

                    case 2:
                    default:
                        threeOfThreeScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.ThreeOfThreeTargetPlacards, TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, () => Xamarin.Essentials.DisplayOrientation.Portrait, relativeSizeScaleFactor);

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

        private Common.Presentation.Views.BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return Support.Extend.Templating.Presentation.Helpers.Provisioning.PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }
    }
}