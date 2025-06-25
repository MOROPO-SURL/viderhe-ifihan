namespace MOROPO.VIDERHE.Extend.UICCamaguey.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction, double relativeSizeScaleFactor)
        {
            if (model.Template.Id == Descriptors.EventLiveStreamTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.EventLiveStreamPlacardContextModel>(model.SerializedContext);

                if (context.IsFullScreen)
                {
                    return new Views.FullLiveStreamPlacardView(new Models.View.EventLiveStreamPlacardViewModel
                    {
                        ScreenPresentationTime = context.ScreenPresentationTime,
                        RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                        EventTitle = context.EventTitle,
                        EventPlace = context.EventPlace,
                        VideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(context.StreamUrl)
                    }, relativeSizeScaleFactor);
                }

                return new Views.EventLiveStreamPlacardView(new Models.View.EventLiveStreamPlacardViewModel
                {
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    EventTitle = context.EventTitle,
                    EventPlace = context.EventPlace,
                    VideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(context.StreamUrl)
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == Descriptors.AmbientalDashboardTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.AmbientalDashboardPlacardContextModel>(model.SerializedContext);

                return new Views.AmbientalDashboardPlacardView(new Models.View.AmbientalDashboardPlacardViewModel
                {
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    AmbientalVariable = context.AmbientalVariable,
                }, new System.Uri(context.IoTPlatformEndpointBaseUri), relativeSizeScaleFactor);
            }

            if (model.Template.Id == Descriptors.GovDecisorPrototype1TemplateDescritor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.GovDecisorPrototype1PlacardContextModel>(model.SerializedContext);

                return new Views.GovDecisorPrototype1PlacardView(new Models.View.GovDecisorPrototype1PlacardViewModel
                {
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
                }, relativeSizeScaleFactor);
            }

            if (model.Template.Id == Descriptors.GovDecisorPrototype2TemplateDescritor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.GovDecisorPrototype2PlacardContextModel>(model.SerializedContext);

                return new Views.GovDecisorPrototype2PlacardView(new Models.View.GovDecisorPrototype2PlacardViewModel
                {
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
                }, relativeSizeScaleFactor);
            }

            return null;
        }
    }
}
