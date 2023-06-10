using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_client_subscription_details")]
    public class ClientSubscriptionDetail
    {
        [Key, Required]
        public long id { get; set; }
        public long client_id { get; set; }//FK in Client
        public int subscription_id { get; set; }
        public int pending_points { get; set; }
        public DateTime subscribed_date { get; set; }
        public DateTime validity_end_date { get; set; }
        public string created_by { get; set; } = string.Empty;
        public string created_date { get; set; } = string.Empty;
        public string modified_by { get; set; } = string.Empty;
        public string modified_date { get; set; } = string.Empty;
    }
}
