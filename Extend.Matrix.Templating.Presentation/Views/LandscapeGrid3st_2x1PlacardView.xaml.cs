using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Presenters;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Presentation.Views
{
    public partial class LandscapeGrid3st_2x1PlacardView : Common.Templating.Presentation.Views.BaseTemplatedPlacardPresentationView
    {
        private ScreenplayPresenter topCellScreenplayPresenter;

        private ScreenplayPresenter bottomLeftCellScreenplayPresenter;

        private ScreenplayPresenter bottomRightCellScreenplayPresenter;

        private int iterationCount;
        private int iterationLimit;

        public LandscapeGrid3st_2x1PlacardView(Models.View.LandscapeGrid3st_2x1PlacardViewModel model, double relativeSizeScaleFactor) : base(relativeSizeScaleFactor)
        {
            InitializeComponent();

            iterationCount = 0;
            iterationLimit = model.ScreenTimeDirectorScreenplayIndex == null ? 3 : 1;

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

            var relativeSizeScaleFactor = RelativeSizeScaleFactor * 1.0d / 2.0d;

            for (int i = 0; i < 3; i++)
            {
                var targetView = PlacardLayout.Children[i] as Xamarin.Forms.Layout<Xamarin.Forms.View>;

                switch (i)
                {
                    case 0:
                        System.Action topScreenplayPresenterEndedCallbackAction = ScreenplayPresenterEnded_Callback;
                        var isTopLoop = false;

                        if (concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 1 || concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 2)
                        {
                            topScreenplayPresenterEndedCallbackAction = null;
                            isTopLoop = true;
                        }

                        topCellScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.TopCellPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, topScreenplayPresenterEndedCallbackAction, isTopLoop, null, null, null, null, concreteBindingContext.IsTopCellPlacardsScalable ? relativeSizeScaleFactor : RelativeSizeScaleFactor);

                        break;

                    case 1:
                        System.Action bottomLeftScreenplayPresenterEndedCallbackAction = ScreenplayPresenterEnded_Callback;
                        var isBottomLeftLoop = false;

                        if (concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 0 || concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 2)
                        {
                            bottomLeftScreenplayPresenterEndedCallbackAction = null;
                            isBottomLeftLoop = true;
                        }

                        bottomLeftCellScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.BottomLeftCellPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, bottomLeftScreenplayPresenterEndedCallbackAction, isBottomLeftLoop, null, null, null, null, relativeSizeScaleFactor);

                        break;

                    case 2:
                        System.Action bottomRightScreenplayPresenterEndedCallbackAction = ScreenplayPresenterEnded_Callback;
                        var isBottomRightLoop = false;

                        if (concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 0 || concreteBindingContext.ScreenTimeDirectorScreenplayIndex == 1)
                        {
                            bottomRightScreenplayPresenterEndedCallbackAction = null;
                            isBottomRightLoop = true;
                        }

                        bottomRightCellScreenplayPresenter = new ScreenplayPresenter(targetView, PlacardViewModelToPresentationView, concreteBindingContext.BottomRightCellPlacards, Support.Extend.Transitioning.Presentation.Providers.TransitionProvider.Instance, bottomRightScreenplayPresenterEndedCallbackAction, isBottomRightLoop, null, null, null, null, relativeSizeScaleFactor);

                        break;
                }
            }

            topCellScreenplayPresenter.BeginPresentation();
            bottomLeftCellScreenplayPresenter.BeginPresentation();
            bottomRightCellScreenplayPresenter.BeginPresentation();
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            topCellScreenplayPresenter.SuspendPresentation();
            bottomLeftCellScreenplayPresenter.SuspendPresentation();
            bottomRightCellScreenplayPresenter.SuspendPresentation();

            topCellScreenplayPresenter.Dispose();
            bottomLeftCellScreenplayPresenter.Dispose();
            bottomRightCellScreenplayPresenter.Dispose();

            topCellScreenplayPresenter = null;
            bottomLeftCellScreenplayPresenter = null;
            bottomRightCellScreenplayPresenter = null;
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