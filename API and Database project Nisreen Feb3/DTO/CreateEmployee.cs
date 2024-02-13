namespace API_and_Database_project_Nisreen_Feb3.DTO
{
    public class CreateEmployee
    {
        public int employee_ID { get; set; }
        public string Employee_Name {  get; set; }
        public string phone_number { get; set; }
        public string Email { get; set; }
       public DateTime shift_start_time { get; set; }
        public DateTime @shift_End_time { get; set; }
      public int Admin_ID { get; set; }
        public DateTime working_start_Date { get; set; }
     
    }
}
