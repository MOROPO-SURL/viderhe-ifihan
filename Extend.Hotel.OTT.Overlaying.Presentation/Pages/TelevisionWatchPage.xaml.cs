using SmartSolucionesCuba.XFToolKit.Mvvm.Extensions;
using System.Collections.Generic;

namespace MOROPO.VIDERHE.Extend.Hotel.OTT.Overlaying.Presentation.Pages
{
    public partial class TelevisionWatchPage : SmartSolucionesCuba.XFToolKit.Mvvm.Pages.ContentPage
    {
        private System.Action presentationCompleteCallbackAction;

        private LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel> lastChannelNode;

        public TelevisionWatchPage(LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel> lastChannelNode, System.Action presentationCompleteCallbackAction)
        {
            InitializeComponent();

            this.lastChannelNode = lastChannelNode;
            this.presentationCompleteCallbackAction = presentationCompleteCallbackAction;

            if (lastChannelNode != null) 
            {
                PresentTelevisionChannel(false);
            }

            IsEnabled = false;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (lastChannelNode == null)
            {
                this.NavigationPushModalPageAsync(new TelevisionChannelGridPage(lastChannelNode?.Value, ChannelPicked_Callback));
            }
            else if (IsEnabled)
            {
                PresentTelevisionChannel(false);
            }

            IsEnabled = true;
        }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            presentationCompleteCallbackAction = null;
            lastChannelNode = null;
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            this.NavigationPopModalPageAsync();

            presentationCompleteCallbackAction?.Invoke();
        }

        private void ChannelPicked_Callback(LinkedListNode<HIPS.Web.API.Common.Models.TelevisionChannelDisplayModel> channel)
        {
            lastChannelNode = channel;
        }

        private void PresentTelevisionChannel(bool remmember = true)
        {
            if (ChannelPresentationWrapGrid.Children.Count > 0)
            {
                var outgoingView = ChannelPresentationWrapGrid.Children[0];

                ChannelPresentationWrapGrid.Children.Clear();

                if (outgoingView is System.IDisposable)
                {
                    (outgoingView as System.IDisposable).Dispose();
                }
            }

            switch (lastChannelNode.Value.Kind)
            {
                case HIPS.Persistence.Enumerations.ChannelKind.IPTV:
                    ChannelPresentationWrapGrid.Children.Add(new Views.TV.IPTVChannelView(lastChannelNode.Value));

                    break;

                case HIPS.Persistence.Enumerations.ChannelKind.VIDERHEScreenplay:
                    ChannelPresentationWrapGrid.Children.Add(new Views.TV.VIDERHEScreenplayChannelView(System.Guid.Parse(lastChannelNode.Value.SourceSerialization)));

                    break;
            }

            if (!remmember) return;

            if (Xamarin.Forms.Application.Current.Properties.ContainsKey(Constants.LAST_CHANNEL_ID_KEY))
            {
                Xamarin.Forms.Application.Current.Properties[Constants.LAST_CHANNEL_ID_KEY] = lastChannelNode.Value.Id;
            }
            else
            {
                Xamarin.Forms.Application.Current.Properties.Add(Constants.LAST_CHANNEL_ID_KEY, lastChannelNode.Value.Id);
            }
        }
    }
}