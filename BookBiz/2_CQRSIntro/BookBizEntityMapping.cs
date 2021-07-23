using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro
{
    public class BookBizEntityMapping : IMappingConfiguration
    {
        public void ConfigureModelBuilder(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressEntityConfig());
            modelBuilder.Configurations.Add(new AuthorEntityConfig());
            modelBuilder.Configurations.Add(new BookEntityConfig());
            modelBuilder.Configurations.Add(new StoreEntityConfig());
        }
    }

    public class AddressEntityConfig : EntityTypeConfiguration<Address>
    {
        public AddressEntityConfig()
        {
        }
    }

    public class AuthorEntityConfig : EntityTypeConfiguration<Author>
    {

    }

    public class BookEntityConfig : EntityTypeConfiguration<Book>
    {

    }

    public class StoreEntityConfig : EntityTypeConfiguration<Store>
    {

    }
}