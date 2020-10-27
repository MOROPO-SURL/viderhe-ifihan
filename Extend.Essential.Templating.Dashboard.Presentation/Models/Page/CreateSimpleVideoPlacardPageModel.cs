namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class CreateSimpleVideoPlacardPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        public Support.Presentation.Models.View.VideoViewModel Video { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Video = null;
        }
    }
}
