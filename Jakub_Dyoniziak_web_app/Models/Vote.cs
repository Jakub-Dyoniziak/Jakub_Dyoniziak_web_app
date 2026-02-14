using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Jakub_Dyoniziak_web_app.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; } = null!;

        [Required]
        public string UserId { get; set; } = string.Empty;

        public IdentityUser User { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
