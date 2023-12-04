using Medicines.Data.Models.Enums;
using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Medicines.DataProcessor.ImportDtos
{
    public class ImportPatientDto
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [JsonProperty("FullName")]
        public string FullName { get; set; }

        [Required]
        [Range(0, 2)]
        [JsonProperty("AgeGroup")]
        public int AgeGroup { get; set; }

        [Required]
        [Range(0, 1)]
        [JsonProperty("Gender")]
        public int Gender { get; set; }

        [JsonProperty("Medicines")]
        public int[] MedicineIds { get; set; }
    }
}
