using System.ComponentModel.DataAnnotations;

namespace Y76.Entities
{
    public class TodoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description can't be longer than 100 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "IsCompleted is required.")]
        public bool IsCompleted { get; set; }

    }
}
