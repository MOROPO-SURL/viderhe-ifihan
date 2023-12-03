using MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Enumerations;

namespace MOROPO.VIDERHE.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class OverlapShapeKindExtensions
    {
        public static SkiaSharp.SKPath ToVerticalSKPath(this OverlapShapeKind target, OverlapAlignment overlapAlignment, int paintSurfaceWidth, int paintSurfaceHeight, double contentLayoutHeight, double extraHeight = 0d)
        {
            var overlapHeight = (contentLayoutHeight + extraHeight) * Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;
            var ovarlapVintageHeight = overlapHeight + paintSurfaceHeight / 12;

            if (overlapAlignment == OverlapAlignment.Start)
            {
                switch (target)
                {
                    case OverlapShapeKind.TriangleFullTop:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} L {2} {1} V 0 z",
                            ovarlapVintageHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            overlapHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            paintSurfaceWidth));

                    case OverlapShapeKind.TriangleFullBottom:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} L {2} {1} V 0 z",
                            overlapHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            ovarlapVintageHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            paintSurfaceWidth));

                    case OverlapShapeKind.Rectangle:
                    default:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} H {1} V 0 z",
                            overlapHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            paintSurfaceWidth));
                }
            }

            // For target == Enumerations.OverlapVerticalAlignment.Bottom
            switch (target)
            {
                case OverlapShapeKind.TriangleFullTop:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {2} H {3} V {1} z",
                        (paintSurfaceHeight - ovarlapVintageHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        (paintSurfaceHeight - overlapHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight,
                        paintSurfaceWidth));

                case OverlapShapeKind.TriangleFullBottom:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {2} H {3} V {1} z",
                        (paintSurfaceHeight - overlapHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        (paintSurfaceHeight - ovarlapVintageHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight,
                        paintSurfaceWidth));

                case OverlapShapeKind.Rectangle:
                default:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {1} H {2} V {0} z",
                        (paintSurfaceHeight - overlapHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight,
                        paintSurfaceWidth));
            }
        }
    }
}
