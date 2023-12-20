using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid2x1PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter topCellScreenplayPresenter;
        private ScreenplayPresenter bottomCellScreenplayPresenter;

        private int iterationCount;
        private int iterationLimit;

        public LandscapeGrid2x1PlacardView(Models.View.LandscapeGrid2x1PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            iterationCount = 0;
            iterationLimit = model.ScreenTimeDirectorScreenplayIndex == null ? 2 : 1;

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
                        System.Action topScreenplayPresenterEndedCallbackAction = ScreenplayPresenterEnded_Callback;

                        if (concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 1)
                        {
                            topScreenplayPresenterEndedCallbackAction = null;
                        }

                        topCellScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TopCellPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, topScreenplayPresenterEndedCallbackAction, concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 1, null, null, null, null, concreteBindingContext.IsTopCellPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;

                    case 1:
                        System.Action bottomScreenplayPresenterEndedCallbackAction = ScreenplayPresenterEnded_Callback;

                        if (concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 0)
                        {
                            bottomScreenplayPresenterEndedCallbackAction = null;
                        }

                        bottomCellScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.BottomCellPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, bottomScreenplayPresenterEndedCallbackAction, concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 0, null, null, null, null, concreteBindingContext.IsBottomCellPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;
                }
            }

            topCellScreenplayPresenter.BeginPresentation();
            bottomCellScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            topCellScreenplayPresenter.Dispose();
            bottomCellScreenplayPresenter.Dispose();

            topCellScreenplayPresenter = null;
            bottomCellScreenplayPresenter = null;
        }

        private void ScreenplayPresenterEnded_Callback()
        {
            iterationCount++;

            if (iterationCount < iterationLimit) return;

            EndPresentation();
        }

        private Common.Presentation.Views.BasePlacardPresentationView PlacardViewModelToPresentationView(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            return Support.Extend.Templating.Presentation.Helpers.Provisioning.PlacardPresentationViewProvisioningHelper.Instance.GetFor(model, getOrientationFunction, relativeSizeScaleFactor);
        }
    }
}