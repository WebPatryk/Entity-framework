using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class CarMovie
    {
        public int Id { get; set; }
        [Display(Name = "Car title")]
        public string CarTitle { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
