using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vb.Base.Entity;
using Vb.Bussiness.DtoFiles;

namespace Vb.Bussiness.DtoFiles;

public class ContactDTO : BaseEntityDTO
{
    public int CustomerId { get; set; }
    public string ContactType { get; set; }
    public string Information { get; set; }
    public bool IsDefault { get; set; }
}