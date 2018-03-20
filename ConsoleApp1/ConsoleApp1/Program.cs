using System;
using System.Text;

class RandomNumberSample
{
    static void Main(string[] args)
    {        
        RandomGenerator generator = new RandomGenerator();        
        int rand = generator.RandomNumber(5, 100);
        Console.WriteLine($"Random number between 5 and 100 is {rand}");

        string str = generator.RandomString(10, false);
        Console.WriteLine($"Random string of 10 chars is {str}");

        string pass = generator.RandomPassword();
        Console.WriteLine($"Random string of 6 chars is {pass}");

        Console.WriteLine($"Random WorkItem: WI{generator.LongRandom(1000000000, 9999999999, new Random())}");
        Console.ReadKey();
    }
}

public class RandomGenerator
{
    public long LongRandom(long min, long max, Random rand)
    {
        byte[] buf = new byte[8];
        rand.NextBytes(buf);
        long longRand = BitConverter.ToInt64(buf, 0);
        return (Math.Abs(longRand % (max - min)) + min);
    }


    // Generate a random number between two numbers  
    public int RandomNumber(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }

    // Generate a random string with a given size  
    public string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    // Generate a random password  
    public string RandomPassword()
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(RandomString(4, true));
        builder.Append(RandomNumber(1000, 9999));
        builder.Append(RandomString(2, false));
        return builder.ToString();
    }

    
}