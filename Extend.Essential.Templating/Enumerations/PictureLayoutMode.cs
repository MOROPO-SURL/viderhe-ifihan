namespace SmartSolucionesCuba.Viderhe.Extend.Essential.Templating.Enumerations
{
    public enum PictureLayoutMode
    {
        //
        // Summary:
        //     Scale the image to fit the view. Some parts may be left empty (letter boxing).
        AspectFit = 0,
        //
        // Summary:
        //     Scale the image to fill the view. Some parts may be clipped in order to fill
        //     the view.
        //
        // Remarks:
        //     To be added.
        AspectFill = 1,
        //
        // Summary:
        //     Scale the image so it exactly fills the view. Scaling may not be uniform in X
        //     and Y.
        //
        // Remarks:
        //     To be added.
        Fill = 2,
        AspectFitWithOpaqueAspectFilledBySelf = 3
    }
}
