using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Data.Entities
{
    public class Country : EntityBase
    {
        [Required]
        public string Name { get; set; } = "";
        public string? Code { get; set; } = "";

        public virtual List<City> Cities { get; set; } = new List<City>();
    }
}
