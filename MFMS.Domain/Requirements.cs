using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_requirement")]
    public class Requirement
    {
        [Key, Required]
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string contact_number { get; set; } = string.Empty;
        public string requirements { get; set; } = string.Empty;
        public string comments_by_admin { get; set; } = string.Empty;
        public string status { get; set; } = string.Empty;
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }
}
