using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickleballClubManagement.Models
{
    [Table("395_News")]    public class News    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Content { get; set; } = string.Empty;
        
        public bool IsPinned { get; set; }
        
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
