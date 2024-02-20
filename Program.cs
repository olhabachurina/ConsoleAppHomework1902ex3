namespace ConsoleAppHomework1902ex3
{
    class Program
    {
        private static readonly object locker = new object();
        private static List<int> numbers = new List<int> { 26, 30, 45, 50 };
        static void Main()
        {
            Console.WriteLine("Исходная коллекция чисел:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
            Thread t1 = new Thread(DecreaseNumbers);
            Thread t2 = new Thread(DecreaseNumbers);
            Thread t3 = new Thread(DecreaseNumbers);
            t1.Start();
            t2.Start();
            t3.Start();
            t1.Join();
            t2.Join();
            t3.Join();
            Console.WriteLine("Коллекция чисел после выполнения метода в 3 потоках:");
            numbers.ForEach(n => Console.Write(n + " "));
            Console.WriteLine();
        }
        static void DecreaseNumbers()
        {
            lock (locker)
            {
                for (int i = 0; i < numbers.Count; i++)
                {
                    numbers[i] -= 1;
                }
                Console.WriteLine($"Коллекция после уменьшения на 1 в потоке {Thread.CurrentThread.ManagedThreadId}:");
                numbers.ForEach(n => Console.Write(n + " "));
                Console.WriteLine();
            }
        }
    }
}
