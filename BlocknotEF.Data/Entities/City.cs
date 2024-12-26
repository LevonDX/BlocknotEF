using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Data.Entities
{
    public class City : EntityBase
    {
        public string Name { get; set; } = "";

        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country? Country { get; set; }
    }
}
