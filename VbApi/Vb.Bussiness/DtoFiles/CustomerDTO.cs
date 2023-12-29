

namespace Vb.Bussiness.DtoFiles
{
    public class CustomerDTO: BaseEntityDTO
    {
        public string IdentityNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int CustomerNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime LastActivityDate { get; set; }

        public ICollection<AddressDTO> Addresses { get; set; }
        public ICollection<ContactDTO> Contacts { get; set; }
        public ICollection<AccountDTO> Accounts { get; set; }
    }
}
