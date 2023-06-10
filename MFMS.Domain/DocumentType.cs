using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_document_type")]
    public class DocumentType
    {
        [Key, Required]
        public int id { get; set; }
        public string document_name { get; set; } = string.Empty;
        public bool status { get; set; }
    }
}
