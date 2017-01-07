using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarApplication.Models
{
    public class Manufacturer
    {
        [Key]
        public int ManufacturerID { get; set; }
        public string BrandName { get; set; }
        public virtual ICollection<BrandModel> BrandModel { get;set;}
    }
}