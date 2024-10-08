using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using StoneTrackAdmin.Models;

namespace StoneTrackAdmin.Services
{
    public class CustomerService: ICustomers
    {
        private readonly IDapper _dapper;
        public CustomerService(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<List<CustomerDetailsModel>> CustomerDetails()
        {
            try
            {
                string query = string.Empty;
                query = "SELECT CustomerId, Name,GSTNO, Address, MobileNo, EmailAddress, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    " IsDeleted FROM Customer where  IsActive=1 and IsDeleted=0 Order By CustomerId desc";
                var data = await _dapper.GetAllAsync<CustomerDetailsModel>(query);
                return data.ToList();
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<CustomerDetailsModel> GetCustomerDetailsById(int CustomerId)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                query = "SELECT CustomerId, Name,GSTNO, Address, MobileNo, EmailAddress, CreatedBy, UpdatedBy, CreatedDate, UpdatedDate, IsActive, " +
                    "IsDeleted FROM Customer where CustomerId = @CustomerId ";
                var data = await _dapper.GetFirstOrDefaultAsync<CustomerDetailsModel>(query,parameters);
                return data;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task DeleteCustomerDetails(int CustomerId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", CustomerId);
                string query = string.Empty;
                query = "update Customer set IsActive=0 ,IsDeleted=1 where CustomerId=@CustomerId";
                //await _dapper.GetFirstOrDefaultAsync<ViewCustomerDetailsModel>(query, parameters);
                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task UpdateCustomer(CustomerDetailsModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId",data.CustomerId);
                parameters.Add("@Name", data.Name);
                parameters.Add("@Address", data.Address);
                parameters.Add("@GSTNO", data.GSTNO);
                parameters.Add("@EmailAddress", data.EmailAddress);
                parameters.Add("@MobileNo", data.MobileNo);
                string query = string.Empty;
                query = $"Update Customer set Name=@Name,Address=@Address,EmailAddress=@EmailAddress,GSTNO=@GSTNO,MobileNo=@MobileNo,UpdatedBy=@CustomerId," +
                    $"UpdatedDate=GETDATE() where CustomerId=@CustomerId";
                 
                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task InsertCustomer(CustomerDetailsModel data)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@CustomerId", data.CustomerId);
                parameters.Add("@Name", data.Name);
                parameters.Add("@Address", data.Address);
                parameters.Add("@GSTNO", data.GSTNO);
                parameters.Add("@EmailAddress", data.EmailAddress);
                parameters.Add("@MobileNo", data.MobileNo);
                string query = string.Empty;
                query = $"INSERT INTO Customer (Name, Address, MobileNo, EmailAddress,GSTNO, CreatedBy,CreatedDate,IsActive, IsDeleted) VALUES (@Name," +
                    $" @Address,@MobileNo, @EmailAddress,@GSTNO, 0,GETDATE(),1, 0);";

                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderDetailsModel>> OrderDetails()
        {
            try
            {
                string query = string.Empty;
                query = "select OrderId,VehicleNo,DriverName,DriverMobileNo,MaterialType,GSTNO,Weight,Amount,PaymentStatus,PaymentMode,EntrySlipImageUrl," +
                    "PaymentSlipUrl,CustomerName,CustomerAddress,ActualWeight,NetAmount,InvoiceNo,InvoiceImageUrl,OrderStatus,OrderDate, CreatedBy" +
                    " from Orders where IsActive=1 and IsDeleted=0 order by OrderId desc";
                var data = await _dapper.GetAllAsync<OrderDetailsModel>(query);
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderDetailsModel>> DashboardOrderDetails(string Status)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@Status", Status);
                query = "select OrderId,VehicleNo,DriverName,DriverMobileNo,MaterialType,GSTNO,Weight,Amount,PaymentStatus,PaymentMode,EntrySlipImageUrl," +
                    " PaymentSlipUrl,CustomerName,CustomerAddress,ActualWeight,NetAmount,InvoiceNo,InvoiceImageUrl,OrderStatus,OrderDate, CreatedBy " +
                    " from Orders where IsActive=1 and IsDeleted=0 and OrderStatus=@Status AND CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE) order by " +
                    " OrderId desc";
                var data = await _dapper.GetAllAsync<OrderDetailsModel>(query,parameters);
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<OrderDetailsModel>> StatusOrderDetails(string Status)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@Status", Status);
                query = "select OrderId,VehicleNo,DriverName,DriverMobileNo,MaterialType,GSTNO,Weight,Amount,PaymentStatus,PaymentMode,EntrySlipImageUrl," +
                    " PaymentSlipUrl,CustomerName,CustomerAddress,ActualWeight,NetAmount,InvoiceNo,InvoiceImageUrl,OrderStatus,OrderDate, CreatedBy " +
                    " from Orders where IsActive=1 and IsDeleted=0 and OrderStatus=@Status Order by OrderId desc";
                var data = await _dapper.GetAllAsync<OrderDetailsModel>(query, parameters);
                return data.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OrderDetailsModel> OrderDetailsByOrderId(int OrderId)
        {
            try
            {
                string query = string.Empty;
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", OrderId);
                query = "select OrderId,VehicleNo,DriverName,DriverMobileNo,MaterialType,Weight,Amount,PaymentStatus,PaymentMode,EntrySlipImageUrl," +
                    "PaymentSlipUrl,CustomerName,CustomerAddress,ActualWeight,NetAmount,InvoiceNo,InvoiceImageUrl,OrderStatus,OrderDate, CreatedBy" +
                    " from Orders where IsActive=1 and IsDeleted=0 and OrderId=@OrderId";
                return await _dapper.GetFirstOrDefaultAsync<OrderDetailsModel>(query,parameters);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task DeleteOrdersDetails(int OrderId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", OrderId);
                string query = string.Empty;
                query = "update Orders set IsActive=0, IsDeleted=1 where OrderId=@OrderId";
                await _dapper.InsertDelete(query, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<OrderDetailsCountModel> CountOrder()
        {
            try
            {
                string query = string.Empty;
                query = " select " +
                    "(select COUNT(OrderId) from Orders where OrderStatus='New' and IsActive=1 and IsDeleted=0 and CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) as CountNewOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Vehicle In' and IsActive=1 and IsDeleted=0 and CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) as CountVehicleInOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Loaded' and IsActive=1 and IsDeleted=0 and CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) as CountLoadedOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Dispatched' and IsActive=1 and IsDeleted=0 and CAST(OrderDate AS DATE) = CAST(GETDATE() AS DATE)) as CountDispatchedOrder ";
                var data = await _dapper.GetFirstOrDefaultAsync<OrderDetailsCountModel>(query);
                return data;
            }
            catch (Exception ex) { throw ex; }
        }
        public async Task<OrderDetailsCountModel> CountTotaOrder()
        {
            try
            {
                string query = string.Empty;
                query = " select " +
                    "(select COUNT(OrderId) from Orders where OrderStatus='New' and IsActive=1 and IsDeleted=0 ) as CountNewOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Vehicle In' and IsActive=1 and IsDeleted=0 ) as CountVehicleInOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Loaded' and IsActive=1 and IsDeleted=0 ) as CountLoadedOrder," +
                    "(select COUNT(OrderId) from Orders where OrderStatus='Dispatched' and IsActive=1 and IsDeleted=0 ) as CountDispatchedOrder ";
                var data = await _dapper.GetFirstOrDefaultAsync<OrderDetailsCountModel>(query);
                return data;
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<InvoiceModel> GenerateInvoiceData(int OrderId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", OrderId);
                return await _dapper.ExecuteProcedureFirstOrDefault<InvoiceModel>("InviceDetail", parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DownloadEntrySlipModel> DownloadEntrySlip(int OrderId)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@OrderId", OrderId);
                string query = string.Empty;
                query = "Select OrderId,VehicleNo,DriverName,DriverMobileNo,MaterialType,Amount,PaymentStatus,CustomerName,CustomerAddress,ActualWeight,NetAmount,OrderDate " +
                    "from Orders where OrderId=@OrderId";
                var data = await _dapper.GetFirstOrDefaultAsync<DownloadEntrySlipModel>(query, parameters);
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public async Task UpdateOrderStatus(UpdateOrderStatusModel data)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@OrderId", data.OrderId);
        //        parameters.Add("@OrderStatus", data.OrderStatus);
        //        string query = string.Empty;
        //        query = $"update ServiceOrder set OrderStatus=@OrderStatus,UpdateOrderStatusDateTime=GetDate() " +
        //            $"where OrderId=@OrderId";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task UpdatePaymentStatus(UpdateOrderStatusModel data,decimal TotalAmount)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();

        //        parameters.Add("@OrderId", data.OrderId);
        //        parameters.Add("@PaymentStatus", data.PaymentStatus);
        //        parameters.Add("@TotalAmount", TotalAmount);

        //        string query = string.Empty;
        //        query = $"update ServiceOrder set Status=@PaymentStatus,TransactionDate=GETDATE(),Amount=@TotalAmount where OrderId=@OrderId ";

        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public async Task UploadDoucment(UpdateOrderStatusModel data)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();

        //        parameters.Add("@OrderId", data.OrderId);
        //        parameters.Add("@UpdateDoucmentUrl", data.UpdateDoucmentUrl);

        //        string query = string.Empty;
        //        query = $"update ServiceOrder set DoucmentOrder=@UpdateDoucmentUrl where OrderId=@OrderId";

        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task<List<CustomerDetailsModel>> SearchCustomerDetails(string SearchText)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@SearchText", SearchText);

        //        string query = string.Empty;
        //        query = "Select CustomerId,CONCAT(FirstName,' ',LastName)as Name,EmailAddress,PhoneNumber,District, CreatedDate as" +
        //            " JoiningDate from CustomerRegistration where  FirstName like '%'+@SearchText+'%' or EmailAddress like " +
        //            "'%'+@SearchText+'%' or  PhoneNumber like '%'+@SearchText+'%' or District like '%'+@SearchText+'%' or" +
        //            " CreatedDate like '%'+@SearchText+'%' and  IsActive=1 and IsDelete=0 order by CustomerId desc";
        //        var data = await _dapper.GetAllAsync<CustomerDetailsModel>(query);
        //        return data.ToList();
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        //public async Task<DashboardModal> DashboardData()
        //{
        //    try
        //    {
        //        string query = string.Empty;
        //        query = " select(Select Count(CustomerId)  from CustomerRegistration where IsActive=1 and IsDelete=0 and OTPVerification=1)as TotalCustomer," +
        //            "(select Count(OrderId)  from ServiceOrder where OrderStatus='Completed' and Status='Success')as OrderComplete, " +
        //            "(select Count(OrderId)  from ServiceOrder where Status='Success')as TotalOrder, " +
        //            "(Select Sum(CAST(amount AS DECIMAL(10, 2))) from ServiceOrder Where Status='Success')as TotalSaleAmount, " +
        //            "(select Count(OrderId)  from ServiceOrder where Status='Success' and OrderStatus='Pending')as PendingOrder";
        //        return await _dapper.GetFirstOrDefaultAsync<DashboardModal>(query);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task<IEnumerable<MonthBasisSale>> AdminDashboardMonthlyBasisSale()
        //{
        //    try
        //    {
        //        return await _dapper.ExecuteProcedure<MonthBasisSale>("AdminDashboardMonthWiseSale", new DynamicParameters());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //  public async Task<IEnumerable<TotalNoOfCustomerMonthBasis>> TotalNoOfCustomerMonthBasis()
        //{
        //    try
        //    {
        //        return await _dapper.ExecuteProcedure<TotalNoOfCustomerMonthBasis>("TotalNoOfCustomerMonthBasis", new DynamicParameters());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<IEnumerable<TopSellingServices>> TopSellingServicesCount()
        //{
        //    try
        //    {
        //        return await _dapper.ExecuteProcedure<TopSellingServices>("TopSaleServices", new DynamicParameters());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        //public async Task<IEnumerable<MonthBasisSale>> CustomerMonthlyBasisSale(int CustomerId)
        //{
        //    try
        //    {
        //        var Parameters = new DynamicParameters();
        //        Parameters.Add("@CustomerId", CustomerId);
        //        return await _dapper.ExecuteProcedure<MonthBasisSale>("CustomerMonthWiseSale", Parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<List<OrderDetailsModel>> CompliteOrderDetails()
        //{

        //    try
        //    {
        //        string query = string.Empty;
        //        query = "SELECT CR.CustomerId,SO.OrderId,CONCAT(CR.FirstName,' ',CR.LastName) as Name,CR.EmailAddress as Email,CR.PhoneNumber as Phone," +
        //            " SO.TransactionDate as Date,SO.Status,SO.FormType,SO.OrderStatus,SO.DoucmentOrder,SO.UpdateOrderStatusDateTime,ST.ServiceName as Service,CA.District,CR.Nationality FROM CustomerRegistration CR INNER JOIN ServiceOrder SO ON " +
        //            " CR.CustomerId = SO.CustomerId and SO.IsActive=1 and SO.IsDelete=0 INNER JOIN ServiceType ST ON SO.ServiceId = ST.ServiceId left JOIN CustomerAddress CA ON CA.AddressId = SO.AddressId " +
        //            " where SO.Status='Success' and SO.OrderStatus='Completed' order by OrderId desc;";
        //        var data = await _dapper.GetAllAsync<OrderDetailsModel>(query);
        //        return data.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<List<OrderDetailsModel>> PendingOrderDetails()
        //{
        //    try
        //    {
        //        string query = string.Empty;
        //        query = "SELECT CR.CustomerId,SO.OrderId,CONCAT(CR.FirstName,' ',CR.LastName) as Name,CR.EmailAddress as Email,CR.PhoneNumber as Phone,SO.OrderDate," +
        //            " SO.TransactionDate as Date,SO.Status,SO.FormType,SO.OrderStatus,SO.DoucmentOrder,SO.UpdateOrderStatusDateTime,ST.ServiceName as Service,CA.District,CR.Nationality FROM CustomerRegistration CR INNER JOIN ServiceOrder SO ON " +
        //            " CR.CustomerId = SO.CustomerId and SO.IsActive=1 and SO.IsDelete=0 INNER JOIN ServiceType ST ON SO.ServiceId = ST.ServiceId left JOIN CustomerAddress CA ON CA.AddressId = SO.AddressId " +
        //            " where SO.Status='Success' and SO.OrderStatus='Pending' order by OrderId desc;";
        //        var data = await _dapper.GetAllAsync<OrderDetailsModel>(query);
        //        return data.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<List<PendingServices>> PendingServicesName()
        //{
        //    try
        //    {
        //        string query = string.Empty;
        //        query = "  select Count(SO.ServiceId) as TotalService,dbo.Split_On_Upper_Case(ST.SERVICENAME) as AllServiceName  from ServiceOrder as SO Inner Join ServiceType as ST" +
        //            " on SO.ServiceId=ST.ServiceId where Status='Success' and OrderStatus='Pending' group by ST.ServiceName ";
        //        var data = await _dapper.GetAllAsync<PendingServices>(query);
        //       return data.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<List<ActivityLogModel>> ActivityLogData()
        //{
        //    try
        //    {
        //        string query = string.Empty;
        //        query = "Select ActivityLogId,Activity,AL.CustomerId,CreateDate,CONCAT(CR.FirstName,'',CR.LastName) as Name,PhoneNumber from ActivityLog as AL " +
        //            "Inner Join CustomerRegistration as CR on CR.CustomerId=AL.CustomerId order by (ActivityLogId) desc";
        //        var data = await _dapper.GetAllAsync<ActivityLogModel>(query);
        //        return data.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task AddInviceCount(int OrderId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@OrderId", OrderId);
        //        string query = string.Empty;
        //        query = $" insert into InviceCount (OrderId,InviceDate) values(@OrderId,GETDATE())";
        //        await _dapper.InsertDelete(query, parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<CartDataModel> GetEmailData(int OrderId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@OrderId", OrderId);
        //        string query = string.Empty;
        //        return await _dapper.ExecuteProcedureFirstOrDefault<CartDataModel>("GetInviceData", parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //public async Task<InviceDataModel> GetInviceData(int OrderId)
        //{
        //    try
        //    {
        //        var parameters = new DynamicParameters();
        //        parameters.Add("@OrderID", OrderId);
        //        string query = string.Empty;
        //        return await _dapper.ExecuteProcedureFirstOrDefault<InviceDataModel>("GetInviceData", parameters);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

    }
}
