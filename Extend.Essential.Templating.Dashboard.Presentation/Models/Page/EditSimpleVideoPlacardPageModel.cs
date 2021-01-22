namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class EditSimpleVideoPlacardPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        public XFToolKit.Presentation.Sources.Video.VideoSource VideoSource { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            VideoSource = null;
        }
    }
}
