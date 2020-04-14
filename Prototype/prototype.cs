using System;

abstract class OrderPrototype
    {
        public int OrderId;
        public string OrderCode;
        public string OrderStatus;

        public OrderPrototype(int orderId, string orderCode, string orderStatus)
        {
            OrderId = orderId;
            OrderCode = orderCode;
            OrderStatus = orderStatus;
        }

        public abstract OrderPrototype Clone();
    }


    class OrderForDeep : OrderPrototype
    {
        public OrderForDeep(int orderId, string orderCode, string orderStatus) : base(orderId, orderCode, orderStatus)
        {
        }

        public override OrderPrototype Clone()
        {
            return this;
        }
    }

    class OrderForShallow : OrderPrototype
    {
        public OrderForShallow(int orderId, string orderCode, string orderStatus) : base(orderId, orderCode, orderStatus)
        {
        }

        public override OrderPrototype Clone()
        {
            return (OrderPrototype)MemberwiseClone();
        }
    }

public class MainPrototypeClass
{
    public static void Main(string[] args)
    {
        OrderForShallow order1 = new OrderForShallow(1, "RandomCompany", "Entered");
        OrderForShallow order2 = (OrderForShallow)order1.Clone();
        order2.OrderId = 2;

        Console.WriteLine("Order 1:");
        Console.WriteLine("ID: " + order1.OrderId + " Name: " + order1.OrderCode + " Category: " + order1.OrderStatus);

        Console.WriteLine("Order 2:");
        Console.WriteLine("ID: " + order2.OrderId + " Name: " + order2.OrderCode + " Category: " + order2.OrderStatus);


        OrderForDeep order3 = new OrderForDeep(1, "RandomCompany", "Entered");
        OrderForDeep order4 = (OrderForDeep)order3.Clone();
        order4.OrderId = 3;

        Console.WriteLine("Order 3:");
        Console.WriteLine("ID: " + order3.OrderId + " Name: " + order3.OrderCode + " Category: " + order3.OrderStatus);

        Console.WriteLine("Order 4:");
        Console.WriteLine("ID: " + order4.OrderId + " Name: " + order4.OrderCode + " Category: " + order4.OrderStatus);
    }
}

        