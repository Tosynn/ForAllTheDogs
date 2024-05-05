namespace ForAllTheDogs.Server.Models
{
    public class Adoption
    {
        public int petId;
        public string petName { get; set; } = string.Empty;
        public string petDescription { get; set; } = string.Empty;
        public string petBreed { get; set;} = string.Empty;
        
        public string petPhotoFileName { get; set; } = string.Empty;

        public string petAge { get; set; } = string.Empty;

    }
}
