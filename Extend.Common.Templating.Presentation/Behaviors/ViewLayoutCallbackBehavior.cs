namespace MOROPO.VIDERHE.Extend.Common.Templating.Presentation.Behaviors
{
    public class ViewLayoutCallbackBehavior : Xamarin.Forms.Behavior<Xamarin.Forms.View>
    {
        public System.Action LayoutCallbackAction { get; set; }

        protected void Target_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var view = sender as Xamarin.Forms.View;

            if (e.PropertyName != Xamarin.Forms.VisualElement.HeightProperty.PropertyName) return;

            if (view.Height == -1) return;

            LayoutCallbackAction.Invoke();
        }

        protected override void OnAttachedTo(Xamarin.Forms.View label)
        {
            base.OnAttachedTo(label);

            label.PropertyChanged += Target_PropertyChanged;
        }

        protected override void OnDetachingFrom(Xamarin.Forms.View label)
        {
            base.OnDetachingFrom(label);

            label.PropertyChanged -= Target_PropertyChanged;

            LayoutCallbackAction = null;
        }
    }
}
