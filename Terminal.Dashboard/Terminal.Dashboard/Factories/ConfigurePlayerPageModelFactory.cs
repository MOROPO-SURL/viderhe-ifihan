using MOROPO.VIDERHE.Support.Extend.Overlaying.Providers;

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Factories
{
    public static class ConfigurePlayerPageModelFactory
    {
        public static Models.Page.ConfigurePlayerPageModel Build(Models.View.PlayerViewModel model)
        {
            if (model != null)
            {
                var _model = new Models.Page.ConfigurePlayerPageModel
                {
                    IsBusy = true,
                    Id = model.Id,
                    Name = model.Name,
                    Screenplay = model.Screenplay,
                    About = model.About,
                    Overlay = model.OverlayId == null ? null : OverlayDescriptorProvider.Instance.GetDescriptorById(model.OverlayId.Value),
                    SerializedOverlayContext = model.SerializedOverlayContext
                };

                foreach (var item in model.Tags)
                {
                    _model.Tags.Add(item);
                }

                return _model;
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
