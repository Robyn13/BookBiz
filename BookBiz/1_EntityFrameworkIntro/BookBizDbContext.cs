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

            modelBuilder.Configurations.Add(new StoreEntityConfig());
            modelBuilder.Configurations.Add(new AddressEntityConfig());
            modelBuilder.Configurations.Add(new AuthorEntityConfig());
            modelBuilder.Configurations.Add(new BookEntityConfig());
        }
    }

    public class AuthorEntityConfig : EntityTypeConfiguration<Author>
    {
    }

    public class AddressEntityConfig : EntityTypeConfiguration<Address>
    {
    }

    public class BookEntityConfig : EntityTypeConfiguration<Book>
    {
    }

    public class StoreEntityConfig : EntityTypeConfiguration<Store>
    {
        public StoreEntityConfig()
        {
        }
    }
}
