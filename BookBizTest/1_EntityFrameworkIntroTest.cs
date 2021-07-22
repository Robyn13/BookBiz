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
            var store = new Store()
            {
                Name = "Amazon",
                Books = new List<Book>()
                {
                    new Book()
                    {
                        Title = "EF Is Fun"
                    }
                }
            };
            
            _dbContext.Set<Store>().Add(store);
            _dbContext.SaveChanges();

            Assert.NotNull(store.Id);
        }

        [Test]
        public void CanQueryData()
        {
            var savedStore = _dbContext
                .Set<Store>()
                .FirstOrDefault(x => x.Name == "Ebay");

            Assert.NotNull(savedStore);
        }

        [Test]
        public void CanUpdateData()
        {
            var savedStore = _dbContext
                .Set<Store>()
                .FirstOrDefault(x => x.Name == "Ebay");


            savedStore.Name = "Not Ebay";

            _dbContext.SaveChanges();

            Assert.AreEqual("Not Ebay", savedStore.Name);
        }

        [Test]
        public void LazyLoadingCausesMultipleQueries()
        {
            _dbContext.Configuration.LazyLoadingEnabled = true;

            //Initial Query
            var savedStores = _dbContext.Set<Store>().Where(x => x.Name == "Ebay");

            //Referencing items linked to the query that weren't specifically also queried
            //This does not fail, instead it queries the database each time it needs something that hasn't been queries yet
            //This might seem simpler for development
            //This is highly discouraged in all development environments because of the number of sql queries it can cause resulting in serious performance problems
            var books = savedStores.First().Books;

            var author = books.First().Authors.First();

            var authorName = author.FirstName + " " + author.LastName;

            //use breakpoint and show profiler with the multiple queries that come through

            Assert.AreEqual(authorName, "Lil Wayne");
        }

        [Test]
        public void EagerLoadingDoesNotAllowMultipleQueries()
        {
            _dbContext.Configuration.LazyLoadingEnabled = false;

            //for optimal performance, always do the where clause before any include clauses. 

            var savedStores = _dbContext.Set<Store>()
                .Where(x => x.Name == "Ebay");

            var books = savedStores.First().Books;

            //Watch the profiler and you can see only one query with the tables joined

            Assert.Null(books);
        }

        [Test]
        public void EagerLoadingWorksWithExplicitQueries()
        {
            _dbContext.Configuration.LazyLoadingEnabled = false;

            //for optimal performance, always do the where clause before any include clauses. 

            var savedStores = _dbContext.Set<Store>()
                .Where(x => x.Name == "Ebay")
                .Include(x => x.Books);

            var books = savedStores.First().Books;

            //Watch the profiler and you can see only one query with the tables joined

            Assert.NotNull(books);
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