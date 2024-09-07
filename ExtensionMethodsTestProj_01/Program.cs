//•  Random.NextDouble() only returns values between 0 and 1, and they often need to be able to 
//produce random double values between 0 and another number, such as 0 to 10. 
//•  They need to randomly choose from one of several strings, such as "up", "down", "left", and 
//"right", with each having an equal probability of being chosen. 
//•  They need to do a coin toss, randomly picking a bool, and usually want it to be a fair coin toss (50% 
//heads and 50% tails) but occasionally want unequal probabilities. For example, a 75% chance of true 
//and a 25% chance of false. 

//Objectives: 
//•  Create a new static class to add extension methods for Random. 
//•  As described above, add a  NextDouble  extension method that gives a maximum value for a 
//randomly generated double. 
//•  Add a NextString extension method for Random that allows you to pass in any number of string 
//values (using params) and randomly pick one of them. 
//•  Add a CoinFlip method that randomly picks a bool value. It should have an optional parameter 
//that indicates the frequency of heads coming up, which should default to 0.5, or 50% of the time. 
//•  Answer this question:  In your opinion, would it be better to make a derived AdvancedRandom 
//class that adds these methods or use extension methods and why? 
using System.Reflection.Metadata.Ecma335;

internal class Program
{
    public static void Main(string[] args)
    {
        string s = "Hello, World!";
        Random random = new Random();
        Console.WriteLine(random.NextDouble2());
        Console.WriteLine(random.NextString("1", "2", "3", "4", "5"));

        double freq = 0.45;
        int yesAns = 0;
        int noAns = 0;
        for (int i = 0; i < 1000000; ++i) {
            if (random.CoinFlip(freq) == true)
            {
                ++yesAns;
            }
            else 
            {
                ++noAns;
            }
        }
        Console.WriteLine($"yes: {yesAns}, no: {noAns}");
    }
}

public static class RandomExtensions {
    public static double NextDouble2(this Random random) {
        return random.NextDouble() * double.MaxValue;
    }
    public static string NextString(this Random random, params string[] strings) {
        int count = strings.Length;
        int number = random.Next(0, count);
        return strings[number];
    }
    public static bool CoinFlip(this Random random, double frequency) {        
        if (frequency - random.NextDouble() > 0)
           return true; 
        return false; 
    }
}