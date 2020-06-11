using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpeseCreateViewModel
    {
        public int Id { get; set; }

        [DisplayName("bedrag")]
        [Range(0, 9999999999999999999, ErrorMessage = "niet onder nul")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: yyyy-MM-dd}")]
        public DateTime Date { get; set; }
        public string Description { get; set; }

    }
}
