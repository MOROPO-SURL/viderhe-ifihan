using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class SoundComplementConfigurationPageModelFactory
    {
        public static Models.Page.SoundComplementConfigurationPageModel Build(PlacardViewModel model)
        {
            if (model.ComplementationKind == null) return new Models.Page.SoundComplementConfigurationPageModel();

            if (model.ComplementationKind != PlacardComplementationKind.Sound) throw new System.InvalidOperationException();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundComplementContextModel>(model.SerializedComplementation);

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
