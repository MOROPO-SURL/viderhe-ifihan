using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid2x1PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfTwoScreenplayPresenter;

        private ScreenplayPresenter twoOfTwoScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid2x1PlacardView(Models.View.LandscapeGrid2x1PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeGrid2x1PlacardViewModel;

            var relativeSizeScaleFactor = RelativeSizeScaleFactor * 1.0d / 2.0d;

            for (int i = 0; i < 2; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfTwoScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfTwoTargetPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, concreteBindingContext.IsOneOfTwoTargetPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;

                    case 1:
                        twoOfTwoScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfTwoTargetPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, concreteBindingContext.IsTwoOfTwoTargetPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;
                }
            }

            oneOfTwoScreenplayPresenter.BeginPresentation();
            twoOfTwoScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            oneOfTwoScreenplayPresenter.Dispose();
            twoOfTwoScreenplayPresenter.Dispose();

            oneOfTwoScreenplayPresenter = null;
            twoOfTwoScreenplayPresenter = null;
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