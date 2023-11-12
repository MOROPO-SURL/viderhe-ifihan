namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Presentation.Providers
{
    public class PlacardPresentationViewProvider : Common.Templating.Presentation.Providers.Facade.IPlacardPresentationViewProviderFacade
    {
        public Common.Presentation.Views.BasePlacardPresentationView GetFor(Support.Presentation.Models.View.PlacardViewModel model, System.Func<Xamarin.Essentials.DisplayOrientation> getOrientationFunction)
        {
            if (model.Template.Id == Descriptors.ClassicDeparturesTemplateDescriptor.ID)
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.Placard.ClassicDeparturesPlacardContextModel>(model.SerializedContext);

                return new Views.ClassicDeparturesPlacardView(new Models.View.ClassicDeparturesPlacardViewModel
                {
                   ScreenPresentationTime = context.ScreenPresentationTime,
                   RequireUnobstructedPresetation = context.RequireUnobstructedPresetation
                });
            }

            return null;
        }
    }
}
