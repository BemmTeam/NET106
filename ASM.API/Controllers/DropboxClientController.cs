using ASM.SHARE.Models;
using Dropbox.Api;
using Dropbox.Api.Files;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ASM.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DropboxClientController : Controller
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile()
        {
            var fileImage = Request.Form.Files[0];

            using (var dbx = new DropboxClient("sl.BMtCiKehvakPNgiBQkZ6Kj4SgISBvM-UAmGjzKmiVMvG9OB64mJS4wpZxUlkUO8Owx72j5d51wvOGCnu1ooz6-uHmYRf4y9nZdhienPQCMfcW5cyL5IPDV4GikTr4FQuYtQTWjjA8UM"))
            {
                string targetFolder = "/uploads";
                var targetFileName = Guid.NewGuid().ToString().Substring(0, 6) + DateTime.Today.ToString("ddmm") + Path.GetExtension(fileImage.FileName);

                string path = "";
                using (var memoryStream = new MemoryStream())
                {


                    var updated = await dbx.Files.UploadAsync(
                         targetFolder + "/" + targetFileName,
                         WriteMode.Overwrite.Instance,
                         body: fileImage.OpenReadStream());
                    path = updated.PathDisplay;
                }

                return Ok(new DataJsonResult { IsSuccess = true, Message = "Upload file thành công !", Data = path });
            }
        }



    }
}
