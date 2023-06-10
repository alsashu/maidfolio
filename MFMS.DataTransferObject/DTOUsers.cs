using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.DataTransferObject
{
    public class DTOUsers
    {
        public long id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string old_password { get; set; } = string.Empty;
        public string country_code { get; set; } = string.Empty;
        public string contact_person { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public string mobile { get; set; } = string.Empty;
        public string access { get; set; } = string.Empty;
        public string api_key { get; set; } = string.Empty;
        public string verification_code { get; set; } = string.Empty;
        public byte[] user_image { get; set; } = new Byte[64];
        public string created_on { get; set; } = string.Empty;
        public string updated_date { get; set; } = string.Empty;
        public int role_id { get; set; }
        public int created_by_user_id { get; set; }
        public int modified_by_user_id { get; set; }
        public bool is_deleted { get; set; }
        public bool active { get; set; }
        public bool terms_and_conditions { get; set; }
    }
}
