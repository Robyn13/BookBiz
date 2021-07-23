using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Queries
{
    public class FindStoreByName : Query<Store>
    {
        public FindStoreByName(string name)
        {
            ContextQuery = c => c.AsQueryable<Store>().Where(x => x.Name == name)
                .Include(x => x.Books);
        }

        public FindStoreByName WithAuthors()
        {
            var query = ContextQuery;
            ContextQuery = c => query(c)
                .Include(x => x.Books.Select(b => b.Authors));

            return this;
        }
    }
}
