namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Models.Page
{
    public class PictureSecuencePlacardConfigurationPageModel : Common.Templating.Dashboard.Presentation.Models.Page.AbstractLabeledPlacardConfigurationPageModel
    {
        private int picturePresentationSecounds;

        public PictureSecuencePlacardConfigurationPageModel()
        {
            PicturePresentationSecounds = 10;

            Images = new System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.ImageViewModel>();
        }

        public int PicturePresentationSecounds
        {
            get => picturePresentationSecounds;
            set => SetProperty(ref picturePresentationSecounds, value);
        }

        public System.Collections.ObjectModel.ObservableCollection<Support.Presentation.Models.View.ImageViewModel> Images { get; set; }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            Images.Clear();

            Images = null;
        }
    }
}
