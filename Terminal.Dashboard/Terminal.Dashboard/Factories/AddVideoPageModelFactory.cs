using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class AddVideoPageModelFactory
    {
        public static AddVideoPageModel Build(Plugin.FilePicker.Abstractions.FileData targetFileData)
        {
            return new AddVideoPageModel
            {
                VideoSource = SmartSolucionesCuba.XFToolKit.Presentation.Sources.Video.VideoSource.FromFile(targetFileData.FilePath),
                Format = System.IO.Path.GetExtension(targetFileData.FilePath).Substring(1).ToUpper(),
                About = targetFileData.FileName
            };
        }
    }
}
