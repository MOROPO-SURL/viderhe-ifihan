namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Models.Page
{
    public class AddImagePageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
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
