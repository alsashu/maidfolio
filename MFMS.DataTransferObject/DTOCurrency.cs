using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_currency")]
    public class DTOCurrency
    {
        [Key, Required]
        public int id { get; set; }
        public string currency_name { get; set; } = string.Empty;
        public string symbol { get; set; } = string.Empty;
        public int country_id { get; set; } // FK in Country
        public bool status { get; set; }
    }
}
