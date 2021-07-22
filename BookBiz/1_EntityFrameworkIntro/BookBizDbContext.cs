using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BookBiz._1_EntityFrameworkIntro.Entities;

namespace BookBiz._1_EntityFrameworkIntro
{
    public class BookBizDbContext : DbContext
    {

        public BookBizDbContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
