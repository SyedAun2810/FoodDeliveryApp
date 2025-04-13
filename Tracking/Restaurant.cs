using FoodDeliveryApp.FoodDeliveryDriver;

namespace FoodDeliveryApp.Tracking
{
    public class Restaurant : FoodDelivery
    {
        public Restaurant(string restaurantId, string orderId, IOrderState deliveryStatus)
            : base(restaurantId, orderId, deliveryStatus) { }

        public void UpdateDeliveryStatus(IOrderState newStatus, string estimatedDeliveryTime)
        {
            this.DeliveryStatus = newStatus;
            this.NotifyDetailed(estimatedDeliveryTime);
        }
    }
}
