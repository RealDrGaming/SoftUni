using Medicines.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class ImportPharmacyDTO
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        [XmlElement("Name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"\([0-9]{3}\) [0-9]{3}\-[0-9]{4}")]
        [XmlElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlAttribute("non-stop")]
        public string IsNonStop { get; set; }

        [XmlArray("Medicines")]
        public ImportMedicineDTO[] Medicines { get; set; }
    }
}
