namespace CustomContainer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomContainer<int> custom1 = new CustomContainer<int>(1){};
            custom1.Add(2);
            custom1.Add(3);
            custom1.Add(4);
            custom1.Add(5);
            custom1.Add(6);
            custom1.Add(7);
            custom1.Add(8);
            custom1.Add(9);
            custom1.Add(10);
            custom1.Print();
            Console.WriteLine(custom1[5]);
            custom1[5] = 15;
            Console.WriteLine(custom1[5]);
            custom1.Print();
        }
    }
}
