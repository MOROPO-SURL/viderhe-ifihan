using MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter;
using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using MOROPO.VIDERHE.Terminal.Dashboard.Models.View;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Models.Page
{
    public class ManageProgrammingPageModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private readonly System.Action<ScreenplayViewModel> selectedScreenplayCallbackAction;
        private ScreenplayViewModel[] screenplays;
        private FrameViewModel[] frames;
        private bool hasMorePlacards;
        private ScreenplayViewModel selectedScreenPlay;
        private bool useExpandedLayout;
        private System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel> placardOverviews;
        private PlacardFilterModel placardFilter;

        public ManageProgrammingPageModel(System.Action<ScreenplayViewModel> selectedScreenplayCallbackAction)
        {
            this.selectedScreenplayCallbackAction = selectedScreenplayCallbackAction;

            Screenplays = new ScreenplayViewModel[] { };
            Frames = new FrameViewModel[] { };
            PlacardOverviews = new System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel>();
        }

        public ScreenplayViewModel[] Screenplays
        {
            get => screenplays;
            set => SetProperty(ref screenplays, value);
        }

        public FrameViewModel[] Frames
        {
            get => frames;
            set => SetProperty(ref frames, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel> PlacardOverviews { get => placardOverviews; set => SetProperty(ref placardOverviews, value); }

        public bool HasMorePlacards { get => hasMorePlacards; set => SetProperty(ref hasMorePlacards, value); }

        public ScreenplayViewModel SelectedScreenplay
        {
            get => selectedScreenPlay;
            set => SetProperty(ref selectedScreenPlay, value, () =>
            {
                selectedScreenplayCallbackAction?.Invoke(value);
            });
        }

        public bool UseExpandedLayout { get => useExpandedLayout; set => SetProperty(ref useExpandedLayout, value); }

        public PlacardFilterModel PlacardFilter { get => placardFilter; set => SetProperty(ref placardFilter, value, PlacardFilterParamChangeCallbackAction); }

        public System.Action PlacardFilterParamChangeCallbackAction { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            SelectedScreenplay = null;

            Screenplays = null;

            Frames = null;

            foreach (var item in PlacardOverviews)
            {
                item.Dispose();
            }

            PlacardOverviews.Clear();

            PlacardOverviews = null;

            PlacardFilterParamChangeCallbackAction = null;
        }
    }
}
