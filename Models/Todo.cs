using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Todo
    {
        public long Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool Completed { get; set; }
    }
}
