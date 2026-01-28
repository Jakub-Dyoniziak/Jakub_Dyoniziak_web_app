using System.ComponentModel.DataAnnotations;

namespace Jakub_Dyoniziak_web_app.Models
{
    public class Option
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Text { get; set; } = string.Empty;

        public int SurveyId { get; set; }
        public Survey Survey { get; set; } = null!;

        public ICollection<Vote> Votes { get; set; } = new List<Vote>();
    }
}
