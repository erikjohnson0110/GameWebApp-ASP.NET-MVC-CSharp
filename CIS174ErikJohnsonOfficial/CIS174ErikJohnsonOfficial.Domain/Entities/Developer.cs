using System.ComponentModel.DataAnnotations;

namespace CIS174ErikJohnsonOfficial.Domain.Entities
{
    public class Developer
    {
        public System.Guid DeveloperId { get; set; }
        [StringLength(30)]
        public string Name { get; set; }

        [StringLength(30)]
        public string Email { get; set; }

        [StringLength(30)]
        public string Role { get; set; }
    }
}
