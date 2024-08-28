using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Collections.Generic;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Pages
{
    public partial class TelevisionChannelGridPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.MasterDetailPage
    {
        private System.Action<LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel>> channelPickedCallbackAction;

        public TelevisionChannelGridPage(HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel lastChannel, System.Action<LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel>> channelPickedCallbackAction)
        {
            InitializeComponent();

            this.channelPickedCallbackAction = channelPickedCallbackAction;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            channelPickedCallbackAction = null;
        }

        public void HandlePickedChannel(HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel model)
        {
            channelPickedCallbackAction.Invoke(Providers.TelevisionChannelProvider.Instance.Channels.Find(model));

            this.NavigationPopModalPageAsync();
        }
    }
}