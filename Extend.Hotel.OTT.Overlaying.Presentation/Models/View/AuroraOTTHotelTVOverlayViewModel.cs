namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Models.View
{
    public class AuroraOTTHotelTVOverlayViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
    {
        public AuroraOTTHotelTVOverlayViewModel()
        {
            Actions = new ActionViewModel[]
            {
                new ActionViewModel() { Title = "Señal Diamond", Glyph = "\uF1C8", Kind = ActionKind.BrandChannel },
                new ActionViewModel { Title = "Canales de TV", Glyph = "\uF7F3", Kind = ActionKind.TV },
                new ActionViewModel { Title = "Video a Demanda", Glyph = "\uFEEC", Kind = ActionKind.VoD },
                new ActionViewModel { Title = "Conocer el Hotel", Glyph = "\uF990", Kind = ActionKind.ResortKnowning }
            };
        }

        public Context.OTTHotelTVOverlayContextModel Context { get; set; }

        public ActionViewModel[] Actions { get; private set; }

        public enum ActionKind
        {
            BrandChannel,
            TV,
            VoD,
            ResortKnowning
        }

        public class ActionViewModel : SmartSolucionesCuba.XFToolKit.Mvvm.Models.BaseBindableModel
        {
            public string Title { get; set; }

            public string Glyph { get; set; }

            public ActionKind Kind { get; set; }
        }
    }
}
