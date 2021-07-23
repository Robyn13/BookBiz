using System.Collections.Generic;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Entities
{
    public class Store : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}