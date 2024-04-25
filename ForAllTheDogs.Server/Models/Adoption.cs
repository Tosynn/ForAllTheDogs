namespace ForAllTheDogs.Server.Models
{
    public class Adoption
    {
        public int petID;
        public string petName { get; set; } = string.Empty;
        public string petDescription { get; set; } = string.Empty;
        public string petType { get; set;} = string.Empty;

        public int petAge;

    }
}
