public class CustomerCreditDetailResponse
{
    public Guid CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public string CustomerPhone { get; set; } = string.Empty;
    public string CreateBy { get; set; } = string.Empty;

    public decimal TotalCredit { get; set; }

    public List<CustomerCreditSaleDetail> Sales { get; set; } = new();
}

public class CustomerCreditSaleDetail
{
    public Guid SaleId { get; set; }
    public string InvoiceNumber { get; set; } = string.Empty;

    public DateTime SaleDate { get; set; }

    public decimal TotalAmount { get; set; }
    public decimal PaidAmount { get; set; }
    public decimal Balance { get; set; }

    public string PaymentStatus { get; set; } = string.Empty;
}
