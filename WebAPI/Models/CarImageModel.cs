namespace WebAPI.Models
{
    public class CarImageModel
    {
        public IFormFile files { get; set; }
        public string? FilePath { get; set; }
        public int? CarId { get; set; }
    }
}
