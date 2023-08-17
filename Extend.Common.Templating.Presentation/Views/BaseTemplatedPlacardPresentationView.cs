using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Views
{
    public class BaseTemplatedPlacardPresentationView : Common.Presentation.Views.BasePlacardPresentationView, Contract.IRelativeDimensionScalable
    {
        public Xamarin.CommunityToolkit.UI.Views.MediaElement SoundComplementMediaElement;

        public virtual void StartShowInWhenReady(Transitioning.Presentation.Transitions.Contract.AbstractTransition transition)
        {
            transition.PerformMotion();
        }

        public sealed override void OnShowInTransitionComplete()
        {
            PerformPlacardStarup();

            if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Sound)
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.SoundComplementContextModel>((BindingContext as Models.View.AbstractPlacardViewModel).SerializedComplementation);

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
                            Source = Xamarin.CommunityToolkit.Core.MediaSource.FromUri(Support.Presentation.Factories.SoundUriFactory.BuildUri(model.Sound.Id, model.Sound.Extension))
                        };

                        ConfigureLayout(SoundComplementMediaElement);

                        WrapLayout.Children.Add(SoundComplementMediaElement);
                    });                  
                });            
            }
            else if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Video)
            {
                var model = Newtonsoft.Json.JsonConvert.DeserializeObject<Templating.Models.Context.VideoComplementContextModel>((BindingContext as Models.View.AbstractPlacardViewModel).SerializedComplementation);

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

            if (!(BindingContext is Models.View.AbstractScreenTimedPlacardViewModel) || (BindingContext as Models.View.AbstractScreenTimedPlacardViewModel).ScreenPresentationTime <= System.TimeSpan.Zero) return;

            Xamarin.Forms.Device.StartTimer((BindingContext as Models.View.AbstractScreenTimedPlacardViewModel).ScreenPresentationTime, () =>
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

            if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Sound)
            {
                SoundComplementMediaElement.Stop();

                SoundComplementMediaElement.Source = null;

                WrapLayout.Children.Remove(SoundComplementMediaElement);

                SoundComplementMediaElement = null;
            }
            else if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Video)
            {
                var complementVideoView = WrapLayout.Children.Last() as PlacardComplementVideoView;

                WrapLayout.Children.Remove(complementVideoView);

                complementVideoView.Dispose();
            }
        }

        #region IRelativeDimensionScalable implementation

        public double RelativeDeimensionScaleFactor { get; set; } = 1.0d;

        #endregion
    }
}
