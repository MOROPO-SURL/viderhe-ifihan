namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View
{
    public class SimplePicturePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public SimplePicturePlacardViewModel()
        {
            ZoomingEnabled = false;
        }

        public Xamarin.Forms.ImageSource Source { get; set; }

        public Xamarin.Forms.Aspect Aspect { get; set; }

        public bool ZoomingEnabled { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Source = null;
        }
    }
}
