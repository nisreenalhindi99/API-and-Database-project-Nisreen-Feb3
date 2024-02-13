  using API_and_Database_project_Nisreen_Feb3.DTO;
using API_and_Database_project_Nisreen_Feb3.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using static API_and_Database_project_Nisreen_Feb3.Helper.Helper;

namespace API_and_Database_project_Nisreen_Feb3.Controllers
{
    [Route("Nisreen")] //api/Test
    [ApiController] // Attributes
    public class ProjectController : Controller
    {
      

        #region getTablesUaingView

            [HttpGet]
            [Route("[action]")]
                public IActionResult ViewToGetAllAdmin()
            {
                string query = "SELECT * FROM ViewToGetAllAdmin ";
                DataTable table = ExecutenQueryCommandHelper(query, null);
                return Ok(table);
            }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewToGetAllCombo_meal()
        {
            string query = "SELECT * FROM ViewToGetAllCombo_meal ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewToGetAllCustomer()
        {
            string query = "SELECT * FROM viewcustomers ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewToGetAllEmployee()
        {
            string query = "SELECT * FROM ViewToGetAllEmployee ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewToGetAllItems()
        {
            string query = "SELECT * FROM ViewToGetAllItems ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewToGetAllOrders()
        {
            string query = "SELECT * FROM ViewToGetAllOrders ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }
        #endregion
        #region CustomizedView
        [HttpGet]
        [Route("[action]")]
        public IActionResult ViewTop10Orders()
        {
            string query = "SELECT * FROM Order_top10 ";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Viewlast_orders()
        {
            string query = "select * from last_orders";
            DataTable table = ExecutenQueryCommandHelper(query, null);
            return Ok(table);
        }
        // view inside procedure to get the sales bases on date
        [HttpGet]
        [Route("FilteredDataViewTest")]
        public IActionResult CreateFilteredDataViewTest(DateTime startDate, DateTime endDate)
        {
            string query = "FilteredDataViewTest";

            Dictionary<string, object> parms = new Dictionary<string, object>
    {  { "@startDate", startDate},
    { "@endDate", endDate }
    };
            DataTable table = QuerycommandHanleproc(query, parms);
            return Ok(table);
          
        }
        #endregion
        #region Create

        [HttpPost]
        [Route("CreateAdmin")]
        public IActionResult CreateAdmin(CreateAdmin dto)
        {
            string query = "Insert_Admin";

            Dictionary<string, object> parms = new Dictionary<string, object>
                         {
                                 { "@Amdin_Name", dto.@Amdin_Name },
                                 { "@phone_number", dto.phone_number },
                                 { "@Email", dto.Email }
                                         };

            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "Insert Admin Done" : "Failed to Insert New Admin");
        }

        [HttpPost]
        [Route("CreateEmployee")]
        public IActionResult Insert_Employe2(CreateEmployee dto)
        {
            string query = "Insert_Employe2";
            Dictionary<string, object> parms = new Dictionary<string, object>
    {
        { "@Employee_Name", dto.Employee_Name },
        { "@phone_number", dto.phone_number },
        { "@Email", dto.Email },
        { "@shift_start_time", dto.shift_start_time },
        { "@shift_End_time", dto.shift_End_time },
        { "@Admin_ID", dto.Admin_ID },
        { "@working_start_Date", dto.working_start_Date },
    };

            
            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "Insert employee Done" : "Failed Insert New employee");
        }

        [HttpPost]
        [Route("CreateOrder")]
        public IActionResult CreateOrder(CreateOrder dto)
        {
            string query = "Insert_order2 ";
            Dictionary<string, object> parms = new Dictionary<string, object>
    {
        { "@Total_price ", dto.Total_price },
        { "@Price_method ", dto.price_methid },
        { "@Cooking_period_time ", dto.Cooking_period_time },
        { "@Employee_ID ", dto.Employee_ID },
        { "@Item_ID ", dto.Item_ID },
        { "@Combo_meal_ID ", dto.Combo_meal_ID },
        { "@Customer_ID ", dto.Customer_ID },
         { "@OrderDate  ", dto.OrderDate },
    };


            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "Insert Order Done" : "Failed Insert New Order");
        }

        #endregion
        #region update "Employye and Order"
        [HttpPut]
        [Route("updateemployee")]

        public IActionResult updateemployee(CreateEmployee dto)
        {
            string query = "UpdateEmployee";

            Dictionary<string, object> parms = new Dictionary<string, object>
    {
         { "@EmployeeID", dto.employee_ID },
        { "@EmployeeName", dto.Employee_Name },
        { "@PhoneNumber", dto.phone_number },
        { "@Email", dto.Email },
        { "@ShiftStartTime", dto.shift_start_time },
        { "@ShiftEndTime", dto.shift_End_time },
        { "@AdminID", dto.Admin_ID },
        { "@WorkingStartDate", dto.working_start_Date },
    };

            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "update Employee Done" : "Failed to update Employee");
        }


        [HttpPut]
        [Route("updateorder")]
        public IActionResult updateorder(CreateOrder dto)
        {
            string query = "UpdateOrder ";
            Dictionary<string, object> parms = new Dictionary<string, object>
    {
                 { "@Order_ID ", dto.Id },
        { "@Total_price ", dto.Total_price },
        { "@Price_method ", dto.price_methid },
        { "@Cooking_period_time ", dto.Cooking_period_time },
        { "@Employee_ID ", dto.Employee_ID },
        { "@Item_ID ", dto.Item_ID },
        { "@Combo_meal_ID ", dto.Combo_meal_ID },
        { "@Customer_ID ", dto.Customer_ID },
         { "@OrderDate  ", dto.OrderDate },
    };


            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "Update Order Done" : "Failed update New Order");
        }
        #endregion
        #region delete
        [HttpDelete]
        [Route("Deleteorder")]
        public IActionResult DeleteOrder(int ID)
        {
            string query = "Deleteorder";
            Dictionary<string, object> parms = new Dictionary<string, object>
    {
                 { "@orderId  ", ID },
    };

            return Ok(ExecuteNonQueryCommandHelper(query, parms) > 0 ? "Delete Order Done" : "Failed Delete New Order");
        }
    }
        #endregion
    
}
