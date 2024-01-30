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
            if (kapottFileModels == null || kapottFileModels.Count == 0)
            {
                return BadRequest();
            }
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

        [HttpGet("DownloadFile")]
        public async Task<IActionResult> DownloadFileAsync(int id)
        {
           //check if exist
           var fajl = await _fileService.DownloadFileById(id);
            if (fajl == null)
            {
                return NotFound();
              }
            try
            {
                MemoryStream path = await _fileService.DownloadFileById(id);
                return File(path, "text/plain", "file.txt");
            }
            catch (Exception )
            {
                return StatusCode(StatusCodes.Status500InternalServerError);

                throw;
            }
        }

      
    }
}
