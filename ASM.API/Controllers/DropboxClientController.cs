using ASM.API.Model;
using ASM.SHARE.Dtos;
using ASM.SHARE.Dtos.DropBox;
using ASM.SHARE.Models;
using AutoMapper;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DropboxClientController : Controller
    {
        private readonly DropBoxApiConfig DropBoxApiConfigs;
        private readonly IMapper mapper;

        public DropboxClientController(IOptions<DropBoxApiConfig> dropBoxApiConfigs, IMapper mapper)
        {
            DropBoxApiConfigs = dropBoxApiConfigs.Value;
            this.mapper = mapper;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile()
        {
            var fileImage = Request.Form.Files[0];

            using (var dbx = new DropboxClient(DropBoxApiConfigs.Token))
            {
                string targetFolder = DropBoxApiConfigs.Folder;
                var targetFileName = Guid.NewGuid().ToString().Substring(0, 6) + DateTime.Today.ToString("ddmm") + Path.GetExtension(fileImage.FileName);

                UploadResponse reponse = new UploadResponse();
                using (var memoryStream = new MemoryStream())
                {


                    var updated = await dbx.Files.UploadAsync(
                         targetFolder + "/" + targetFileName,
                         WriteMode.Overwrite.Instance,
                         body: fileImage.OpenReadStream());

                    reponse.Path = updated.PathDisplay;
                    reponse.Name = updated.Name;
                    reponse.Message = "Upload file thành công !";
                    reponse.IsSuccess = true;
                    reponse.Size = (int)updated.Size;
                    reponse.Thumb = await GetAThumbnail(updated.PathDisplay);
                }

                return Ok(reponse);
            }
        }
        [HttpGet("[action]")]
        public IActionResult GetBearerToken(string password)
        {
            if (DropBoxApiConfigs.Password == password)
            {
                return Ok(new DataJsonResult
                {
                    IsSuccess = true,
                    Message = "Lấy Token thành công !",
                    Data = DropBoxApiConfigs.Token
                });


            }
            return Ok(new DataJsonResult
            {
                IsSuccess = false,
                Message = "Lấy Token thất bại mật khẩu không đúng !",
            });
        }


        [HttpPost("[action]")]
        public async Task<IActionResult> GetThumbnail(List<SHARE.DropBox.Dtos.SendPostGetThumb> paths)
        {

            using (var dbx = new DropboxClient(DropBoxApiConfigs.Token))
            {
                string targetFolder = DropBoxApiConfigs.Folder;

                ThumbnailSize size = new ThumbnailSize();
                size = ThumbnailSize.W256h256.Instance;
                GetThumbnailBatchArg getThumbnailBatchArg = new GetThumbnailBatchArg(paths.Select(p => new ThumbnailArg(p.Path , size: size)));


                var result = await dbx.Files.GetThumbnailBatchAsync(getThumbnailBatchArg);
              
                paths = mapper.Map<List<SHARE.DropBox.Dtos.SendPostGetThumb>>(result.Entries.Select(p => p.AsSuccess.Value.Thumbnail));


                return Ok(new DataJsonResult { IsSuccess = true, Message = "lấy danh sách thành công !", Data = paths });
            }
        }

        [HttpGet("[action]")]
        public async Task<string> GetAThumbnail(string path)
        {

            using (var dbx = new DropboxClient(DropBoxApiConfigs.Token))
            {

                ThumbnailSize size = new ThumbnailSize();
                size = ThumbnailSize.W256h256.Instance;
                ThumbnailArg n = new ThumbnailArg(path , size: size);
                GetThumbnailBatchArg getThumbnailBatchArg = new GetThumbnailBatchArg(new List<ThumbnailArg> { n });


                var result = await dbx.Files.GetThumbnailBatchAsync(getThumbnailBatchArg);


                return "data:image/png;base64, " + result.Entries[0].AsSuccess.Value.Thumbnail.ToString();
            }
        }

        [HttpDelete("[action]")]
        public async Task<IActionResult> DeleteFile(string path)
        {

            using (var dbx = new DropboxClient(DropBoxApiConfigs.Token))
            {
                string targetFolder = DropBoxApiConfigs.Folder;


                using (var memoryStream = new MemoryStream())
                {
                    DeleteArg deleteArg = new DeleteArg(path);
                    var result = await dbx.Files.DeleteV2Async(deleteArg);
                }

                return NoContent();
            }
        }

    }
}
