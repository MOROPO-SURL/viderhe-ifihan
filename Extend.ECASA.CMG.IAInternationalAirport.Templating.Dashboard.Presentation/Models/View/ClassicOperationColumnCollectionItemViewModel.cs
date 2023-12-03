using MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Models.View
{
    public class ClassicOperationColumnCollectionItemViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private ClassicOperationsColumn target;
        private bool isBeingDragged;
        private bool isBeingDraggedOverAtStart;
        private bool isBeingDraggedOverAtEnd;

        public int Order { get; set; }

        public ClassicOperationsColumn Target { get => target; set => SetProperty(ref target, value); }

        public bool IsBeingDragged { get => isBeingDragged; set => SetProperty(ref isBeingDragged, value); }

        public bool IsBeingDraggedOverAtStart { get => isBeingDraggedOverAtStart; set => SetProperty(ref isBeingDraggedOverAtStart, value); }

        public bool IsBeingDraggedOverAtEnd { get => isBeingDraggedOverAtEnd; set => SetProperty(ref isBeingDraggedOverAtEnd, value); }
    }
}
