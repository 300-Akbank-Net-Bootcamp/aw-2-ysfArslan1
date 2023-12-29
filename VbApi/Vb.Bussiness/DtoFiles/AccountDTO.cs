

namespace Vb.Bussiness.DtoFiles;

public class AccountDTO : BaseEntityDTO
{
    public int CustomerId { get; set; }

    public int AccountNumber { get; set; }
    public string IBAN { get; set; }
    public decimal Balance { get; set; }
    public string CurrencyType { get; set; }
    public string Name { get; set; }
    public DateTime OpenDate { get; set; }

    public virtual ICollection<AccountTransactionDTO>? AccountTransactions { get; set; }
    public virtual ICollection<EftTransactionDTO>? EftTransactions { get; set; }
} 
