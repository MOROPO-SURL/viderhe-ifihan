namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Presentation.Models.View
{
    public class ResponsivePicturePlacardViewModel : Common.Templating.Presentation.Models.View.AbstractScreenTimedPlacardViewModel
    {
        public Xamarin.Forms.ImageSource Source { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Source = null;
        }
    }
}
