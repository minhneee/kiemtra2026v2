using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PickleballClubManagement.Models
{
    [Table("395_MatchSets")]
    public class MatchSet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int MatchId { get; set; }

        [Required]
        public int SetNumber { get; set; }

        [Required]
        public int TeamAScore { get; set; }

        [Required]
        public int TeamBScore { get; set; }

        // Navigation property
        [ForeignKey("MatchId")]
        public virtual Match? Match { get; set; }
    }
}
