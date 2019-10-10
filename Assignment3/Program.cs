/**************************************
 * CIS 3343 
 * John Velazquez
 **************************************
 * Assignment 3
 * Employee Pay
 * Date: 10/3/2019
 **************************************
 * Takes user inputted amount of
 * employees and creates an array of
 * Employee objects. Then loops through
 * the array creating the Employee
 * objects with name and hourly rate.
 * Loops one final time asking for the
 * hours worked by the employees and
 * calculates their pay including a
 * multiplier for overtime.
 **************************************/

using System;

namespace Assignment3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Employee App v1.0\n");
            int empCount = PromptForInteger("Enter the number of employees: ", 1, 100);

            //This bit of code below deals with a try catch that ensures that an 
            //integer is being entered and not a string or double. Can replaced
            //with line 29. Ideally would have all of it within a method.
            /*
            int empCount = 0;
            bool exit = false;
            do
            {
                if(empCount < 0) //Checks if a negative number is entered
                {
                    Console.WriteLine("Please enter a non-negative integer...\n");
                    empCount = 0;
                }

                try //Checks if an integer is entered and not a string or a double
                {
                    Console.Write("Enter the number of employees: ");
                    empCount = Convert.ToInt32(Console.ReadLine());
                    exit = true;
                }
                catch
                {
                    Console.WriteLine("An error occured.\nPlease enter a non-negative integer...\n");
                    exit = false;
                }

                //exit = true;
            } while (!exit);
            */

            Console.WriteLine("creating an array of employess..." +
                    "\n\nusing a loop to populate the employees...");

            Employee[] emp = new Employee[empCount];

            for(int i = 0; i < emp.Length; i++)
            {
                emp[i] = new Employee();

                Console.Write($"Enter the first name for employee #{i}: ");
                emp[i].FirstName = Console.ReadLine();

                Console.Write($"Enter the last name for employee #{i}: ");
                emp[i].LastName = Console.ReadLine();

                emp[i].HourlyRate = PromptForDouble($"Enter the hour pay rate for employee #{i}: ", Employee.MIN_HOURLY_RATE, Employee.MAX_HOURLY_RATE);

                Console.WriteLine();
            }

            Console.WriteLine("using another loop to calculate their pay...");
            for (int i = 0; i < emp.Length; i++)
            {
                double hours = PromptForDouble($"Enter the number of hours for {emp[i].FullName()}: ", 0, Employee.MAX_HOURS);
                Console.WriteLine($"The pay for {emp[i].FullName()} is {emp[i].CalcPay(hours):C}\n");
            }

            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

        static double PromptForDouble(string message, double minVal, double maxVal)
        {
            double answer = -1;
            bool gotIt = false;

            do
            {
                Console.Write(message);
                answer = Convert.ToDouble(Console.ReadLine());
                if (answer < minVal || answer > maxVal)
                {
                    Console.WriteLine($"Number is out of range, valid values are between {minVal} and {maxVal}.\nPlease try again");
                }
                else
                {
                    gotIt = true;
                }
            } while (!gotIt);

            return answer;
        }

        static int PromptForInteger(string message, int minVal, int maxVal)
        {
            int answer = -1;
            bool gotIt = false;

            do
            {
                Console.Write(message);
                answer = Convert.ToInt32(Console.ReadLine());
                if (answer < minVal || answer > maxVal)
                {
                    Console.WriteLine($"Number is out of range, value values are between {minVal} and {maxVal}.  Please try again");
                }
                else
                {
                    gotIt = true;
                }
            } while (!gotIt);

            return answer;
        }
    }
}
