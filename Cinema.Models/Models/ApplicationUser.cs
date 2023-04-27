using Microsoft.AspNetCore.Identity;

namespace Cinema.Models.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public List<Customer> Customers { get; set; }
    }
}
