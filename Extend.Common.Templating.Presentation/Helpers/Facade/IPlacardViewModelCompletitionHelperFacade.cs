using MOROPO.VIDERHE.Support.Presentation.Models.View;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Helpers.Facade
{
    public interface IPlacardViewModelCompletitionHelperFacade
    {
        System.Threading.Tasks.Task CompleteAsync(PlacardViewModel model);
    }
}
