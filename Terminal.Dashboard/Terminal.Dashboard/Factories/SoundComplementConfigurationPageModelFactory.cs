namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class SoundComplementConfigurationPageModelFactory
    {
        public static Models.Page.SoundComplementConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.ComplementationKind == null) return new Models.Page.SoundComplementConfigurationPageModel();

            if (model.ComplementationKind != Cloud.Persistence.Enumerations.PlacardComplementationKind.Sound) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Extend.Common.Templating.Models.Context.SoundComplementContextModel>(model.SerializedComplementation);

            return new Models.Page.SoundComplementConfigurationPageModel
            {
                Sound = new Support.Presentation.Models.View.SoundViewModel
                {
                    Id = context.Sound.Id,
                    About = context.Sound.About,
                    AudioChannelOutput = context.Sound.AudioChannelOutput,
                    AudioFormat = context.Sound.AudioFormat,
                    CreateAt = context.Sound.CreateAt,
                    Duration = context.Sound.Duration,
                    Extension = context.Sound.Extension,
                    Length = context.Sound.Length,
                    ThumbnailId = context.Sound.ThumbnailId
                },
                Repeat = context.Repeat,
                Delay = context.Delay
            };
        }
    }
}
