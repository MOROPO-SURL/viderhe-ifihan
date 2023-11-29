using MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View;
using MOROPO.VIDERHE.Support.Presentation.Models.View;
using SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class ManageProgrammingPageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private readonly System.Action<ScreenplayViewModel> selectedScreenplayCallbackAction;
        private readonly System.Action labelFilterParamaChangeCallbackAction;

        private ScreenplayViewModel[] screenplays;
        private FrameViewModel[] frames;
        private bool hasMorePlacards;
        private ScreenplayViewModel selectedScreenPlay;
        private bool useExpandedLayout;
        private System.Collections.ObjectModel.ObservableCollection<PlacardOverviewViewModel> placardOverviews;
        private string labelFilterParam;

        public ManageProgrammingPageModel(System.Action<ScreenplayViewModel> selectedScreenplayCallbackAction, System.Action labelFilterParamaChangeCallbackAction)
        {
            this.selectedScreenplayCallbackAction = selectedScreenplayCallbackAction;
            this.labelFilterParamaChangeCallbackAction = labelFilterParamaChangeCallbackAction;

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

        public string LabelFilterParam { get => labelFilterParam; set => SetProperty(ref labelFilterParam, value, labelFilterParamaChangeCallbackAction); }

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
        }
    }
}
