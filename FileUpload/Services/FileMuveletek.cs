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
                    Name= kapottFileModel.File.FileName,
                    Type= kapottFileModel.FileType

                };
                using (var memoryStream = new MemoryStream())
                {
                    kapottFileModel.File.CopyTo(memoryStream);
                    ujFajl.Data=memoryStream.ToArray();
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

        public async Task PostMultipleFileAsync(List<FileUploadModel> kapottFileModels)
        {
            foreach (var kapottFileModel in kapottFileModels)
            {
                try
                {
                    // Create and upload a new file
                    FileModel ujFajl = new FileModel
                    {
                        Name = kapottFileModel.File.FileName,
                        Type = kapottFileModel.FileType
                    };
                    using (var memoryStream = new MemoryStream())
                    {
                        kapottFileModel.File.CopyTo(memoryStream);
                        ujFajl.Data = memoryStream.ToArray();
                    }
                    var result = _context.Add(ujFajl);
                }
                catch (Exception)
                {
                    Console.Out.WriteLine("Hiba a fájl feltöltésekor");
                    throw;
                }
            }
            await _context.SaveChangesAsync();
        }

    }
}
