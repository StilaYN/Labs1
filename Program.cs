using System.Collections.Generic;

namespace Labs1
{
    internal class Program
    {
        public static float FirstFunction(float x) => x * x - 20 * (float)Math.Sin(x) - 5;
        public static float FirstDerivedFunction(float x) => 2 * x - 20 * (float)Math.Cos(x);
        public static float FirstSecondDerivedFunction(float x) => 2 + 20 * (float)Math.Sin(x);
        public static float SecondFunction(float x) => 100 * x * x - 10000 * x - 1;
        public static float SecondDerivedFunction(float x) => 200 * x - 10000;
        public static float SecondSecondDerivedFunction(float x) => 200;

        public static void Print(IFindRoot first, IFindRoot second)
        {
            Console.WriteLine("___________________________");
            Console.WriteLine(first.FindRoot(-5,-4.5f, 1));
            Console.WriteLine(first.FindRoot(-4, -3,1));
            Console.WriteLine(first.FindRoot(-1,0 ,1));
            Console.WriteLine(first.FindRoot(2,3, 1));
            Console.WriteLine("___________________________");
            Console.WriteLine(second.FindRoot(-1,1 ,1));
            Console.WriteLine(second.FindRoot(99,101, 1));
            Console.WriteLine("___________________________");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Newtown Method");
            NewtonMethod firstNewtonMethod = new NewtonMethod(FirstFunction,FirstDerivedFunction,FirstSecondDerivedFunction);
            NewtonMethod secondNewtonMethod = new NewtonMethod(SecondFunction, SecondDerivedFunction,SecondSecondDerivedFunction);
            Print(firstNewtonMethod,secondNewtonMethod);
            Console.WriteLine("Iteration Method");
            IterationMethod firstIterationMethod = new IterationMethod(FirstFunction, FirstDerivedFunction);
            IterationMethod secondIterationMethod = new IterationMethod(SecondFunction,SecondDerivedFunction);
            Print(firstIterationMethod,secondIterationMethod);
            HalfIntervalMethod firstHalfIntervalMethod = new HalfIntervalMethod(FirstFunction);
            HalfIntervalMethod secondHalfIntervalMethod = new HalfIntervalMethod(SecondFunction);
            Console.WriteLine("Half Interval Method");
            Print(firstHalfIntervalMethod,secondHalfIntervalMethod);
        }
    }
}