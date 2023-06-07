using System.ComponentModel.DataAnnotations;
namespace AuthenticationWebApi.Dtos
{
        public record UseraccountDto(Guid Id, string Email, string Username, string Role);

        public record CreateUseraccountDto([Required]string Email, [Required] string Username, [Required] string Password);
}
