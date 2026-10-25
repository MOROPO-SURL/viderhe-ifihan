using MOROPO.VIDERHE.Cloud.Persistence.Enumerations;
using MOROPO.VIDERHE.Extend.Common.Templating.Models.Context;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Models.View;
using MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views.Facade;
using MOROPO.VIDERHE.Support.Presentation.Factories;
using System.Linq;

namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Views
{
    public class BaseTemplatedPlacardPresentationView : Common.Presentation.Views.BasePlacardPresentationView, IRelativeSizeScalableViewFacade
    {
        public BaseTemplatedPlacardPresentationView(double relativeSizeScaleFactor)
        {
            RelativeSizeScaleFactor = relativeSizeScaleFactor;
        }

        public Xamarin.CommunityToolkit.UI.Views.MediaElement SoundComplementMediaElement;

        public virtual void StartShowInWhenReady(Transitioning.Presentation.Transitions.Contract.AbstractTransition transition)
        {
            transition.PerformMotion();
        }

        public sealed override void OnShowInTransitionComplete()
        {
            PerformPlacardStarup();

            if ((BindingContext as AbstractPlacardViewModel).ComplementationKind == PlacardComplementationKind.Sound)
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<SoundComplementContextModel>((BindingContext as AbstractPlacardViewModel).SerializedComplementation);

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(model.Delay)).ContinueWith(_ =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        SoundComplementMediaElement = new Xamarin.CommunityToolkit.UI.Views.MediaElement
                        {
                            IsLooping = model.Repeat,
                            IsVisible = Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android,
                            Opacity = Xamarin.Forms.Device.RuntimePlatform == Xamarin.Forms.Device.Android ? 0 : 1,
                            AutoPlay = true,
                            ShowsPlaybackControls = false,
                            Source = Xamarin.CommunityToolkit.Core.MediaSource.FromUri(SoundUriFactory.BuildUri(model.Sound.Id, model.Sound.Extension))
                        };

                        ConfigureLayout(SoundComplementMediaElement);

                        WrapLayout.Children.Add(SoundComplementMediaElement);
                    });
                });
            }
            else if ((BindingContext as AbstractPlacardViewModel).ComplementationKind == PlacardComplementationKind.Video)
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<VideoComplementContextModel>((BindingContext as AbstractPlacardViewModel).SerializedComplementation);

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(model.Delay)).ContinueWith(_ =>
                {
                    Xamarin.Forms.Device.BeginInvokeOnMainThread(() =>
                    {
                        var complementVideoView = new PlacardComplementVideoView(this, model);

                        ConfigureLayout(complementVideoView);

                        WrapLayout.Children.Add(complementVideoView);
                    });
                });
            }

            if (!(BindingContext is AbstractScreenTimedPlacardViewModel) || (BindingContext as AbstractScreenTimedPlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            Xamarin.Forms.Device.StartTimer((BindingContext as AbstractScreenTimedPlacardViewModel).ScreenPresentationTime, () =>
            {
                if (BindingContext != null)
                {
                    EndPresentation();
                }

                return false;
            });
        }

        public virtual void PerformPlacardStarup() { }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if ((BindingContext as AbstractPlacardViewModel).ComplementationKind == PlacardComplementationKind.Sound)
            {
                if (SoundComplementMediaElement == null) return;

                SoundComplementMediaElement.Stop();

                SoundComplementMediaElement.Source = null;

                WrapLayout.Children.Remove(SoundComplementMediaElement);

                SoundComplementMediaElement = null;
            }
            else if ((BindingContext as AbstractPlacardViewModel).ComplementationKind == PlacardComplementationKind.Video)
            {
                var complementVideoView = WrapLayout.Children.Last() as PlacardComplementVideoView;

                WrapLayout.Children.Remove(complementVideoView);

                complementVideoView.Dispose();
            }
        }

        #region IRelativeSizeScalableViewFacade implementation

        public double RelativeSizeScaleFactor { get; }

        #endregion
    }
}
