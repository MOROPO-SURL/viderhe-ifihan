namespace SmartSolucionesCuba.Viderhe.Extend.OHCC.RailwayMuseum.Overlaying.Dashboard.Presentation.Factories
{
    public static class WindowsAppLauncherOverlayConfigurationPageModelFactory
    {
        public static Models.Page.WindowsAppLauncherOverlayConfigurationPageModel Build(string serializedContext)
        {
            try
            {
                var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Overlaying.Presentation.Models.Context.WindowsAppLauncherOverlayContextModel>(serializedContext);

                return new Models.Page.WindowsAppLauncherOverlayConfigurationPageModel
                {
                    LocalPath = context.LocalPath,
                    CallToActionMessage = context.CallToActionMessage,
                    CallToActionMessageFontSize = context.CallToActionMessageFontSize
                };
            }
            catch
            {
                return new Models.Page.WindowsAppLauncherOverlayConfigurationPageModel();
            }
        }
    }
}
