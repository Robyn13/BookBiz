using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using BookBiz._1_EntityFrameworkIntro;
using BookBiz._1_EntityFrameworkIntro.Entities;
using NUnit.Framework;

namespace BookBizTest
{
    public class EntityFrameworkIntroTest : SetUpBaseData
    {
        private BookBizDbContext _dbContext;
        private DbContextTransaction _transaction;


        [SetUp]
        public void Setup()
        {
            _dbContext =
                new BookBizDbContext(
                    @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BookBiz;Integrated Security=SSPI");
            _transaction = _dbContext.Database.BeginTransaction(IsolationLevel.ReadCommitted);

        }

        [TearDown]
        public void Rollback()
        {
            _transaction.Rollback();
        }

        [Test]
        public void CanInsertDataWithRelationships()
        {
        }

        [Test]
        public void CanQueryData()
        {
        }

        [Test]
        public void LazyLoadingCausesMultipleQueries()
        {
        }

        [Test]
        public void EagerLoadingDoesNotAllowMultipleQueries()
        {
        }

        [Test]
        public void EagerLoadingWorksWithExplicitQueries()
        {
        }

        [Test]
        public void EntityFrameworkPopulatesAutoGeneratedIdsOnSave()
        {
        }

        [Test]
        public void EntityFrameworkManagesFkRelationshipsWithObjectRelationships()
        {
        }

    }

    [TestFixture]
    public class SetUpBaseData
    {
        private readonly BookBizDbContext _dbContext;

        public SetUpBaseData()
        {
            _dbContext =
                new BookBizDbContext(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=BookBiz;Integrated Security=SSPI");
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

            _dbContext.Set<Store>().Add(store);

            _dbContext.SaveChanges();
        }

        [TearDown]
        public void DeleteBaseData()
        {
            _dbContext.Set<Store>().RemoveRange(_dbContext.Set<Store>());
            _dbContext.Set<Book>().RemoveRange(_dbContext.Set<Book>());
            _dbContext.Set<Author>().RemoveRange(_dbContext.Set<Author>());
            _dbContext.Set<Address>().RemoveRange(_dbContext.Set<Address>());
            _dbContext.SaveChanges();
        }
    }
}