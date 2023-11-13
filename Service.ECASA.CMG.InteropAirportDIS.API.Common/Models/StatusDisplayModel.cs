namespace MOROPO.VIDERHE.Service.ECASA.CMG.InterFIDS.API.Common.Models
{
    public class StatusDisplayModel : Framework.Guama.Core.Persistence.Presentation.Models.Contract.IEntityDisplayModel<Persistence.Entities.Status, System.Guid>
    {
        public System.Guid Id { get; set; }

        public int Discriminator { get; set; }

        public string Label { get; set; }

        public string EmphasisTextColor { get; set; }

        public string EmphasisBackgroundColor { get; set; }

        public string AlternateTextColor { get; set; }

        public string AlternateBackgroundColor { get; set; }

        public void Import(Persistence.Entities.Status entity)
        {
            Id = entity.Id;
            Label = entity.Label;
            Discriminator = entity.Discriminator;
            EmphasisTextColor = entity.EmphasisTextColor;
            EmphasisBackgroundColor = entity.EmphasisBackgroundColor;
            AlternateTextColor = entity.AlternateTextColor;
            AlternateBackgroundColor = entity.AlternateBackgroundColor;
        }
    }
}
