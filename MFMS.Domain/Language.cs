using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_language")]
    public class Language
    {
        [Key, Required]
        public int id { get; set; }
        public string language_name { get; set; } = string.Empty;
        public int country_id { get; set; }//FK in Country
        public bool status { get; set; }
    }
}
