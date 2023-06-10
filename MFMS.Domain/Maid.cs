using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Domain
{
    [Table("mfms_maid")]
    public class Maid
    {
        [Key, Required]
        public long id { get; set; }
        public string first_name { get; set; } = string.Empty;
        public string last_name { get; set; } = string.Empty;
        public string contact_number { get; set; } = string.Empty;
        public int age { get; set; }
        public string gender { get; set; } = string.Empty;
        public string address { get; set; } = string.Empty;
        public int country_id { get; set; } //FK in Country
        public int state_id { get; set; }//FK in State 
        public string city { get; set; } = string.Empty;
        public string zip_code { get; set; } = string.Empty;
        public bool status { get; set; }
        public int working_hours_id { get; set; }// FK in WorkingHours
        public int job_skills_id { get; set; }//FK in JobSkills
        public bool availibility { get; set; }
        public string expected_date_of_availibility { get; set; } = string.Empty;
        public string languages_known { get; set; } = string.Empty;// comma sperated id from Language table . Example 1,2,4
        public int salary_range_id { get; set; } //FK in SalaryRange
        public byte[] photo { get; set; } = new Byte[64];
        public int document_type_id { get; set; } //FK in DocumentType
        public byte[] document_photo { get; set; } = new Byte[64];
        public string reference { get; set; } = string.Empty;
        public string about_maid { get; set; } = string.Empty;
        public string comments_by_admin { get; set; } = string.Empty;
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool is_verified { get; set; }
        public bool is_block_listed { get; set; }
        public string created_by { get; set; } = string.Empty;
        public string created_date { get; set; } = string.Empty;
        public string modified_by { get; set; } = string.Empty;
        public string modified_date { get; set; } = string.Empty;
    }
}
