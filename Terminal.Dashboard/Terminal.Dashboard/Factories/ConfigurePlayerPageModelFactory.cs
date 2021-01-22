namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class ConfigurePlayerPageModelFactory
    {
        public static Models.Page.ConfigurePlayerPageModel Build(Models.View.PlayerViewModel model)
        {
            if (model != null)
            {
                return new Models.Page.ConfigurePlayerPageModel
                {
                    IsBusy = true,
                    Id = model.Id,
                    Name = model.Name,
                    Screenplay = model.Screenplay,
                    About = model.About,
                    Overlay = model.OverlayId == null ? null : Support.Extend.Overlaying.Providers.OverlayDescriptorProvider.Instance.GetDescriptorById(model.OverlayId.Value),
                    SerializedOverlayContext = model.SerializedOverlayContext
                };
            }
            else
            {
                return new Models.Page.ConfigurePlayerPageModel
                {
                    IsBusy = true
                };
            }
        }
    }
}
