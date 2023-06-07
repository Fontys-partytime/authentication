using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationWebApi.Entities
{
    [Table("users")]
    public class Useraccount
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
