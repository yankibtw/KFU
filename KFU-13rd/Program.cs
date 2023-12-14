using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace KFU_13rd
{
    internal class Program
    {
        static void PrintTenNumbers()
        {
            for(int i = 0; i < 11; i++) {
                Console.WriteLine(i);
                Thread.Sleep(500);
            }
        }
        static async Task<long> SearchFactorial(int value)
        {
            await Task.Delay(8000);

            long factorial = 1;
            for (int i = 1; i <= value; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        static long SearchSquare(int value)
        {
            return value * value;
        }
        static async Task Main(string[] args)
        {
            ///1-ое задание
            Console.WriteLine("Задание 1:");
            Thread thr1 = new Thread(new ThreadStart(PrintTenNumbers));
            Thread thr2 = new Thread(new ThreadStart(PrintTenNumbers));
            Thread thr3 = new Thread(new ThreadStart(PrintTenNumbers));
            
            thr1.Start();
            thr2.Start();
            thr3.Start();

            thr1.Join();
            thr2.Join();
            thr3.Join();

            ///2-ое задание
            Console.WriteLine("\nЗадание 2:");
            Console.WriteLine("Введите число: ");
            if (int.TryParse(Console.ReadLine(), out int value))
            {
                Task<long> factorial = SearchFactorial(value);
                long square = SearchSquare(value);
                long factorialResult = await factorial;

                Console.WriteLine($"Квадрат числа: {square}");
                Console.WriteLine($"Факториал числа: {factorialResult}");
            }else
                Console.WriteLine("Введите число!");

            ///3-ие задание
            Console.WriteLine("\nЗадание 3");
            Refl reflInstance = new Refl();

            string[] methodNames = GetMethodNames(reflInstance);
            foreach (var methodName in methodNames)
            {
                Console.WriteLine(methodName);
            }
        }
        public static string[] GetMethodNames(object obj)
        {
            Type type = obj.GetType();
            MethodInfo[] methods = type.GetMethods();
            string[] methodNames = new string[methods.Length];

            for (int i = 0; i < methods.Length; i++)
            {
                methodNames[i] = methods[i].Name;
            }

            return methodNames;
        }
    }


}
