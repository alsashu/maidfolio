using MFMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    internal interface IEF_DbContext
    {
        DbSet<Client> Clients { get; set; }
        DbSet<ClientProfileViewedHistory> ClientProfileViewedHistorys { get; set; }
        DbSet<ClientSubscriptionDetail> ClientSubscriptionDetails { get; set; }
        DbSet<Country> Countrys { get; set; }
        DbSet<Currency> Currencys { get; set; }
        DbSet<DocumentType> DocumentTypes { get; set; }
        DbSet<Language> Languages { get; set; }
        DbSet<Maid> Maids { get; set; }
        DbSet<MaidReview> MaidReviews { get; set; }
        DbSet<Movie> Movies { get; set; }
        DbSet<Requirement> Requirements { get; set; }
        DbSet<Role> Role { get; set; }
        DbSet<RoleMaster> RoleMaster { get; set; }
        DbSet<SalaryRange> SalaryRanges { get; set; }
        DbSet<State> States { get; set; }
        DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        DbSet<WorkingHour> WorkingHour { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Tokens> Tokens { get; set; }
    }
}
