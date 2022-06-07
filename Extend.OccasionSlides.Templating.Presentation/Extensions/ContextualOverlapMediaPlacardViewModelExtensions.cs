namespace SmartSolucionesCuba.Viderhe.Extend.OccasionSlides.Templating.Presentation.Extensions
{
    public static class ContextualOverlapMediaPlacardViewModelExtensions
    {
        public static SkiaSharp.SKPath ToHorizontalSKPath(this Models.View.Contract.IContextualOverlapPlacardViewModelSKPathTransformable target, int paintSurfaceWidth, int paintSurfaceHeight, double placardWidth, double extraWidth = 0d)
        {
            var columnWidth = paintSurfaceWidth / System.Convert.ToDouble(target.OverlapSize.ToColumnCount());

            var contentBoxWidth = columnWidth * (target.OverlapSize.ToColumnCount() - 1) + extraWidth;

            if (target.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Left)
            {
                switch (target.OverlapShapeKind)
                {
                    case Enumerations.OverlapShapeKind.TriangleFullTop:
                        var bottomOvarlapVintageWidth = contentBoxWidth + (columnWidth / 2);

                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} L {1} {2} H 0 z", bottomOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), paintSurfaceHeight));

                    case Enumerations.OverlapShapeKind.TriangleFullBottom:
                        var topOvarlapVintageWidth = contentBoxWidth + (columnWidth / 2);

                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} L {1} {2} H 0 z", contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), topOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), paintSurfaceHeight));

                    case Enumerations.OverlapShapeKind.Rectangle:
                    default:
                        var paddingSimulationWidth = contentBoxWidth + placardWidth / Providers.ConstantProvider.CONTEXTUAL_OVERLAP_PADDING_BY_WRAPPER_WIDTH_RAZON;

                        return SkiaSharp.SKPath.ParseSvgPathData(string.Format("M 0 0 H {0} V {1} H 0 z", paddingSimulationWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), paintSurfaceHeight));
                }
            }

            // For target.OverlapHorizontalAlignment == Enumerations.OverlapHorizontalAlignment.Right
            switch (target.OverlapShapeKind)
            {
                case Enumerations.OverlapShapeKind.TriangleFullTop:
                    var topOverlapVintageExtraWith = columnWidth / 2;

                    var bottomOvarlapVintageWidth = contentBoxWidth + topOverlapVintageExtraWith;

                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {3} 0 h -{0} l {1} {2} H {3} z", bottomOvarlapVintageWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), topOverlapVintageExtraWith.ToString(System.Globalization.CultureInfo.InvariantCulture), paintSurfaceHeight, paintSurfaceWidth));

                case Enumerations.OverlapShapeKind.TriangleFullBottom:
                    var bottomOverlapVintageExtraWdith = columnWidth / 2;

                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format(
                        "M {3} 0 h -{0} l -{1} {2} H {3} z",
                        contentBoxWidth.ToString(System.Globalization.CultureInfo.InvariantCulture),
                        bottomOverlapVintageExtraWdith.ToString(System.Globalization.CultureInfo.InvariantCulture),
                        paintSurfaceHeight,
                        paintSurfaceWidth));

                case Enumerations.OverlapShapeKind.Rectangle:
                default:
                    var paddingSimulationWidth = contentBoxWidth + placardWidth / Providers.ConstantProvider.CONTEXTUAL_OVERLAP_PADDING_BY_WRAPPER_WIDTH_RAZON;

                    return SkiaSharp.SKPath.ParseSvgPathData(string.Format("M {2} 0 h -{0} V {1} H {2} z", paddingSimulationWidth.ToString(System.Globalization.CultureInfo.InvariantCulture), paintSurfaceHeight, paintSurfaceWidth));
            }
        }
    }
}
