using FoodDeliveryApp.FoodDeliveryAppModel;
using FoodDeliveryApp.Tracking;
using System.Threading;
using System;

namespace FoodDeliveryApp.FoodDeliveryDriver
{
    public class OrderTrackingDriver
    {
        private IOrderState currentState;
        public IOrderState PreviousState { get; private set; }

        public OrderTrackingDriver()
        {
            currentState = new OrderReceivedState();
            PreviousState = null;
        }

        public void SetState(IOrderState state)
        {
            PreviousState = currentState; // Track the previous state
            currentState = state;
        }

        public void OrderTrackingByUser(string restaurantId, string orderId, UserModel user, char cancel)
        {
            //Order Tracking.
            if (cancel != 'y')
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine("Food Delivery Status");
                Console.WriteLine("---------------------");

                Restaurant restaurant = new Restaurant(restaurantId, orderId, new  OrderReceivedState());
                restaurant.Attach(new Customers(user));

                while (currentState != null)
                {
                    if (currentState != null) restaurant.DeliveryStatus = currentState;
                    if (currentState != null)
                    {
                        currentState.Handle(this); // Trigger the next state's behavior
                    }
                }
            }

            Console.ReadKey();
        }
    }

}
