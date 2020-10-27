namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Models.Page
{
    public class AddImagePageModel : XFToolKit.Mvvm.Models.Page.BasePageModel
    {
        private string about;

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }

        public Xamarin.Forms.ImageSource ImageSource { get; set; }

        public string Format { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ImageSource = null;
        }
    }
}
