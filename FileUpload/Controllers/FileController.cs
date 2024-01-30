using FileUpload.Models;
using FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
 
        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost("PostSingleFile")]
        public async Task<IActionResult> PostSingleFile([FromForm] FileUploadModel kapottFileModel)
        {
            try
            {
                await _fileService.PostFileAsync(kapottFileModel);
                //return im a teapot
                return Ok();
            }
            catch (Exception ex )
            {
                Console.Out.WriteLine(ex.Message);
                throw;
            }
           
        }

        [HttpPost("PostMultipleFile")]
        public async Task<IActionResult> PostMultipleFile([FromForm] List<FileUploadModel> kapottFileModels)
        {
            try
            {
                await _fileService.PostMultipleFileAsync(kapottFileModels);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.Out.WriteLine(ex.Message);
                throw;
            }
        }

      
    }
}
