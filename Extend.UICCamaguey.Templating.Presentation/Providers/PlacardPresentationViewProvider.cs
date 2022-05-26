namespace SmartSolucionesCuba.Viderhe.Extend.UICCamaguey.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.EventLiveStreamTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.EventLiveStreamPlacardContextModel>(model.SerializedContext);

                return new Views.EventLiveStreamPlacardView(new Models.View.EventLiveStreamPlacardViewModel
                {
                    ScreenPresentationTime = context.ScreenPresentationTime,
                    RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                    EventTitle = context.EventTitle,
                    EventPlace = context.EventPlace,
                    VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(context.StreamUrl)
                });
            }

            return null;
        }
    }
}
