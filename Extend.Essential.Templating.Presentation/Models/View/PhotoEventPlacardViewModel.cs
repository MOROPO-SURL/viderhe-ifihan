namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View
{
    public class PhotoEventPlacardViewModel : BaseEventPlacardViewModel
    {
        public System.Guid ImageId { get; set; }

        public int ImageHeight { get; set; }

        public int ImageWidth { get; set; }

        public bool ImageZoomingEnabled { get; set; }

        public Xamarin.Forms.ImageSource ImageSource { get; set; }

        public Xamarin.Forms.Aspect ImageAspect { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            ImageSource = null;
        }
    }
}
