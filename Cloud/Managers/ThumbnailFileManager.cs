using MOROPO.Framework.Guama.Media.Persistence.Entities;

namespace MOROPO.VIDERHE.Cloud.Managers
{
    public class ThumbnailFileManager : Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IThumbnailFileManagerFacade
    {
        private readonly Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions;

        public ThumbnailFileManager(Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions)
        {
            this.mediaPathOptions = mediaPathOptions;
        }

        public void DeleteThumbnailFile(Thumbnail thumbnail)
        {
            System.IO.File.Delete(GetThumbnailAbsoluteFilePath(thumbnail));
        }

        public string GetThumbnailAbsoluteFilePath(Thumbnail thumbnail)
        {
            var extension = thumbnail.ContentType.Split('/')[1].ToLowerInvariant();

            return System.IO.Path.Combine(mediaPathOptions.Value.ThumbnailMediaPath, string.Format("{0}.{1}", thumbnail.Id, extension));
        }

        public byte[] GetThumbnailFileContent(Thumbnail thumbnail)
        {
            byte[] result;

            using (var file = System.IO.File.OpenRead(GetThumbnailAbsoluteFilePath(thumbnail)))
            {
                result = new byte[file.Length];

                file.Read(result, 0, (int)file.Length);

                file.Close();
            }

            return result;
        }

        public string GetThumbnailRelativeFilePath(Thumbnail thumbnail)
        {
            return null;
        }

        public void SaveThumbnailFileContent(System.Guid thumbnailId, byte[] content, string contentType)
        {
            System.IO.File.WriteAllBytes(GetThumbnailAbsoluteFilePath(new Thumbnail { Id = thumbnailId, ContentType = contentType }), content);
        }
    }
}
