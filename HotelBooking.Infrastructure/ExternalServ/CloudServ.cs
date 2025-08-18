using HotelBooking.Core.DTOs;
using HotelBooking.Core.ExternalServContracts;
using HotelBooking.Core.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;
using System.Text.Json;

namespace HotelBooking.Infrastructure.ExternalServ
{
    public class CloudServ : ICloudServ
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiKey;

        public CloudServ(IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _httpClientFactory = httpClientFactory;
            _apiKey = config["ImgBB:ApiKey"] ?? throw new ArgumentNullException("ImgBB:ApiKey not found in config");
        }

        public async Task<OperationResult<string>> DeleteImageAsync(string deleteUrl)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(deleteUrl);

            if (!response.IsSuccessStatusCode)
                return OperationResult<string>.Failure($"ImgBB delete failed: ");

            return OperationResult<string>.SuccessOperation("Deleted successfully");

        }

        public async Task<OperationResult<FullImgInfoDTO>> ReplaceImageAsync(string oldDeleteUrl, IFormFile newFile)
        {
            await DeleteImageAsync(oldDeleteUrl);
            return await UploadImageAsync(newFile);
        }

        public async Task<OperationResult<FullImgInfoDTO>> UploadImageAsync(IFormFile file)
        {
            var client = _httpClientFactory.CreateClient();

            using var content = new MultipartFormDataContent();

            using var stream = file.OpenReadStream();

            var fileContent = new StreamContent(stream);

            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType ?? "application/octet-stream");
            content.Add(fileContent, "image", file.FileName);


            var url = $"https://api.imgbb.com/1/upload?key={_apiKey}";

            var response = await client.PostAsync(url, content);

            var body = await response.Content.ReadAsStringAsync();


            if (!response.IsSuccessStatusCode)
                throw new Exception($"ImgBB upload failed: {body}");

            var json = JsonDocument.Parse(body);
            var data = json.RootElement.GetProperty("data");

            return OperationResult<FullImgInfoDTO>.SuccessOperation(new FullImgInfoDTO
            {
                DisplayUrl = data.GetProperty("display_url").GetString()!,
                DeleteUrl = data.GetProperty("delete_url").GetString()!
            }
            );
        }

        public async Task<OperationResult<List<FullImgInfoDTO>>> UploadImagesAsync(List<IFormFile> files)
        {
            var results = new OperationResult<List<FullImgInfoDTO>>();

            foreach (var file in files)
            {
                  var res = await UploadImageAsync(file);

                if (!res.Success)
                    results.Data.Add(res.Data);
            }

            return results;
        }

        
       


       

  

      
    }
}
