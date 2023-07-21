using System.Linq;

namespace SmartSolucionesCuba.Viderhe.Extend.Common.Templating.Presentation.Views
{
    public class BaseTemplatedPlacardPresentationView : Common.Presentation.Views.BasePlacardPresentationView
    {
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

                System.Threading.Tasks.Task.Delay(System.TimeSpan.FromSeconds(model.Delay)).ContinueWith(async _ =>
                {
                    MediaManager.CrossMediaManager.Current.ClearQueueOnPlay = true;                    

                    if (model.Repeat)
                    {
                        MediaManager.CrossMediaManager.Current.MediaItemFinished += CrossMediaManagerCurrent_MediaItemFinished;
                    }

                    await MediaManager.CrossMediaManager.Current.Play(Support.Presentation.Factories.SoundUriFactory.BuildUri(model.Sound.Id, model.Sound.Extension).ToString());
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

        private void CrossMediaManagerCurrent_MediaItemFinished(object sender, MediaManager.Media.MediaItemEventArgs eventArgs)
        {
            MediaManager.CrossMediaManager.Current.SeekTo(System.TimeSpan.Zero);

            MediaManager.CrossMediaManager.Current.Play();
        }

        public virtual void PerformPlacardStarup() { }

        protected override void DisposeUnmanagementResources()
        {
            base.DisposeUnmanagementResources();

            if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Sound)
            {
                MediaManager.CrossMediaManager.Current.MediaItemFinished -= CrossMediaManagerCurrent_MediaItemFinished;

                MediaManager.CrossMediaManager.Current.Stop();
            }
            else if ((BindingContext as Models.View.AbstractPlacardViewModel).ComplementationKind == Cloud.Persistence.Enumerations.PlacardComplementationKind.Video)
            {
                MediaManager.CrossMediaManager.Current.MediaItemFinished -= CrossMediaManagerCurrent_MediaItemFinished;

                var complementVideoView = WrapLayout.Children.Last() as PlacardComplementVideoView;

                WrapLayout.Children.Remove(complementVideoView);

                complementVideoView.Dispose();
            }
        }
    }
}
