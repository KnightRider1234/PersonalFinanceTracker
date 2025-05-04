using PersonalFinanceTracker.Shared.Enums;
using System.ComponentModel.DataAnnotations;

namespace PersonalFinanceTracker.API.Models
{
    public class Entry
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public EntryType Type { get; set; }
        public DateTime? Date { get; set; }
    }
}