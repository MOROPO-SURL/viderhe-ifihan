using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Managers
{
    public class ImageFileManager : Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade
    {
        private readonly Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions;

        public ImageFileManager(Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions)
        {
            this.mediaPathOptions = mediaPathOptions;
        }

        public void DeleteImageFile(Image image)
        {
            System.IO.File.Delete(GetImageAbsoluteFilePath(image));
        }

        public string GetImageAbsoluteFilePath(Image image)
        {
            return System.IO.Path.Combine(mediaPathOptions.Value.ImageMediaPath, string.Format("{0}{1}", image.Id, MimeTypes.MimeTypeMap.GetExtension(image.ContentType)));
        }

        public byte[] GetImageFileContent(Image image)
        {
            byte[] result;

            using (var file = System.IO.File.OpenRead(GetImageAbsoluteFilePath(image)))
            {
                result = new byte[file.Length];

                file.Read(result, 0, (int)file.Length);

                file.Close();
            }

            return result;
        }

        public string GetImageRelativeFilePath(Image image)
        {
            return null;
        }

        public void SaveImageFileContent(System.Guid imageId, byte[] content, string contentType)
        {
            System.IO.File.WriteAllBytes(GetImageAbsoluteFilePath(new Image { Id = imageId, ContentType = contentType }), content);
        }
    }
}
