using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Queries
{
    public class FindAuthorByName : Query<Author>
    {
        public FindAuthorByName(string firstName, string lastName)
        {
            ContextQuery = c => c.AsQueryable<Author>()
                .Where(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
