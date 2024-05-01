namespace ForAllTheDogs.Server.Models
{
    public class Memes
    {
        public int memeId {  get; set; }
        public string memePhotoName { get; set; } = string.Empty;
        public DateTime dateCreated { get; set; }
    }
}
