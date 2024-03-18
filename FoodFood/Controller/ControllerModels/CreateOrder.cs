namespace FoodFood.Controller.ControllerModels
{
    public class CreateOrder
    {
        public DateTime OrderDate { get; set; }
        public bool IsDelivered { get; set; }
        public double TotalPrice { get; set; }

    }
}
