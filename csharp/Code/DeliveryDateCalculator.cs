namespace RefactorConditionals;

public static class DeliveryDateCalculator
{
    public static DateTime RushDeliveryDate(Order anOrder)
    {
        return DeliveryDate(anOrder, true);
    }

    public static DateTime RegularDeliveryDate(Order anOrder)
    {
        return DeliveryDate(anOrder, false);
    }

    private static DateTime DeliveryDate(Order anOrder, bool rush)
    {
        int deliveryTime;
        if (anOrder.DeliveryState == "MA" || anOrder.DeliveryState == "CT")
            deliveryTime = rush ? 1 : 2;
        else if (anOrder.DeliveryState == "NY" || anOrder.DeliveryState == "NH")
        {
            deliveryTime = 2;
            if (anOrder.DeliveryState == "NH" && !rush)
                deliveryTime = 3;
        }
        else if (rush)
            deliveryTime = 3;
        else if (anOrder.DeliveryState == "ME")
            deliveryTime = 3;
        else
            deliveryTime = 4;

        DateTime result = anOrder.PlacedOn.AddDays(2 + deliveryTime);
        if (rush)
            result = result.AddDays(-1);
        return result;
    }

    // Example Order class
    public class Order
    {
        public Order(string deliveryState, DateTime placedOn)
        {
            DeliveryState = deliveryState;
            PlacedOn = placedOn;
        }

        public string DeliveryState { get; set; }
        public DateTime PlacedOn { get; set; }
    }
}