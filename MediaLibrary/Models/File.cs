namespace MediaLibrary.Models
{
    public class File
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public string FullName { get; set; }
    }
}
