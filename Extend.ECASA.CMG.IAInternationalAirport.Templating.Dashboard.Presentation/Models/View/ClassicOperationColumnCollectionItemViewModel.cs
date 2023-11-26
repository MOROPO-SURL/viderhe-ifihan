namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.View
{
    public class ClassicOperationColumnCollectionItemViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private Enumerations.ClassicOperationsColumn target;
        private bool isBeingDragged;
        private bool isBeingDraggedOverAtStart;
        private bool isBeingDraggedOverAtEnd;

        public int Order { get; set; }

        public Enumerations.ClassicOperationsColumn Target { get => target; set => SetProperty(ref target, value); }

        public bool IsBeingDragged { get => isBeingDragged; set => SetProperty(ref isBeingDragged, value); }

        public bool IsBeingDraggedOverAtStart { get => isBeingDraggedOverAtStart; set => SetProperty(ref isBeingDraggedOverAtStart, value); }

        public bool IsBeingDraggedOverAtEnd { get => isBeingDraggedOverAtEnd; set => SetProperty(ref isBeingDraggedOverAtEnd, value); }
    }
}
