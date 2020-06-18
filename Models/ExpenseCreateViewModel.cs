using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpenseCreateViewModel
    {
        public int Id { get; set; }

        [DisplayName("bedrag")]
        [Range(0, 9999999999999999999, ErrorMessage = "niet onder nul")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int PaymentStatusId { get; set; }
        public List<SelectListItem> PaymentStatusus { get; set; } = new List<SelectListItem>();
        public IEnumerable<int> SelectedProductId { get; set; }
        public List<SelectListItem> Products { get; set; } = new List<SelectListItem>();
    }
}
