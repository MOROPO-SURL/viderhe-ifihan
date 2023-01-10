namespace SmartSolucionesCuba.Viderhe.Extend.Matrix.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == Descriptors.LandscapeGrid1x3TemplateDescriptor.ID)
            {
                return new XFToolKit.Mvvm.Views.ContentView();
            }

            if (model.Template.Id == Descriptors.LandscapeGrid2x2TemplateDescriptor.ID)
            {
                return new XFToolKit.Mvvm.Views.ContentView();
            }

            return null;
        }
    }
}