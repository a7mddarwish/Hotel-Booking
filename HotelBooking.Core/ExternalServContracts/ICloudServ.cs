using HotelBooking.Core.DTOs;
using HotelBooking.Core.Helpers;
using Microsoft.AspNetCore.Http;

namespace HotelBooking.Core.ExternalServContracts
{
    public interface ICloudServ
    {
        public Task<OperationResult<FullImgInfoDTO>> UploadImageAsync(IFormFile file);

        public Task<OperationResult<List<FullImgInfoDTO>>> UploadImagesAsync(List<IFormFile> files);

        public Task<OperationResult<string>> DeleteImageAsync(string deleteUrl);

        public Task<OperationResult<FullImgInfoDTO>> ReplaceImageAsync(string oldDeleteUrl, IFormFile newFile);


    }
}
