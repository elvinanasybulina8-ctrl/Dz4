using System;
using System.Linq;

namespace Homework4
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Task1();
            Task2();
            Task3();
            Task4();

            Console.ReadKey();
        }

        // ЗАДАЧА 1. Массив из 20 случайных чисел, поменять два местами
        
        static void Task1()
        {
            Console.WriteLine( "1.Массив из 20 случайных чисел. Поменять два элемента местами.");

            int[] numbers = new int[20];
            Random rnd = new Random();
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] = rnd.Next(1, 100);

            Console.WriteLine("Исходный массив:");
            PrintArray(numbers);

            Console.Write("Введите индекс первого элемента (0..19): ");
            int i1 = ReadIndex(numbers.Length);

            Console.Write("Введите индекс второго элемента (0..19): ");
            int i2 = ReadIndex(numbers.Length);

            (numbers[i1], numbers[i2]) = (numbers[i2], numbers[i1]);

            Console.WriteLine("Массив после обмена:");
            PrintArray(numbers);

            Pause();
        }

        // ЗАДАЧА 2. Метод с params, ref, out
        static void Task2()
        {
            Console.WriteLine( "2.Метод с params, ref и out: сумма, произведение, среднее.");

            int[] numbers = { 2, 4, 6, 8, 10 };
            Console.WriteLine("Массив:");
            PrintArray(numbers);

            long product = 1;
            int sum = CalculateArray(ref product, out double average, numbers);

            Console.WriteLine($"Сумма элементов:          {sum}");
            Console.WriteLine($"Произведение элементов:   {product}");
            Console.WriteLine($"Среднее арифметическое:   {average:F2}");

            Pause();
        }

        /// <summary>
        /// Считает сумму, произведение (ref) и среднее (out) элементов массива.
        /// </summary>
        static int CalculateArray(ref long product, out double average, params int[] numbers)
        {
            int sum = 0;
            product = 1;

            if (numbers == null || numbers.Length == 0)
            {
                average = 0;
                return 0;
            }

            foreach (int n in numbers)
            {
                sum += n;
                product *= n;
            }

            average = (double)sum / numbers.Length;
            return sum;
        }

        // ЗАДАЧА 3. Рисование цифры символами '#', красный цвет при ошибке, выход по "exit"
        
        static void Task3()
        {
            Console.WriteLine( "3.Введите цифру 0..9 — будет нарисована символами '#'");

            while (true)
            {
                Console.Write("Введите цифру (0..9) или 'exit': ");
                string input = Console.ReadLine()!;

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (input.Trim().ToLower() == "exit")
                    break;

                try
                {
                    // Если введено не число — исключение FormatException
                    int digit = int.Parse(input);

                    if (digit >= 0 && digit <= 9)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        DrawDigit(digit);
                        Console.ResetColor();
                    }
                    else
                    {
                        ShowError("Число должно быть от 0 до 9!");
                    }
                }
                catch (FormatException)
                {
                    // По заданию — программа должна выпасть в исключение
                    throw;
                }
            }
        }

        /// <summary>Рисует цифру 0..9 символами '#' (5x5).</summary>
        static void DrawDigit(int digit)
        {
            string[] pattern = digit switch
            {
                0 => new[] { 
                    " ### ",
                    "#   #",
                    "#   #", 
                    "#   #", 
                    " ### " },
                1 => new[] { 
                    "  #  ",
                    " ##  ", 
                    "  #  ", 
                    "  #  ",
                    " ### " },
                2 => new[] { 
                    " ### ", 
                    "#   #", 
                    "   # ", 
                    "  #  ", 
                    "#####" },
                3 => new[] {
                    " ### ",
                    "#   #", 
                    "  ## ", 
                    "#   #",
                    " ### " },
                4 => new[] { 
                    "#   #", 
                    "#   #", 
                    "#####", 
                    "    #", 
                    "    #" },
                5 => new[] { 
                    "#####", 
                    "#    ", 
                    "#### ", 
                    "    #", 
                    "#### " },
                6 => new[] {
                    " ### ",
                    "#    ", 
                    "#### ", 
                    "#   #", 
                    " ### " },
                7 => new[] { 
                    "#####",
                    "    #",
                    "   # ",
                    "  #  ", 
                    "  #  " },
                8 => new[] { 
                    " ### ", 
                    "#   #", 
                    " ### ",
                    "#   #", 
                    " ### " },
                9 => new[] { 
                    " ### ",
                    "#   #",
                    " ####", 
                    "    #",
                    " ### " },
                _ => Array.Empty<string>()
            };

            foreach (string line in pattern)
                Console.WriteLine(line);
        }

        static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
            System.Threading.Thread.Sleep(3000); // 3 секунды
        }

        
        // ЗАДАЧА 4. Структура Дед, ворчание, бабка
        static void Task4()
        {
            Console.WriteLine( "4.Структура Дед: ворчание, матерные слова и синяки от бабки.");

            string[] swearWords = { "блин", "ёлки-палки", "ёпрст", "чёрт", "караул" };

            Ded[] grandfathers =
            {
                new Ded("Иван",   Grumpiness.Спокойный, new[] { "Проститутки!", "Гады!", "Опять эти гуси!" }),
                new Ded("Пётр",   Grumpiness.Ворчливый, new[] { "Ну куда ты лезешь!", "Ох, молодёжь..." }),
                new Ded("Семён",  Grumpiness.ОченьВорчливый, new[] { "Да чтоб тебя!", "Совсем стыд потеряли!" }),
                new Ded("Николай", Grumpiness.Ворчливый, new[] { "Ох, ёлки-палки...", "Ну что за день сегодня!" }),
                new Ded("Фёдор",  Grumpiness.ОченьВорчливый, new[] { "Проститутки!", "Чёрт бы вас побрал!" })
            };

            Console.WriteLine("Начальное состояние дедов:");
            foreach (var d in grandfathers)
                Console.WriteLine($"  {d}");

            Console.WriteLine("\nПроверяем дедов на матерные слова...\n");
            foreach (var d in grandfathers)
            {
                int bruises = d.CountBruises(swearWords);
                Console.WriteLine($"  Дед {d.Name}: фразы — [{string.Join(", ", d.Phrases)}]");
                Console.WriteLine($"     Найдено совпадений: {bruises}, фингалов: {d.BlackEyes}\n");
            }

            Console.WriteLine("Итоговое состояние дедов:");
            foreach (var d in grandfathers)
                Console.WriteLine($"  {d}");

            Pause();
        }

        enum Grumpiness
        {
            Спокойный,
            Ворчливый,
            ОченьВорчливый
        }

        struct Ded
        {
            public string Name;
            public Grumpiness Level;
            public string[] Phrases;
            public int BlackEyes;

            public Ded(string name, Grumpiness level, string[] phrases)
            {
                Name = name;
                Level = level;
                Phrases = phrases;
                BlackEyes = 0; // по умолчанию
            }

            /// <summary>
            /// Принимает деда, список матерных слов (params).
            /// За каждое матерное слово в лексике деда бабка ставит фингал.
            /// Возвращает количество фингалов.
            /// </summary>
            public int CountBruises(params string[] swearWords)
            {
                if (Phrases == null || swearWords == null) return BlackEyes;

                foreach (string phrase in Phrases)
                {
                    foreach (string swear in swearWords)
                    {
                        if (phrase.IndexOf(swear, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            BlackEyes++;
                            break; // одно слово — один фингал для этой фразы
                        }
                    }
                }
                return BlackEyes;
            }

            public override string ToString()
                => $"Дед {Name} ({Level}), фингалов: {BlackEyes}";
        }

       
        // ВСПОМОГАТЕЛЬНЫЕ МЕТОДЫ
        

        static void PrintHeader(int number, string description)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(new string('=', 70));
            Console.WriteLine($"ЗАДАНИЕ {number}. {description}");
            Console.WriteLine(new string('=', 70));
            Console.ResetColor();
        }

        static void PrintArray(int[] arr)
        {
            Console.WriteLine(string.Join(", ", arr));
        }

        static int ReadIndex(int length)
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int index) &&
                    index >= 0 && index < length)
                    return index;

                Console.Write($"Некорректно. Введите число от 0 до {length - 1}: ");
            }
        }

        static void Pause()
        {
            Console.WriteLine("\nНажмите любую клавишу, чтобы продолжить...");
            Console.ReadKey(true);
            Console.WriteLine();
        }
    }
}