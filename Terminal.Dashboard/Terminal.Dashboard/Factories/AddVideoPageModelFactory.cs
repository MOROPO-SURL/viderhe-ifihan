namespace SmartSolucionesCuba.Videre.Terminal.Dashboard.Factories
{
    public static class AddVideoPageModelFactory
    {
        public static Models.Page.AddVideoPageModel Build(Plugin.FilePicker.Abstractions.FileData targetFileData)
        {
            return new Models.Page.AddVideoPageModel
            {
                VideoSource = XFToolKit.Presentation.Sources.Video.VideoSource.FromFile(targetFileData.FilePath),
                Format = System.IO.Path.GetExtension(targetFileData.FilePath).Substring(1).ToUpper(),
                About = targetFileData.FileName
            };
        }
    }
}
