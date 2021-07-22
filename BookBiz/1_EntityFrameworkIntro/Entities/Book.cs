using System.Collections.Generic;

namespace BookBiz._1_EntityFrameworkIntro.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public long Price { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}