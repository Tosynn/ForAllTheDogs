namespace ForAllTheDogs.Server.Models
{
    public class FoodModel
    {
        public int foodId { get; set; }
        public string foodName { get; set; } = string.Empty;
        public string foodDescription { get; set;} = string.Empty;
        public string foodType { get; set;}= string.Empty;

    }
}
