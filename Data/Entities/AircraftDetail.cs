using Data.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities
{
    public class AircraftDetail : BaseEntity
    {
        [Required]
        [StringLength(128)]
        public string Make { get; set; }

        [Required]
        [StringLength(128)]
        public string Model { get; set; }

        public string Registration { get; set; }

        [Required]
        [StringLength(255)]
        public string Location { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [PastDateValidation]
        public DateTime Datetime { get; set; }

        public string FileSource { get; set; }

    }
}
