using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookBiz._2_CQRSIntro.Entities;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Queries
{
    public class GetStoresByState : Query<Store>
    {
        public GetStoresByState(string state)
        {
            ContextQuery = c => c.AsQueryable<Store>().Where(x => x.Address.State == state);
        }
    }
}
