using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_role")]
    public class DTORole
    {
        [Key, Required]
        public int id { get; set; }
        public string role_for { get; set; } = string.Empty;
        public string role_name { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public Nullable<bool> active { get; set; }
    }
}
