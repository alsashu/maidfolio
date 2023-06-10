using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_movie")]
    public class Movie
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public decimal cost { get; set; }
    }
}
