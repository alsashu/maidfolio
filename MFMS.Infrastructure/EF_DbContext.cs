using MFMS.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFMS.Infrastructure
{
    public class EF_DbContext: DbContext, IEF_DbContext
    {
        public EF_DbContext(DbContextOptions<EF_DbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientProfileViewedHistory> ClientProfileViewedHistorys { get; set; }
        public DbSet<ClientSubscriptionDetail> ClientSubscriptionDetails { get; set; }
        public DbSet<Country> Countrys { get; set; }
        public DbSet<Currency> Currencys { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Maid> Maids { get; set; }
        public DbSet<MaidReview> MaidReviews { get; set; }
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<SalaryRange> SalaryRanges { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<WorkingHour> WorkingHour { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<RoleMaster> RoleMaster { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Tokens> Tokens { get; set; }
    }
}
