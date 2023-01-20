using PetsAlone.Core;

namespace PetsAlone.Angular.Models
{
    public class AuthenticationInfo
    {
        public string Token { get; set; }
        public User Profile { get; set; }
    }
}