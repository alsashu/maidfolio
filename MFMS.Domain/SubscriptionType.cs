using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MFMS.Domain
{
    [Table("mfms_subscription_type")]
    public class SubscriptionType
    {
        [Key, Required]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public long amount { get; set; }
        public int country_id { get; set; } //FK in Country
        public int currency_id { get; set; } //FK in Currency
        public int validity_duration { get; set; }
        public string validity_type { get; set; } = string.Empty;// FK in Enum ValidityType
        public int points { get; set; }
        public string benefits { get; set; } = string.Empty;
        public string how_it_works { get; set; } = string.Empty;
        public string terms_and_conditions { get; set; } = string.Empty;
        public string desciption { get; set; } = string.Empty;
        public bool status { get; set; }
        public string created_by { get; set; } = string.Empty;
        public DateTime created_date { get; set; }
        public string modified_by { get; set; } = string.Empty;
        public DateTime modified_date { get; set; }
    }

    public enum ValidityType
    {
        Day,
        Week,
        Month,
        Year
    }
}
