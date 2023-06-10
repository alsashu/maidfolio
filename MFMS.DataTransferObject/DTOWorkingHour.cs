using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_working_hours")]
    public class DTOWorkingHour
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = String.Empty;
        public bool status { get; set; }
    }
}
