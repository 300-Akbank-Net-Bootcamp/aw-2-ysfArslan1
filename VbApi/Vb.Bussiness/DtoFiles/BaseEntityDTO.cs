namespace Vb.Bussiness.DtoFiles;

public abstract class BaseEntityDTO
{
    public int? InsertUserId { get; set; }
    public DateTime? InsertDate { get; set; }
    public int? UpdateUserId { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool? IsActive { get; set; }
}