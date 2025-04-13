namespace FoodDeliveryApp.FoodDeliveryDriver
{
    using System;
    using System.Threading;

    public class OrderReceivedState : IOrderState
    {
        public void Handle(OrderTrackingDriver context)
        {
            AddRandomDelay();

            // 25% chance to go to DelayedState
            if (ShouldGoToDelayedState())
            {
                context.SetState(new DelayedState());
            }
            else
            {
                context.SetState(new OnTheWayState());
            }
        }

        private void AddRandomDelay()
        {
            Random random = new Random();
            int delay = random.Next(1, 3) * 1000; // Random delay of 1 or 2 seconds
            Thread.Sleep(delay);
        }

        private bool ShouldGoToDelayedState()
        {
            Random random = new Random();
            return random.Next(0, 4) == 0; // 25% chance (0 out of 0, 1, 2, 3)
        }
    }

    public class OnTheWayState : IOrderState
    {
        public void Handle(OrderTrackingDriver context)
        {
            AddRandomDelay();

            // 25% chance to go to DelayedState
            if (ShouldGoToDelayedState())
            {
                context.SetState(new DelayedState());
            }
            else
            {
                context.SetState(new DeliveredState());
            }
        }

        private void AddRandomDelay()
        {
            Random random = new Random();
            int delay = random.Next(1, 3) * 1000;
            Thread.Sleep(delay);
        }

        private bool ShouldGoToDelayedState()
        {
            Random random = new Random();
            return random.Next(0, 4) == 0;
        }
    }

    public class DelayedState : IOrderState
    {
        public void Handle(OrderTrackingDriver context)
        {
            // Determine the next state based on the previous state
            if (context.PreviousState is OnTheWayState)
            {
                context.SetState(new DeliveredState());
            }
            else if (context.PreviousState is OrderReceivedState)
            {
                context.SetState(new OnTheWayState());
            }
        }
    }

    public class DeliveredState : IOrderState
    {
        public void Handle(OrderTrackingDriver context)
        {
            context.SetState(null);
        }
    }
}
