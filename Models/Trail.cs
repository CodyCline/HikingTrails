using System.ComponentModel.DataAnnotations;
namespace HikingTrails.Models
{
    public abstract class BaseEntity {}
    public class Trail : BaseEntity
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
 
        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        public string Description { get; set; }
 
        [Required]
        public int Length { get; set;}

        [Required]
        public int ElevationChange { get; set; }

        [Required]
        public int Latitude { get; set; }

        [Required]
        public int Longitude { get; set; }
    }
}