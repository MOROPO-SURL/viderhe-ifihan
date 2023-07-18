namespace SmartSolucionesCuba.Viderhe.Extend.SocialWelfare.Templating.Providers
{
    public class PlacardContextDependenciesProvider : Common.Templating.Providers.Facade.IPlacardContextDependenciesProvider
    {
        public Common.Templating.Models.Context.GradientContextModel[] GetGradients(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.InmersiveCityWeatherOverviewPlacardContextModel>(serializedContext);

                if (context.Background.Kind == Enumerations.BackgroundKind.Gradient)
                {
                    return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(context.Background.SerializedContext) };
                }

                return null;
            }

            if (templateId == Descriptors.HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(serializedContext);

                if (context.Background.Kind != Enumerations.BackgroundKind.Gradient) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(context.Background.SerializedContext) };
            }

            if (templateId == Descriptors.OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.OverlayHeroCityTimeWeatherPlacardContextModel>(serializedContext);

                if (context.Background.Kind != Enumerations.BackgroundKind.Gradient) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.GradientContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }

        public Common.Templating.Models.Context.ImageContextModel[] GetImages(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.InmersiveCityWeatherOverviewTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.InmersiveCityWeatherOverviewPlacardContextModel>(serializedContext);

                if (context.Background.Kind == Enumerations.BackgroundKind.Image)
                {
                    return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(context.Background.SerializedContext) };
                }

                return null;
            }

            if (templateId == Descriptors.HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(serializedContext);

                if (context.Background.Kind != Enumerations.BackgroundKind.Image) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(context.Background.SerializedContext) };
            }

            if (templateId == Descriptors.OverlayHeroCityTimeWeatherTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.OverlayHeroCityTimeWeatherPlacardContextModel>(serializedContext);

                if (context.Background.Kind != Enumerations.BackgroundKind.Image) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.ImageContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }

        public Common.Templating.Models.Context.SoundContextModel[] GetSounds(System.Guid templatedId, string serializedContxt)
        {
            return null;
        }

        public Common.Templating.Models.Context.VideoContextModel[] GetVideos(System.Guid templateId, string serializedContext)
        {
            if (templateId == Descriptors.HeroLocalNowDateTimeTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.Context.Placard.HeroLocalNowDateTimePlacardContextModel>(serializedContext);

                if (context.Background.Kind != Enumerations.BackgroundKind.Video) return null;

                return new[] { Newtonsoft.Json.JsonConvert.DeserializeObject<Common.Templating.Models.Context.VideoContextModel>(context.Background.SerializedContext) };
            }

            return null;
        }
    }
}
