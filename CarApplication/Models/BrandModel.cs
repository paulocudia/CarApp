using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace CarApplication.Models
{
    public class BrandModel
    {
        [Key]
        public int ModelID { get; set; }
        public string ModelName { get; set; }
        public string ModelPrice { get; set; }
        public int ManufacturerID { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }        
    }
}
