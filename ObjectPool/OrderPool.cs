public class OrderPool
    {
        private static Lazy<OrderPool> instance
            = new Lazy<OrderPool>(() => new OrderPool());
        public static OrderPool Instance { get; } = instance.Value;

        private const int defaultSize = 5;
        private ConcurrentBag<Order> _bag = new ConcurrentBag<Order>();
        private volatile int _currentSize;
        private volatile int _counter;
        private object _lockObject = new object();

        private OrderPool()
            : this(defaultSize)
        {
        }
        private OrderPool(int size)
        {
            _currentSize = size;
        }

        public Order AcquireObject()
        {
            if (!_bag.TryTake(out Order item))
            {
                lock (_lockObject)
                {
                    if (item == null)
                    {
                        if (_counter >= _currentSize)
                            throw new Exception();

                        item = new RequestOrder();
                        _counter++;

                    }
                }

            }

            return item;
        }

        public void ReleaseObject(Order item)
        {
            _bag.Add(item);
        }
        public void IncreaseSize()
        {
            lock (_lockObject)
            {
                _currentSize++;
            }
        }
    }


    public abstract class Order
    {
        public abstract string GatherOrder();
    }

    internal class RequestOrder : Order
    {
        public override string GatherOrder()
        {
            Thread.Sleep(1000);
            return "Gathering order with RequestOrder...";
        }
    }

public class ObjectPoolRun
    {
        public static void Main(string[] args)
        {
            int counter = 0;
            Parallel.For(0, 100, (i, loopState) =>
            {
                Order order;
                Exception e = null;
                do
                {
                    try
                    {
                        order = OrderPool.Instance.AcquireObject();
                        Console.WriteLine("Thread " + Thread.CurrentThread.GetHashCode() + " : " + order.GatherOrder() + " Instance id : " + order.GetHashCode());
                        OrderPool.Instance.ReleaseObject(order);
                        e = null;
                        counter++;
                    }
                    catch (Exception ex)
                    {
                        Thread.Sleep(1000);
                        Console.WriteLine("Waiting...");
                        e = ex;
                    }
                } while (e != null);
            });

            Console.WriteLine("Counter : " + counter);
        }
    }