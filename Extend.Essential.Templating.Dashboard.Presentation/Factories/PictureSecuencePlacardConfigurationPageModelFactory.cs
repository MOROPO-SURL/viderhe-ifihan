namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Dashboard.Presentation.Factories
{
    public static class PictureSecuencePlacardConfigurationPageModelFactory
    {
        public static Models.Page.PictureSecuencePlacardConfigurationPageModel Build(Support.Presentation.Models.View.PlacardViewModel placardViewModel)
        {
            if (placardViewModel == null) return new Models.Page.PictureSecuencePlacardConfigurationPageModel();

            var context = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Presentation.Models.Context.PictureSecuencePlacardContextModel>(placardViewModel.SerializedContext);

            var result = new Models.Page.PictureSecuencePlacardConfigurationPageModel
            {
                RequireUnobstructedPresetation = context.RequireUnobstructedPresetation,
                Label = placardViewModel.Label,
                PicturePresentationSecounds = context.PicturePresentationSecounds
            };

            foreach (var item in context.Images)
            {
                result.Images.Add(new Support.Presentation.Models.View.ImageViewModel { Id = item.Id, ThumbnailId = item.ThumbnailId });
            }

            return result;
        }
    }
}
