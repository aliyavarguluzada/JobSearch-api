namespace JobSearch.Models.v1.Address
{
    public class AddressRequest
    {
        public string Address { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
    }
}
