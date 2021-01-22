namespace SmartSolucionesCuba.Viderhe.Terminal.Player.Views.Rendered
{
    public class IndeterminableProgressBarView : Xamarin.Forms.ProgressBar
    {
        public static readonly Xamarin.Forms.BindableProperty IsIndeterminateProperty = Xamarin.Forms.BindableProperty.Create(nameof(IsIndeterminate), typeof(bool), typeof(IndeterminableProgressBarView), true);

        public bool IsIndeterminate
        {
            set { SetValue(IsIndeterminateProperty, value); }
            get { return (bool)GetValue(IsIndeterminateProperty); }
        }
    }
}
