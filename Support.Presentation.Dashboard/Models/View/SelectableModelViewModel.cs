namespace MOROPO.VIDERHE.Support.Presentation.Dashboard.Models.View
{
    public class SelectableModelViewModel<TModel> : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel where TModel : class
    {
        private bool selected;

        public bool Selected { get => selected; set => SetProperty(ref selected, value); }

        public TModel Model { get; set; }
    }
}
