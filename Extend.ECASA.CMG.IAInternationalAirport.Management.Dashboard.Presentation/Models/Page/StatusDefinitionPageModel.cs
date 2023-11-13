namespace SmartSolucionesCuba.Viderhe.Extend.ECASA.CMG.IAInternationalAirport.Management.Dashboard.Presentation.Models.Page
{
    public class StatusDefinitionPageModel : Support.Presentation.Dashboard.Models.Page.FormPageModel
    {
        private string label;
        private int? discriminator;
        private int[] availableDiscriminators;
        private bool isEmphasisEnabled;
        private Xamarin.Forms.Color emphasisTextColor;
        private Xamarin.Forms.Color emphasisBackgroundColor;
        private bool isBlinkAnimationEnabled;
        private Xamarin.Forms.Color alternateTextColor;
        private Xamarin.Forms.Color alternateBackgroundColor;

        public StatusDefinitionPageModel()
        {
            Id = System.Guid.NewGuid();
        }

        public System.Guid Id { get; set; }

        public string Label { get => label; set => SetProperty(ref label, value); }

        public int? Discriminator { get => discriminator; set => SetProperty(ref discriminator, value); }

        public int[] AvailableDiscriminators { get => availableDiscriminators; set => SetProperty(ref availableDiscriminators, value); }

        public bool IsEmphasisEnabled { get => isEmphasisEnabled; set => SetProperty(ref isEmphasisEnabled, value); }

        public Xamarin.Forms.Color EmphasisTextColor { get => emphasisTextColor; set => SetProperty(ref emphasisTextColor, value); }

        public Xamarin.Forms.Color EmphasisBackgroundColor { get => emphasisBackgroundColor; set => SetProperty(ref emphasisBackgroundColor, value); }

        public bool IsBlinkAnimationEnabled { get => isBlinkAnimationEnabled; set => SetProperty(ref isBlinkAnimationEnabled, value); }

        public Xamarin.Forms.Color AlternateTextColor { get => alternateTextColor; set => SetProperty(ref alternateTextColor, value); }

        public Xamarin.Forms.Color AlternateBackgroundColor { get => alternateBackgroundColor; set => SetProperty(ref alternateBackgroundColor, value); }
    }
}
