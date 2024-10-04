using System.Collections.Generic;
using System.Threading.Tasks;
using StoneTrackAdmin.Models;

namespace StoneTrackAdmin.Services
{
    public interface ICustomers
    {

        Task<List<CustomerDetailsModel>> CustomerDetails();
        Task<CustomerDetailsModel> GetCustomerDetailsById(int CustomerId);
        Task DeleteCustomerDetails(int CustomerId);
        Task UpdateCustomer(CustomerDetailsModel data);
        Task InsertCustomer(CustomerDetailsModel data);
        Task<List<OrderDetailsModel>> OrderDetails();
        Task<OrderDetailsModel> OrderDetailsByOrderId(int OrderId);
        Task<List<OrderDetailsModel>> DashboardOrderDetails(string Status);
        Task<OrderDetailsCountModel> CountOrder();
        Task DeleteOrdersDetails(int OrderId);
        Task<InvoiceModel> GenerateInvoiceData(int OrderId);
        Task<OrderDetailsCountModel> CountTotaOrder();
        Task<List<OrderDetailsModel>> StatusOrderDetails(string Status);
        Task<DownloadEntrySlipModel> DownloadEntrySlip(int OrderId);

        //Task<List<CustomerDetailsModel>> CustomerDetails();
        //Task<ViewCustomerDetailsModel> ViewCustomerDetails(int CustomerId);
        //Task<ViewCustomerDetailsModel> EditCustomerDetails(int CustomerId);
        //Task DeleteCustomerDetails(int CustomerId);
        //Task DeleteOrderDetails(int OrderId);
        //Task UpdateCustomer(ViewCustomerDetailsModel data);
        //Task UpdateOrderStatus(UpdateOrderStatusModel data);
        //Task UploadDoucment(UpdateOrderStatusModel data);
        //Task<StateCityValue> GetStateByCustomerId(int CustomerId);
        //Task<List<CustomerDetailsModel>> SearchCustomerDetails(string SearchText);
        //Task<DashboardModal> DashboardData();
        //Task<IEnumerable<MonthBasisSale>> AdminDashboardMonthlyBasisSale();
        //Task<IEnumerable<TotalNoOfCustomerMonthBasis>> TotalNoOfCustomerMonthBasis();
        //Task<IEnumerable<TopSellingServices>> TopSellingServicesCount();
        //Task<IEnumerable<MonthBasisSale>> CustomerMonthlyBasisSale(int CustomerId);
        //Task<List<OrderDetailsModel>> CompliteOrderDetails();
        //Task<List<OrderDetailsModel>> PendingOrderDetails();
        //Task<List<PendingServices>> PendingServicesName();
        //Task<List<ActivityLogModel>> ActivityLogData();
        //Task UpdatePaymentStatus(UpdateOrderStatusModel data,decimal TotalAmount);
        //Task AddInviceCount(int OrderId);
        //Task<CartDataModel> GetEmailData(int OrderId);
        //Task<InviceDataModel> GetInviceData(int OrderId);
    }
}
