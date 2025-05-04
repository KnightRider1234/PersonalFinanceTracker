using PersonalFinanceTracker.Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceTracker.Shared.DTOs
{
    public class EntryDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description can't exceed 100 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Amount is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Entry type is required.")]
        public EntryType Type { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(EntryDto), nameof(ValidateDate))]
        public DateTime? Date { get; set; }

        public static ValidationResult? ValidateDate(DateTime? date, ValidationContext context)
        {
            return date > DateTime.Today
                ? new ValidationResult("Date cannot be in the future.")
                : ValidationResult.Success;
        }
    }
}