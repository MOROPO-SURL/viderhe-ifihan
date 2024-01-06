using MOROPO.VIDERHE.Terminal.Dashboard.Models.Page;

namespace MOROPO.VIDERHE.Terminal.Dashboard.Factories
{
    public static class AddImagePageModelFactory
    {
        public static AddImagePageModel Build(Plugin.FilePicker.Abstractions.FileData targetFileData)
        {
            var imageFormat = System.IO.Path.GetExtension(targetFileData.FilePath).Substring(1).ToUpper();

            if (imageFormat.Equals("jpg", System.StringComparison.CurrentCultureIgnoreCase))
            {
                imageFormat = "JPEG";
            }

            using (var imageFileStream = targetFileData.GetStream())
            {
                var imageData = new byte[imageFileStream.Length];

                imageFileStream.Read(imageData, 0, imageData.Length);

                return new AddImagePageModel
                {
                    ImageSource = Xamarin.Forms.ImageSource.FromStream(() => new System.IO.MemoryStream(imageData)),
                    Format = imageFormat,
                    About = targetFileData.FileName
                };
            }
        }
    }
}
