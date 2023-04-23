using Microsoft.AspNetCore.Http;

namespace Cinema.Shared.DTO
{
    public class MoveAndImageDTO
    {
        public MovieDTO MovieDTO { get; set; }
        public IFormFile Content { get; set; }
    }
}
