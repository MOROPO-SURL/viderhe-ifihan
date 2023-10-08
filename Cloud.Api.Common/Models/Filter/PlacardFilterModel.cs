using System;
using System.Linq.Expressions;
using SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Extensions;

namespace SmartSolucionesCuba.Viderhe.Cloud.Api.Common.Models.Filter
{
    public class PlacardFilterModel : MOROPO.SAPRESSC.Core.Persistence.Models.Filter.IEntityFilterModel<Persistence.Entities.Placard, Guid>
    {
        public PlacardFilterModel()
        {
            PlayerOrientationSupportKind = Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any;
            PlayerOrientationSupportKindExclusive = false;
        }

        public string Label { get; set; }

        public Guid? TemplateId { get; set; }

        public Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind PlayerOrientationSupportKind { get; set; }

        public bool PlayerOrientationSupportKindExclusive { get; set; }

        public Expression<Func<Persistence.Entities.Placard, bool>> GetSelector()
        {
            Expression<Func<Persistence.Entities.Placard, bool>> expression = null;

            if (!string.IsNullOrEmpty(Label?.Trim()))
            {
                expression = item => item.Label.ToLower().Contains(Label.ToLower());
            }

            if (PlayerOrientationSupportKind == Extend.Common.Templating.Enumerations.PlayerOrientationSupportKind.Any || PlayerOrientationSupportKindExclusive)
            {
                if (TemplateId != null)
                {
                    return expression.Combine(item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind && item.TemplateId == TemplateId);
                }

                return expression.Combine(item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind);
            }
            else
            {
                if (TemplateId != null)
                {
                    return expression.Combine(item => (item.PlayerOrientationSupportKind == PlayerOrientationSupportKind || item.PlayerOrientationSupportKind == null) && item.TemplateId == TemplateId);
                }

                return expression.Combine(item => item.PlayerOrientationSupportKind == PlayerOrientationSupportKind || item.PlayerOrientationSupportKind == null);
            }
        }
    }
}
