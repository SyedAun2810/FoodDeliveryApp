namespace FoodDeliveryApp.FoodDeliveryDriver
{
    public interface IOrderState
    {
        void Handle(OrderTrackingDriver context);
    }
}
