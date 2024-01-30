using FileUpload.Models;
using System.IO;

namespace FileUpload.Services
{
    public class FileMuveletek : IFileService
    {
        public readonly FileContext _context;
        public FileMuveletek(FileContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Task<MemoryStream> DownloadFileById(int fileName)
        {
            throw new NotImplementedException();
        }

        public async Task PostFileAsync(FileUploadModel kapottFileModel)
        {
            try
            {
                //új fájl létrehozása és feltöltése
                FileModel ujFajl = new FileModel
                {
                    FileName = kapottFileModel.FileDetails.FileName,
                    FileType = kapottFileModel.FileType

                };
                using (var memoryStream = new MemoryStream())
                {
                    kapottFileModel.FileDetails.CopyTo(memoryStream);
                    ujFajl.FileData = memoryStream.ToArray();
                }
                var result = _context.Add(ujFajl);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                Console.Out.WriteLine("Hiba a fájl feltöltésekor");
                throw;
            }
        }

        public async Task PostMultipleFileAsync(List<FileUploadModel> fileLista)
        {
            try
            {
                foreach(FileUploadModel f in fileLista)
                {
                    FileModel ujFajl= new FileModel { FileName = f.FileDetails.FileName, FileType = f.FileType };
                    using (var memoryStream = new MemoryStream())
                    {
                        f.FileDetails.CopyTo(memoryStream);
                        ujFajl.FileData = memoryStream.ToArray();
                    }
                    var result = _context.Add(ujFajl);
                    
            }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex )
            {
                await Console.Out.WriteLineAsync("Hiba a fájl feltöltésekor " + ex.Message);
                throw;
            }
           
        }
    }
}
