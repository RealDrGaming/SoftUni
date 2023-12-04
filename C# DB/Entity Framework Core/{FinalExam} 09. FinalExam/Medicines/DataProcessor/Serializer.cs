namespace Medicines.DataProcessor
{
    using Medicines.Data;
    using Medicines.Data.Models;
    using Medicines.DataProcessor.ExportDtos;
    using Medicines.Helpers;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportPatientsWithTheirMedicines(MedicinesContext context, string date)
        {
            var patients = context.Patients
                .Where(p => p.PatientsMedicines.Any(pm => pm.Medicine.ProductionDate > DateTime.Parse(date)))
                .Select(p => new ExportPatientDto
                {
                    FullName = p.FullName,
                    AgeGroup = p.AgeGroup.ToString().ToLower(),
                    Gender = p.Gender.ToString().ToLower(),
                    Medicines = p.PatientsMedicines
                    .Select(pm => new ExportMedicineDto
                    {
                        Name = pm.Medicine.Name,
                        Price = pm.Medicine.Price,
                        Category = pm.Medicine.Category.ToString().ToLower(),
                        Producer = pm.Medicine.Producer,
                        ExpiryDate = pm.Medicine.ExpiryDate
                    })
                    .OrderByDescending(m => m.ExpiryDate)
                    .ThenBy(m => m.Price)
                    .ToArray()
                })
                .OrderByDescending(p => p.Medicines.Count())
                .ThenBy(p => p.FullName)
                .ToList();

            return XmlSerializationHelper.Serialize(patients, "Patients");
        }

        public static string ExportMedicinesFromDesiredCategoryInNonStopPharmacies(MedicinesContext context, int medicineCategory)
        {
            var medicines = context.Medicines
                .Where(m => (int)m.Category == medicineCategory)
                .Where(m => m.Pharmacy.IsNonStop)
                .Select(m => new
                {
                    Name = m.Name,
                    Price = m.Price.ToString("f2"),
                    Pharmacy = new
                    {
                        Name = m.Pharmacy.Name,
                        PhoneNumber = m.Pharmacy.PhoneNumber
                    }
                })
                .OrderBy(m => m.Price)
                .ThenBy(m => m.Name)
                .ToList();

            return JsonConvert.SerializeObject(medicines, Formatting.Indented);
        }
    }
}
