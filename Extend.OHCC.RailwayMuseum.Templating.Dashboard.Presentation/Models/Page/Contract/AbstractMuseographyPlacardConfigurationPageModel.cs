namespace MOROPO.VIDERHE.Extend.OHCC.RailwayMuseum.Templating.Dashboard.Presentation.Models.Page.Contract
{
    public abstract class AbstractMuseographyPlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledScreenTimedPlacardConfigurationPageModel
    {
        private string header;
        private int headerFontSize;
        private string content;
        private int contentFontSize;

        public AbstractMuseographyPlacardConfigurationPageModel()
        {
            ScreenPresentationTimeSecounds = 15;

            HeaderFontSize = 48;
            ContentFontSize = 32;
        }

        public string Header { get => header; set => SetProperty(ref header, value); }

        public int HeaderFontSize { get => headerFontSize; set => SetProperty(ref headerFontSize, value); }

        public string Content { get => content; set => SetProperty(ref content, value); }

        public int ContentFontSize { get => contentFontSize; set => SetProperty(ref contentFontSize, value); }
    }
}
