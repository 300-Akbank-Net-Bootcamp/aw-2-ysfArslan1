

namespace Vb.Bussiness.DtoFiles;

public class EftTransactionDTO : BaseEntityDTO
{
    public int AccountId { get; set; }
    
    public string? ReferenceNumber { get; set; }
    public DateTime TransactionDate { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    
    public string? SenderAccount { get; set; }
    public string? SenderIban { get; set; }
    public string? SenderName { get; set; }
}