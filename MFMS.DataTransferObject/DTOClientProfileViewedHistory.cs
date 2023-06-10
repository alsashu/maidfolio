using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.DataTransferObject
{
    public class DTOClientProfileViewedHistory
    {
        public long id { get; set; }
        public long client_id { get; set; }//FK in Client
        public long maid_id { get; set; }//FK in Maid
        public DateTime viewed_date { get; set; }
    }
}
