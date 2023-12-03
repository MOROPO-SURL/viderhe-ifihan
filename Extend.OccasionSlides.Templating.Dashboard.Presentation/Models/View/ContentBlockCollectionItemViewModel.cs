using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Models.View.Block.Contract;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.View
{
    public class ContentBlockCollectionItemViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private AbstractContentBlockViewModel target;
        private bool isBeingDragged;
        private bool isBeingDraggedOverAtStart;
        private bool isBeingDraggedOverAtEnd;

        public AbstractContentBlockViewModel Target { get => target; set => SetProperty(ref target, value); }

        public bool IsBeingDragged { get => isBeingDragged; set => SetProperty(ref isBeingDragged, value); }

        public bool IsBeingDraggedOverAtStart { get => isBeingDraggedOverAtStart; set => SetProperty(ref isBeingDraggedOverAtStart, value); }

        public bool IsBeingDraggedOverAtEnd { get => isBeingDraggedOverAtEnd; set => SetProperty(ref isBeingDraggedOverAtEnd, value); }
    }
}
