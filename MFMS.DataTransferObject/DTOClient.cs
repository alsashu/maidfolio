using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.DataTransferObject
{
    public class DTOClient
    {
        public long id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string contact_number { get; set; } = string.Empty;
        public string gender { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public int country_id { get; set; } //FK in Country
        public int state_id { get; set; }//FK in State 
        public string city { get; set; } = string.Empty;
        public string zip_code { get; set; } = string.Empty;
        public bool status { get; set; }
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }
}
