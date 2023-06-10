using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_maid_reviews")]
    public class MaidReview
    {
        [Key, Required]
        public long id { get; set; }
        public long maid_id { get; set; }//FK in Maid
        public long cient_id { get; set; }//FK in Client
        public int rating { get; set; }
        public string review { get; set; } = string.Empty;
        public string comments { get; set; } = string.Empty;
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }

    }
}
