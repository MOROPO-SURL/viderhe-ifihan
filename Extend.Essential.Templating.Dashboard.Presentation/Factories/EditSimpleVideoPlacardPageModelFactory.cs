namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class EditSimpleVideoPlacardPageModelFactory
    {
        public static Models.Page.EditSimpleVideoPlacardPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel, Support.Presentation.Providers.Facade.ICloudServerProviderFacade cloudServerProvider)
        {
            var contextModel = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.SimpleVideoPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.EditSimpleVideoPlacardPageModel
            {
                Label = placardViewModel.Label,
                RequireUnobstructedPresetation = contextModel.RequireUnobstructedPresetation,
                VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromUri(Support.Presentation.Factories.VideoUriFactory.BuildVideoUri(cloudServerProvider, contextModel.VideoId, contextModel.VideoExtension).AbsoluteUri)
            };
        }
    }
}
