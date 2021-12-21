[assembly: Xamarin.Forms.ExportRenderer(typeof(SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Views.Rendered.IconImageCell), typeof(SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Droid.Views.Renderer.IconImageCellRenderer))]

namespace SmartSolucionesCuba.Viderhe.Terminal.Dashboard.Droid.Views.Renderer
{
    public class IconImageCellRenderer : Xamarin.Forms.Platform.Android.ImageCellRenderer
    {
        protected override Android.Views.View GetCellCore(Xamarin.Forms.Cell item, Android.Views.View convertView, Android.Views.ViewGroup parent, Android.Content.Context context)
        {
            var cell = (Android.Widget.LinearLayout)base.GetCellCore(item, convertView, parent, context);

            var image = (Android.Widget.ImageView)cell.GetChildAt(0);

            image.SetScaleType(Android.Widget.ImageView.ScaleType.Center);

            return cell;
        }
    }
}