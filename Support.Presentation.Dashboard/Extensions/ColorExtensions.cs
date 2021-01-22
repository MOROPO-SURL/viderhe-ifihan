namespace SmartSolucionesCuba.Viderhe.Support.Presentation.Dashboard.Extensions
{
    public static class ColorExtensions
    {
        public static string ToSolidHex(this Xamarin.Forms.Color target)
        {
            return string.Format("#{0}", target.ToHex().Substring(3));
        }
    }
}
