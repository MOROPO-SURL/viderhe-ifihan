namespace MOROPO.VIDERHE.Extend.Common.Overlaying.Presentation.Behaviors
{
    public class MarqueeLabelBehavior : Xamarin.Forms.Behavior<Xamarin.Forms.Label>
    {
        private SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToAnimation animation;

        protected void Target_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var label = sender as Xamarin.Forms.Label;

            if (e.PropertyName != Xamarin.Forms.VisualElement.WidthProperty.PropertyName) return;

            if (label.Width == -1) return;

            label.TranslationX = (label.Parent as Xamarin.Forms.Layout).Width;

            var translationWidth = label.TranslationX + label.Width;

            animation = new SmartSolucionesCuba.XFToolKit.Presentation.Transform.Animations.TranslateToAnimation
            {
                Target = label,
                TranslateX = label.Width * -1,
                Duration = System.TimeSpan.FromSeconds(translationWidth / 50).TotalMilliseconds.ToString()
            };

            animation.Completed += Animation_Completed;

            animation.Begin();
        }

        protected override void OnAttachedTo(Xamarin.Forms.Label label)
        {
            base.OnAttachedTo(label);

            label.PropertyChanged += Target_PropertyChanged;
        }

        protected override void OnDetachingFrom(Xamarin.Forms.Label label)
        {
            base.OnDetachingFrom(label);

            label.PropertyChanged -= Target_PropertyChanged;

            animation = null;
        }

        private void Animation_Completed(object sender, System.EventArgs e)
        {
            animation.Target.TranslationX = (animation.Target.Parent as Xamarin.Forms.Layout).Width;

            animation.Begin();
        }
    }
}
