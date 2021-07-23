using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro;
using BookBiz._2_CQRSIntro.Commands;
using BookBiz._2_CQRSIntro.Entities;
using BookBiz._2_CQRSIntro.Queries;
using Highway.Data;
using Highway.Data.Repositories;
using NUnit.Framework;

namespace BookBizTest
{
    class _2_CQRSIntroTest : SetUpBaseCqrsData
    {
        private DbContextTransaction _transaction;

        [SetUp]
        public void SetUpRepository()
        {
            _transaction = Context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        [TearDown]
        public void RollbackChanges()
        {
            _transaction.Rollback();
        }

        [Test]
        public void CanQueryData()
        {
        }

        [Test]
        public void CanQueryDataWithExtension()
        {
        }

        [Test]
        public void CanUpdateData()
        {
        }

        [Test]
        public void CanInsertData()
        {
        }

        [Test]
        public void CanQueryEntitiesWithIIdentifiable()
        {
        }
    }
    [TestFixture]
    public class SetUpBaseCqrsData
    {
        public DomainRepository<BookBizDomain> Repository { get; }
        public DomainContext<BookBizDomain> Context { get; }

        public SetUpBaseCqrsData()
        {
            var domain = new BookBizDomain(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BookBizCQRS;Integrated Security=SSPI");
            Context = new DomainContext<BookBizDomain>(domain);
            Repository = new DomainRepository<BookBizDomain>(Context, domain);
        }

        [SetUp]
        public void InsetStoreData()
        {
            var store = new Store
            {
                Name = "Ebay",
                Address = new Address
                {
                    AddressLine1 = "1234 YourStreet",
                    City = "Houston",
                    State = "Texas",
                    Country = "USA",
                    Zip = "77042"
                },
                Books = new List<Book>
                {
                    new Book
                    {
                        Title = "A Developer's Life",
                        Genre = "Action",
                        Authors = new List<Author>
                        {
                            new Author
                            {
                                FirstName = "Lil",
                                LastName = "Wayne"
                            }
                        }
                    }
                }
            };

            Context.Set<Store>().Add(store);

            Context.SaveChanges();
        }

        [TearDown]
        public void DeleteBaseData()
        {
            Context.Set<Store>().RemoveRange(Context.Set<Store>());
            Context.Set<Book>().RemoveRange(Context.Set<Book>());
            Context.Set<Author>().RemoveRange(Context.Set<Author>());
            Context.Set<Address>().RemoveRange(Context.Set<Address>());
            Context.SaveChanges();
        }
    }
}
