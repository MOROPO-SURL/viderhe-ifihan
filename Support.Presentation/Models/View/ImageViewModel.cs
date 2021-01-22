namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View
{
    public class ImageViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string about;

        public System.Guid Id { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Format { get; set; }

        public long Size { get; set; }

        public string Resolution { get; set; }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }
    }
}
