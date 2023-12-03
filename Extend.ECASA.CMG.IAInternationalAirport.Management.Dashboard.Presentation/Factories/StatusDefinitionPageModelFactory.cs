namespace MOROPO.VIDERHE.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Factories
{
    public static class StatusDefinitionPageModelFactory
    {
        public static Models.Page.StatusDefinitionPageModel Build(Service.ECASA.CMG.InterFIDS.API.Common.Models.StatusDisplayModel target)
        {
            if (target == null) return new Models.Page.StatusDefinitionPageModel();

            return new Models.Page.StatusDefinitionPageModel
            {
                Id = target.Id,
                Label = target.Label,
                Discriminator = target.Discriminator,
                IsEmphasisEnabled = target.EmphasisBackgroundColor != null,
                EmphasisTextColor = target.EmphasisTextColor == null ? Xamarin.Forms.Color.Accent : Xamarin.Forms.Color.FromHex(target.EmphasisTextColor),
                EmphasisBackgroundColor = target.EmphasisBackgroundColor == null ? Xamarin.Forms.Color.Accent : Xamarin.Forms.Color.FromHex(target.EmphasisBackgroundColor),
                IsBlinkAnimationEnabled = target.AlternateBackgroundColor != null,
                AlternateTextColor = target.AlternateTextColor == null ? Xamarin.Forms.Color.Accent : Xamarin.Forms.Color.FromHex(target.AlternateTextColor),
                AlternateBackgroundColor = target.AlternateBackgroundColor == null ? Xamarin.Forms.Color.Accent : Xamarin.Forms.Color.FromHex(target.AlternateBackgroundColor)
            };
        }
    }
}
