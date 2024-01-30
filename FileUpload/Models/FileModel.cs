namespace FileUpload.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Data { get; set; }

        public FileTypes Type { get; set; }


    }
}
