using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_tokens")]
    public class Tokens
    {
        [Key, Required]
        public string token { get; set; } = string.Empty;
        public string refresh_token { get; set; } = string.Empty;
    }
}
