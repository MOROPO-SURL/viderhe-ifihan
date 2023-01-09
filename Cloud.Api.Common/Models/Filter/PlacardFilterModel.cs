namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter
{
    public class PlacardFilterModel : MOROPO.SAPRESSC.Core.Persistence.Models.Filter.IEntityFilterModel<Persistence.Entities.Placard, System.Guid>
    {
        public PlacardFilterModel()
        {
            PlayerOrientationSupportKind = Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
        }

        public string Label { get; set; }

        public System.Guid? TemplateId { get; set; }

        public Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupportKind { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Persistence.Entities.Placard, bool>> GetSelector()
        {
            if (!string.IsNullOrEmpty(Label.Trim()))
            {
                if (TemplateId != null)
                {
                    return item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind && item.TemplateId == TemplateId && item.Label.Contains(Label);
                }

                return item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind && item.Label.Contains(Label);
            }

            if (TemplateId != null)
            {
                return item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind && item.TemplateId == TemplateId;
            }

            return item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind;
        }
    }
}
