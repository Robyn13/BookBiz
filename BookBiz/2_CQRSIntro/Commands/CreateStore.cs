using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Commands
{
    public class CreateStore : Command
    {
        public CreateStore(Store store)
        {
            ContextQuery = c =>
            {
                c.Add(store);
                c.Commit();
            };
            
        }
    }
}
