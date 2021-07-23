using System.Collections.Generic;
using Highway.Data;

namespace BookBiz._2_CQRSIntro.Entities
{
    public class Book : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public long Price { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}