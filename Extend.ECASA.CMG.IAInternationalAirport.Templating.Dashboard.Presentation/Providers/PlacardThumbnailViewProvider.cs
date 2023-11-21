namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.ClassicDeparturesTemplateDescriptor.ID || model.Template.Id == Descriptors.ClassicArraivalsTemplateDescriptor.ID)
            {
                return new Views.ClassicOperationsPlacardThumbnailView(model);
            }

            return null;
        }
    }
}
