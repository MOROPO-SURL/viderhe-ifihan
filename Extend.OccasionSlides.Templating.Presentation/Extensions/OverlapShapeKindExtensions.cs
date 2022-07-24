namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class OverlapShapeKindExtensions
    {
        public static SkiaSharp.SKPath ToVerticalSKPath(this Enumerations.OverlapShapeKind target, Enumerations.OverlapAlignment overlapAlignment, int paintSurfaceWidth, int paintSurfaceHeight, double contentLayoutHeight, double extraHeight = 0d)
        {
            var ovarlapVintageHeight = contentLayoutHeight + (paintSurfaceHeight / 12);

            if (overlapAlignment == Enumerations.OverlapAlignment.Start)
            {
                switch (target)
                {
                    case Enumerations.OverlapShapeKind.TriangleFullTop:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} L {2} {1} V 0 z",
                            ovarlapVintageHeight.ToString(System.Globalization.CultureInfo.InvariantCulture), 
                            contentLayoutHeight.ToString(System.Globalization.CultureInfo.InvariantCulture), 
                            paintSurfaceWidth));

                    case Enumerations.OverlapShapeKind.TriangleFullBottom:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} L {2} {1} V 0 z", 
                            contentLayoutHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            ovarlapVintageHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            paintSurfaceWidth));

                    case Enumerations.OverlapShapeKind.Rectangle:
                    default:
                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                            "M 0 0 V {0} H {1} V 0 z",
                            contentLayoutHeight.ToString(System.Globalization.CultureInfo.InvariantCulture),
                            paintSurfaceWidth));
                }
            }

            // For target == Enumerations.OverlapVerticalAlignment.Bottom
            switch (target)
            {
                case Enumerations.OverlapShapeKind.TriangleFullTop:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {2} H {3} V {1} z",
                        (paintSurfaceHeight - ovarlapVintageHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        (paintSurfaceHeight - contentLayoutHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight, 
                        paintSurfaceWidth));

                case Enumerations.OverlapShapeKind.TriangleFullBottom:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {2} H {3} V {1} z",
                        (paintSurfaceHeight - contentLayoutHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        (paintSurfaceHeight - ovarlapVintageHeight).ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight,
                        paintSurfaceWidth));

                case Enumerations.OverlapShapeKind.Rectangle:
                default:
                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M 0 {0} V {1} H {2} V {0} z",
                        (paintSurfaceHeight - contentLayoutHeight).ToString(System.Globalization.CultureInfo.InvariantCulture), 
                        paintSurfaceHeight, 
                        paintSurfaceWidth));
            }
        }
    }
}
