

namespace Vb.Bussiness.DtoFiles;

public class ContactDTO : BaseEntityDTO
{
    public int CustomerId { get; set; }
    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
}