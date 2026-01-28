using System.ComponentModel.DataAnnotations;

namespace Jakub_Dyoniziak_web_app.Models
{
    public class Survey
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string CreateByUserId { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Option> Options { get; set; } = new List<Option>();
    }
}
