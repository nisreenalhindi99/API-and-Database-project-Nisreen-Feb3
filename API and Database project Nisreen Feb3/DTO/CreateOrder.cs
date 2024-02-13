namespace API_and_Database_project_Nisreen_Feb3.DTO
{
    public class CreateOrder
    {
        public int Id { get; set; }
        public float Total_price { get; set; }  
        public string price_methid { get; set; }

        public int Employee_ID { get; set; }
        public float Cooking_period_time { get; set; }
        public int Item_ID { get; set; }
        public int ? Combo_meal_ID { get; set; }
        public int Customer_ID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}


