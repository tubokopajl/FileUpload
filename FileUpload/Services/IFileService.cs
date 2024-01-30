using FileUpload.Models;

namespace FileUpload.Services
{
    public interface IFileService
    {
        public Task PostFileAsync(FileUploadModel kapottFileModel);

        public Task PostMultipleFileAsync(List<FileUploadModel> kapottFileModel);

        public Task<MemoryStream> DownloadFileById(int fileName);
    }
}
