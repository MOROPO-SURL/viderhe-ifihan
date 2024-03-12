namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class AddSoundPageModelFactory
    {
        public static Models.Page.AddSoundPageModel Build(Plugin.FilePicker.Abstractions.FileData targetFileData)
        {
            return new Models.Page.AddSoundPageModel
            {
                AudioSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromFile(targetFileData.FilePath),
                Format = System.IO.Path.GetExtension(targetFileData.FilePath).Substring(1).ToUpper(),
                About = targetFileData.FileName
            };
        }
    }
}
