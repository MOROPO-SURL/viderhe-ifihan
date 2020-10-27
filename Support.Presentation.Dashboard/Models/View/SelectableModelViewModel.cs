namespace SmartSolucionesCuba.Videre.Support.Presentation.Dashboard.Models.View
{
    public class SelectableModelViewModel<TModel> : XFToolKit.Mvvm.Models.BaseBindableModel where TModel : class
    {
        private bool selected;

        public bool Selected { get => selected; set => SetProperty(ref selected, value); }

        public TModel Model { get; set; }
    }
}
