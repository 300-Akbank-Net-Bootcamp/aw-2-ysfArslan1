

namespace Vb.Bussiness.DtoFiles
{
    public class AddressDTO: BaseEntityDTO
    {
        public int CustomerId { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? County { get; set; }
        public string? PostalCode { get; set; }
        public bool IsDefault { get; set; }
    }
}
