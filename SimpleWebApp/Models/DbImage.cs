namespace SimpleWebApp.Models
{
    public class DbImage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public byte[] Full { get; set; }

        public byte[] Thumbnail { get; set; }
    }
}