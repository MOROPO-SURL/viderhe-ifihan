using MOROPO.VIDERHE.Cloud.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Models.View
{
    public class AccountExtensionsInputViewModel
    {
        public AccountExtensionsInputViewModel()
        {
            SelectableExtensions = new System.Collections.Generic.List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>>();
        }

        public System.Guid AccountId { get; set; }

        public Account Account { get; set; }

        public System.Collections.Generic.List<Framework.Guama.Core.Presentation.Models.View.SelectionDescriptedItemInputViewModel<System.Guid>> SelectableExtensions { get; set; }
    }
}