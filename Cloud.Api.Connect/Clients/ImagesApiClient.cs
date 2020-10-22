namespace SmartSolucionesCuba.Videre.Cloud.Api.Connect.Clients
{
    public class ImagesApiClient
    {
        private readonly SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper;

        public ImagesApiClient(SAPRESSC.Core.Api.Connect.Helpers.HttpClientHelper httpClientHelper)
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

            await httpClientHelper.PostFormAsync("business/images", new System.Net.Http.MultipartFormDataContent { formContent, fileContent });
        }

        public async System.Threading.Tasks.Task<SAPRESSC.Core.Common.Models.PaginationModel<Common.Models.ImageDisplayModel>> GetPageAsync(int page = 1)
        {
            return await httpClientHelper.GetAsync<SAPRESSC.Core.Common.Models.PaginationModel<Common.Models.ImageDisplayModel>>(string.Format("business/images/page/{0}", page));
        }

        public virtual async System.Threading.Tasks.Task EditAsync(Common.Models.ImageInputModel inputModel)
        {
            await httpClientHelper.PutAsync("business/images", inputModel);
        }

        public async System.Threading.Tasks.Task DeleteAsync(System.Guid imageId)
        {
            await httpClientHelper.DeleteAsync(string.Format("business/images/{0}", imageId));
        }
    }
}
