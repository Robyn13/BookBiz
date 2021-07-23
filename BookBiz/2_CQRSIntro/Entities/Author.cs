using Highway.Data;

namespace BookBiz._2_CQRSIntro.Entities
{
    public class Author : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}