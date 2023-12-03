using MOROPO.VIDERHE.Cloud.Api.Common.Models;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Helpers.Facade;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Providers.Facade
{
    public interface IPlacardViewModelCompletitionHelperProviderFacade
    {
        IPlacardViewModelCompletitionHelperFacade GetFor(PlacardDisplayModel model);
    }
}
