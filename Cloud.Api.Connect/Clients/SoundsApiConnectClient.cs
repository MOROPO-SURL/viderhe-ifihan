using MOROPO.VIDERHE.Cloud.Api.Common.Models;

namespace MOROPO.VIDERHE.Cloud.Api.Connect.Clients
{
    public class SoundsApiConnectClient
    {
        private readonly Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper;

        public SoundsApiConnectClient(Framework.Guama.Core.Presentation.API.Connect.Helpers.HttpClientHelper httpClientHelper)
        {
            this.httpClientHelper = httpClientHelper;
        }

        public async System.Threading.Tasks.Task UploadAsync(string about, byte[] imageData, string contentType, string fieldName, string fileName)
        {
            var formContent = new System.Net.Http.StringContent(about);

            var fileContent = new System.Net.Http.ByteArrayContent(imageData);

            fileContent.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
            {
                Name = fieldName,
                FileName = fileName
            };

            fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

            await httpClientHelper.PostFormAsync("account/sounds", new System.Net.Http.MultipartFormDataContent { formContent, fileContent });
        }

        public async System.Threading.Tasks.Task<Framework.Guama.Core.Presentation.Models.PaginationModel<SoundDisplayModel>> GetPageAsync(int page = 1)
        {
            return await httpClientHelper.GetAsync<Framework.Guama.Core.Presentation.Models.PaginationModel<SoundDisplayModel>>(string.Format("account/sounds/page/{0}", page));
        }

        public virtual async System.Threading.Tasks.Task EditAsync(SoundInputModel inputModel)
        {
            await httpClientHelper.PutAsync("account/sounds", inputModel);
        }

        public async System.Threading.Tasks.Task DeleteAsync(System.Guid id)
        {
            await httpClientHelper.DeleteAsync(string.Format("account/sounds/{0}", id));
        }
    }
}
