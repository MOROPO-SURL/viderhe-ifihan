namespace SmartSolucionesCuba.Viderhe.Cloud.Managers
{
    public class SoundFileManager
    {
        private readonly Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions;

        public SoundFileManager(Microsoft.Extensions.Options.IOptions<Options.MediaPathOptions> mediaPathOptions)
        {
            this.mediaPathOptions = mediaPathOptions;
        }

        public void DeleteFile(Persistence.Entities.Sound target)
        {
            System.IO.File.Delete(GetAbsoluteFilePath(target));
        }

        public string GetAbsoluteFilePath(Persistence.Entities.Sound target)
        {
            return System.IO.Path.Combine(mediaPathOptions.Value.SoundMediaPath, string.Format("{0}.{1}", target.Id, target.Extension));
        }

        public byte[] GetFileContent(Persistence.Entities.Sound target)
        {
            byte[] result;

            using (var file = System.IO.File.OpenRead(GetAbsoluteFilePath(target)))
            {
                result = new byte[file.Length];

                file.Read(result, 0, (int)file.Length);

                file.Close();
            }

            return result;
        }

        public void SaveFileContent(System.Guid targetId, byte[] content)
        {
            System.IO.File.WriteAllBytes(GetAbsoluteFilePath(new Persistence.Entities.Sound { Id = targetId, Extension = "mp3" }), content);
        }
    }
}
