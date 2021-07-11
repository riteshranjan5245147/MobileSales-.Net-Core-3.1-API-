using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MobileStoreMonthlyReport.Models
{
    public class Sales
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max 50 characters")]
        public string ProductName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Max 50 characters")]
        public string ProductModel { get; set; }
        [Required]
        public int CP { get; set; }
        [Required]
        public int SP { get; set; }
        [Required]
        public DateTime DateOfSelling { get; set; }
    }
}
