using MOROPO.VIDERHE.Cloud.Api.Common.Extensions;
using MOROPO.VIDERHE.Cloud.Persistence.Entities;
using MOROPO.VIDERHE.Extend.Common.Templating.Enumerations;

namespace MOROPO.VIDERHE.Cloud.Api.Common.Models.Filter
{
    public class PlacardFilterModel : Framework.Guama.Core.Persistence.Presentation.Models.Filter.Contract.IEntityFilterModel<Placard, System.Guid>
    {
        public PlacardFilterModel()
        {
            PlayerOrientationSupportKind = PlayerOrientationSupportKind.Any;
            PlayerOrientationSupportKindExclusive = false;
        }

        public string Label { get; set; }

        public System.Guid? TemplateId { get; set; }

        public PlayerOrientationSupportKind PlayerOrientationSupportKind { get; set; }

        public bool PlayerOrientationSupportKindExclusive { get; set; }

        public TagDisplayModel[] Tags { get; set; }

        public System.Linq.Expressions.Expression<System.Func<Placard, bool>> GetSelector()
        {
            System.Linq.Expressions.Expression<System.Func<Placard, bool>> expression = null;

            if (!string.IsNullOrEmpty(Label?.Trim()))
            {
                expression = item => item.Label.ToLower().Contains(Label.ToLower());
            }

            if (PlayerOrientationSupportKind == PlayerOrientationSupportKind.Any || PlayerOrientationSupportKindExclusive)
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
