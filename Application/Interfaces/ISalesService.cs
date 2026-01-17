using Application.Common.Request;
using Application.Common.Response;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISalesService
    {
        Task<Sale> CreateSaleWithItemsAsync(CreateSalesAndSaleItemRequest request);
        Task CancelSaleAsync(CancelSaleRequest request);
        Task PayCustomerRemainingAsync(PayRemainingRequest request);
        Task<SaleDetailResponse> GetSaleDetailAsync(Guid saleId);
        Task<List<SalesListResponse>> GetAllSalesAsync();
        Task<CustomerCreditDetailResponse> GetCustomerCreditDetailAsync(Guid customerId);
        Task EditSaleAsync(EditSaleRequest request);
        Task<Guid> GetUserBranchIdAsync(string userId);

        Task<List<CustomerCreditResponse>> GetCustomerCreditsAsync(string InvoiceNo, DateTime FromDate, DateTime ToDate);

    }

}
