using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlocknotEF.Data.Entities
{
    public class Record : EntityBase
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string? Surname { get; set; }

        public string? PhoneNumber { get; set; }

        public DateTime CreateDate { get; set; } = DateTime.UtcNow;

        [ForeignKey("City")]
        public int? CityId { get; set; }
        public virtual City? City { get; set; }
    }
}
