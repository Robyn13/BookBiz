using Highway.Data;

namespace BookBiz._2_CQRSIntro.Entities
{
    public class Address : IIdentifiable<long>
    {
        public long Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
    }
}
