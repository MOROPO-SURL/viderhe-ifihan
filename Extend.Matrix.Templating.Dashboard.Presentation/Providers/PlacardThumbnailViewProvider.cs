using MOROPO.VIDERHE.Extend.Matrix.Templating.Descriptors;

namespace MOROPO.VIDERHE.Extend.Matrix.Templating.Dashboard.Presentation.Providers
{
    public class PlacardThumbnailViewProvider : Common.Templating.Dashboard.Presentation.Providers.Facade.IPlacardThumbnailViewProviderFacade
    {
        public Xamarin.Forms.ContentView GetPlacardThumnailView(Support.Presentation.Models.View.PlacardViewModel model)
        {
            if (model.Template.Id == LandscapeGrid1x3TemplateDescriptor.ID ||
                model.Template.Id == LandscapeGrid2x2TemplateDescriptor.ID ||
                model.Template.Id == LandscapeGrid2x1TemplateDescriptor.ID ||
                model.Template.Id == LandscapeGrid3st_2x1TemplateDescriptor.ID)
            {
                return new SmartSolucionesCuba.XFToolKit.Mvvm.Views.ContentView()
                {
                    Content = new Support.Presentation.Views.IdentityBackgroundView()
                };
            }

            return null;
        }
    }
}