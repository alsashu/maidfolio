using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_client_profile_viewed_history")]
    public class ClientProfileViewedHistory
    {
        [Key, Required]
        public long id { get; set; }
        public long client_id { get; set; }//FK in Client
        public long maid_id { get; set; }//FK in Maid
        public DateTime viewed_date { get; set; }

    }
}
