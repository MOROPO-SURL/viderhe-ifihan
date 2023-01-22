namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Dashboard.Presentation.Models.View
{
    public class ContentBlockCollectionItemViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel target;
        private bool isBeingDragged;
        private bool isBeingDraggedOverAtStart;
        private bool isBeingDraggedOverAtEnd;

        public Templating.Presentation.Models.View.Block.Contract.AbstractContentBlockViewModel Target { get => target; set => SetProperty(ref target, value); }

        public bool IsBeingDragged { get => isBeingDragged; set => SetProperty(ref isBeingDragged, value); }

        public bool IsBeingDraggedOverAtStart { get => isBeingDraggedOverAtStart; set => SetProperty(ref isBeingDraggedOverAtStart, value); }

        public bool IsBeingDraggedOverAtEnd { get => isBeingDraggedOverAtEnd; set => SetProperty(ref isBeingDraggedOverAtEnd, value); }
    }
}
