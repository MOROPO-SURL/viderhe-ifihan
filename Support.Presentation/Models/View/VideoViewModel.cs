namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Models.View
{
    public class VideoViewModel : XFToolKit.Mvvm.Models.BaseBindableModel
    {
        private string about;

        public System.Guid Id { get; set; }

        public System.Guid ThumbnailId { get; set; }

        public System.DateTime CreateAt { get; set; }

        public string Extension { get; set; }

        public string FrameSize { get; set; }

        public double Fps { get; set; }

        public string Duration { get; set; }

        public long Size { get; set; }

        public string About
        {
            get => about;
            set => SetProperty(ref about, value);
        }
    }
}
