using System;

namespace Tumakov5;

internal class Program
{
    static void Main()
    {
        //Упр 5.1
        Console.WriteLine("Упр 5.1");
        Console.WriteLine("Найти наибольшее из двух чисел.");
        Console.Write("Введите первое число: ");

        int a = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");

        int b = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Наибольшее число: " + GetMax(a, b));


        //Упр 5.2
        Console.WriteLine("Упр 5.2");
        Console.WriteLine("Поменять местами значения двух чисел.");
        Console.Write("Введите первое число: ");

        int x = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");

        int y = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"До обмена: x = {x}, y = {y} ");
        Swap(ref x, ref y);
        Console.WriteLine($"После обмена: x = {x},y = {y} ");


        //Упр 5.3
        Console.WriteLine("Упр 5.3");
        Console.WriteLine("Вычислить факториал числа");
        Console.Write("Введите число: ");
        int n = Convert.ToInt32(Console.ReadLine());
        if (Factorial(n, out long factorial))
        {
            Console.WriteLine($"Факториал числа {n}: {factorial}");
        }
        else
        {
            Console.WriteLine("Произошло переполнение.");

        }


        // Упр 5.4
        Console.WriteLine("Упр 5.4");
        Console.WriteLine("Вычислить факториал рекурсивным методом.");
        Console.Write("Введите число: ");

        int number = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Факториал числа {number}: {RecursiveFactorial(number)}");


        // Дз 5.1
        Console.WriteLine("Дз 5.1");
        Console.WriteLine("Вычислить НОД двух натуральных чисел.");
        Console.Write("Введите первое число: ");

        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите второе число: ");

        int num2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("НОД двух чисел: " + GCD(num1, num2));
        Console.Write("Введите третье число: ");

        int num3 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("НОД трех чисел: " + GCD(num1, num2, num3));


        // Дз 5.2
        Console.WriteLine("Дз 5.2");
        Console.WriteLine("Вычислить n-е число ряда Фибоначчи.");
        Console.Write("Введите номер числа Фибоначчи: ");

        int f = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"Число Фибоначчи с номером {f}: {Fibonacci(f)}");

    }

    //Методы
    //Упр 5.1
    static int GetMax(int a, int b)
    {
        if (a > b)
            return a;
        else
            return b;
    }

    //Упр 5.2
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    //Упр 5.3
    static bool Factorial(int n, out long result)
    {
        result = 1;
        try
        {
            checked
            {
                for (int i = 1; i <= n; i++)
                {
                    result *= i;
                }
            }
            return true;
        }
        catch (OverflowException)
        {
            result = 0;
            return false;
        }
    }

    // Упр 5.4
    static long RecursiveFactorial(int n)
    {
        if (n <= 1)
            return 1;
        return n * RecursiveFactorial(n - 1);
    }

    // Дз 5.1
    static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;

            b = a % b;

            a = temp;
        }
        return a;
    }

    // Перегрузка метода GCD для трех чисел

    static int GCD(int a, int b, int c)
    {
        return GCD(GCD(a, b), c);
    }

    // Дз 5.2
    static long Fibonacci(int n)
    {
        if (n <= 2)
            return 1;
        return Fibonacci(n - 1) + Fibonacci(n - 2);
    }

}
