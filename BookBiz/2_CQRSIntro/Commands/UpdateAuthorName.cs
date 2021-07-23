using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Commands
{
    public class UpdateAuthorName : Command
    {
        public UpdateAuthorName(long id, string firstName, string lastName)
        {
            ContextQuery = c =>
            {
                var authorToUpdate = c.AsQueryable<Author>().Single(a => a.Id == id);
                authorToUpdate.FirstName = firstName;
                authorToUpdate.LastName = lastName;
                c.Commit();
            };
        }
    }
}
