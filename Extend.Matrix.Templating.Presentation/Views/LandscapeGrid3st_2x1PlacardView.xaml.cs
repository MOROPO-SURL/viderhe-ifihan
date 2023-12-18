using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid3st_2x1PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter oneOfTwoScreenplayPresenter;

        private ScreenplayPresenter twoOfTwoSplitOneOfTwoScreenplayPresenter;

        private ScreenplayPresenter twoOfTwoSplitTwoOfTwoScreenplayPresenter;

        private int iterationCount;

        public LandscapeGrid3st_2x1PlacardView(Models.View.LandscapeGrid3st_2x1PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
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

            var concreteBindingContext = BindingContext as Models.View.LandscapeGrid3st_2x1PlacardViewModel;

            var relativeSizeScaleFactor = RelativeSizeScaleFactor * 1.0d / 4.0d;

            for (int i = 0; i < 3; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        oneOfTwoScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.OneOfTwoTargetPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, concreteBindingContext.IsOneOfTwoTargetPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;

                    case 1:
                        twoOfTwoSplitOneOfTwoScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfTwoSplitOneOfTwoTargetPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

                        break;

                    case 2:
                        twoOfTwoSplitTwoOfTwoScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TwoOfTwoSplitTwoOfTwoTargetPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, ScreenplayPresenterEnded_Callback, false, null, null, null, null, relativeSizeScaleFactor);

                        break;
                }
            }

            oneOfTwoScreenplayPresenter.BeginPresentation();
            twoOfTwoSplitOneOfTwoScreenplayPresenter.BeginPresentation();
            twoOfTwoSplitTwoOfTwoScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            oneOfTwoScreenplayPresenter.Dispose();
            twoOfTwoSplitOneOfTwoScreenplayPresenter.Dispose();
            twoOfTwoSplitTwoOfTwoScreenplayPresenter.Dispose();

            oneOfTwoScreenplayPresenter = null;
            twoOfTwoSplitOneOfTwoScreenplayPresenter = null;
            twoOfTwoSplitTwoOfTwoScreenplayPresenter = null;
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