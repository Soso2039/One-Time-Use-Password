using System;
using System.Diagnostics;

public class Problem
{

    public static bool IsValidDate(string dateString)
    {
        if (DateTime.TryParse(dateString, out DateTime date))
        {
            return date.Date == DateTime.Today;
        }
        else
        {
            return false;
        }
    }

    public static string AnagramPassword(string Id)
    {
        int length = Math.Min(Id.Length, 5);
        string initialSubstring = Id.Substring(0, length);

        char[] charArray = initialSubstring.ToCharArray();
        Random random = new Random();

        for (int i = 0; i < charArray.Length; i++)
        {
            int j = random.Next(i, charArray.Length);
            char temp = charArray[i];
            charArray[i] = charArray[j];
            charArray[j] = temp;
        }

        string scrambledSubstring = new string(charArray);
        return scrambledSubstring;
    }


    public static void Main(string[] args)
    {
        string IdString = "";

        do
        {
            Console.WriteLine("Enter the User ID (At least 5 characters):");
            IdString = Console.ReadLine();
        } while (IdString.Length < 5);


        string password = AnagramPassword(IdString);

        bool DateisValid = false;
        string dateString = "";

        do
        {
            Console.WriteLine("Enter the current date (yyyy-MM-dd):");
            dateString = Console.ReadLine();

            DateisValid = IsValidDate(dateString);

            if (!DateisValid)
            {
                Console.WriteLine("Invalid date. Please try again.");
            }

        } while (!DateisValid);

        Console.WriteLine("The password is: " + password);
        Console.WriteLine("You have 30 seconds to enter the password:");

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        bool isPasswordCorrect = false;
        string enteredPassword;

        do
        {
            enteredPassword = Console.ReadLine();

            if (stopwatch.ElapsedMilliseconds >= 30000)
            {
                Console.WriteLine("Time is up. Password expired.");
                break;
            }

            if (enteredPassword == password)
            {
                Console.WriteLine("Password is correct!");
                isPasswordCorrect = true;
            }
            else
            {
                Console.WriteLine("Wrong password. Enter the password again:");
            }

        } while (!isPasswordCorrect);

        stopwatch.Stop();

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}