namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Factories
{
    public static class WindowsAppsLauncherOverlayConfigurationPageModelFactory
    {
        public static Models.Page.WindowsAppsLauncherOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.WindowsAppsLauncherOverlayContextModel>(serializedContext);

                return new Models.Page.WindowsAppsLauncherOverlayConfigurationPageModel
                {
                    Title = context.Title,
                    FirstLocalPath = context.FirstLocalPath,
                    SecoundLocalPath = context.SecoundLocalPath,
                    ThirthLocalPath = context.ThirthLocalPath,
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize
                };
            }
            catch
            {
                return new Models.Page.WindowsAppsLauncherOverlayConfigurationPageModel();
            }
        }
    }
}
