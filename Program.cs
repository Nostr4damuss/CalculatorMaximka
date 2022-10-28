using System;
using System.Numerics;

namespace Calculator
{
    class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.

            // Use a switch statement to do the math.
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    // Ask the user to enter a non-zero divisor.
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    break;
                // Return text for an incorrect option entry.
                default:
                    break;
                case "st":
                    result = Math.Pow(num1, num2);
                    break;
                case "Корень":
                    result = Math.Sqrt(num1);
                    break;
                case "kva":
                    result = Math.Sqrt(num1);
                    break;
                case "pro":
                    result = num1 / 100;
                    break;
                case "fac":
                    Console.WriteLine("Введите число");
                    double b = Convert.ToDouble(Console.ReadLine());
                    int factorial = 1;
                    for (int i = 2; i <= b; i++) // Вычисление факториала.
                    {
                        factorial *= i;
                    }

                    Console.WriteLine(factorial);
                    break;
                    break;
            }
            return result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            bool endApp = false;
            // Display title as the C# console calculator app.
            Console.WriteLine("Калькулятор Макс\r");
            Console.WriteLine("------------------------\n");

            while (!endApp)
            {
                // Declare variables and set to empty.
                string numInput1 = "";
                string numInput2 = "";
                double result = 0;

                // Ask the user to type the first number.
                Console.Write("Введи первое число и нажми Enter");
                numInput1 = Console.ReadLine();

                double cleanNum1 = 0;
                while (!double.TryParse(numInput1, out cleanNum1))
                {
                    Console.Write("Че-то не то: ");
                    numInput1 = Console.ReadLine();
                }

                // Ask the user to type the second number.
                Console.Write("Введи второе число и нажми Enter");
                numInput2 = Console.ReadLine();

                double cleanNum2 = 0;
                while (!double.TryParse(numInput2, out cleanNum2))
                {
                    Console.Write("Это недопустимый ввод. Пожалуйста, введите целое значение: ");
                    numInput2 = Console.ReadLine();
                }

                // Ask the user to choose an operator.
                Console.WriteLine("Выбери оператора из следующего списка");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("\tst - Stepen");
                Console.WriteLine("\tkva - Kvadratkoren");
                Console.WriteLine("\tpro - Procent");
                Console.WriteLine("\tfac - Factorial");
                Console.Write("Что выберешь? ");

                string op = Console.ReadLine();

                try
                {
                    result = Calculator.DoOperation(cleanNum1, cleanNum2, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("Эта операция приведет к математической ошибке.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("О, нет! При попытке выполнить математические вычисления возникло исключение.\n - Details: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                // Wait for the user to respond before closing.
                Console.Write("Нажми n, а потом Enter, чтобы завершить, или нажми любую клавишу, а потом Enter, чтобы продолжить: ");
                if (Console.ReadLine() == "n") endApp = true;

                Console.WriteLine("\n"); // Friendly linespacing.
            }
            return;
        }
    }
}