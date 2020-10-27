using SmartSolucionesCuba.Videre.Extend.Common.Templating.Presentation.Extensions;

namespace SmartSolucionesCuba.Videre.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PhotoEventPlacardConfigurationPageModelFactory
    {
        public static Models.Page.PhotoEventPlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PhotoEventPlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PhotoEventPlacardContextModel>(placardViewModel.SerializedContext);

            return new Models.Page.PhotoEventPlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                ScreenPresentationTimeSecounds = System.Convert.ToInt32(context.ScreenPresentationTime.TotalSeconds),
                Title = context.Title,
                When = context.When,
                Where = context.Where,
                Image = context.Image.ToViewModel(),
                Aspect = context.ImageAspect,
                IsImageZoomingEnabled = context.ImageZoomingEnabled,
                About = context.About
            };
        }
    }
}
