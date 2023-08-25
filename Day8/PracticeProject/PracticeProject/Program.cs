internal class Program
{

    static void MyMethod()
    {
        Console.WriteLine("I just got executed!");
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.Write("Dispaly in the ");
        Console.Write("same line");
        //This is single line command
        /*This is multi-
          line command*/
        Console.WriteLine("\nEnter your name");
        string name = Console.ReadLine();
        Console.WriteLine("Hi, " + name);
        Console.WriteLine(Math.Max(10, 23));
        Console.WriteLine(name.Length);
        Console.WriteLine(name[3]);

        if (1 > 0)
        {
            Console.WriteLine("1 is greater");
        }
        else
        {
            Console.WriteLine("0 is greater");
        }

        int day = 4;
        switch (day)
        {
            case 1:
                Console.WriteLine("Monday");
                break;
            case 2:
                Console.WriteLine("Tuesday");
                break;
            case 3:
                Console.WriteLine("Wednesday");
                break;
            case 4:
                Console.WriteLine("Thursday");
                break;
            case 5:
                Console.WriteLine("Friday");
                break;
            case 6:
                Console.WriteLine("Saturday");
                break;
            case 7:
                Console.WriteLine("Sunday");
                break;
        }

        int i= 0;
        while (i < 5)
        {
            Console.WriteLine(i);
            i++;
        }

        string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
        foreach (string j in cars)
        {
            Console.WriteLine(j);
        }

        Array.Sort(cars);
        foreach (string k in cars)
        {
            Console.WriteLine(k);
        }

        MyMethod();

    }
}