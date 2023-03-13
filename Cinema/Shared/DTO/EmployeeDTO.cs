namespace Cinema.Shared.DTO
{
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
