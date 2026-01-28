using System.ComponentModel.DataAnnotations;

namespace Jakub_Dyoniziak_web_app.Models
{
    public class Vote
    {
        public int Id { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; } = null!;

        [Required]
        public string UserID { get; set; } = string.Empty;

        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    }
}
