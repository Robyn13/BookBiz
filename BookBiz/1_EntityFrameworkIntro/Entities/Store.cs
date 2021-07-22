using System.Collections.Generic;

namespace BookBiz._1_EntityFrameworkIntro.Entities
{
    public class Store 
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}