namespace MOROPO.VIDERHE.Extend.Common.Templating.Models.Context
{
    public class VideoComplementContextModel
    {
        public VideoContextModel Video { get; set; }

        public Enumerations.VideoComplementPosition Position { get; set; }

        public int Delay { get; set; }
    }
}
