using System.Numerics;

namespace PureFunc
{
    internal class Program
    {
        // 1. add :: Int -> Int
        static int Add(int x) => x + 1;

        // 2. multy :: Double -> Double -> Double
        static double Multy(double a, double b) => a * b;

        // 3. multyNum :: Num a => a -> a -> a
        static T MultyNum<T>(T x, T y) where T : INumber<T> => x * y;

        // 4. multyMax :: (Num a, Ord a) => a -> a -> a -> a
        static T MultyMax<T>(T a, T b, T x) where T : INumber<T>, IComparable<T>
        {
            var max = a.CompareTo(b) >= 0 ? a : b;
            return max * x;
        }

        // 5. max1 :: Ord a => a -> a -> a
        static T Max1<T>(T x, T y) where T : IComparable<T>
            => x.CompareTo(y) >= 0 ? x : y;

        // 6. pass3 :: Num t1 => (t1 -> t2) -> t2
        static TResult Pass3<TResult>(Func<int, TResult> f) => f(3);

        // 7. add1 :: Num a => a -> a
        static T Add1<T>(T x) where T : INumber<T> => x + T.One;

        // 8. mult2 :: Num a => a -> a
        static T Mult2<T>(T x) where T : INumber<T>
            => T.CreateChecked(2) * x;

        // 9. compose :: (t1 -> t2) -> (t3 -> t1) -> t3 -> t2
        static Func<T3, T2> Compose<T1, T2, T3>
            ( Func<T1, T2> f, Func<T3, T1> g) => x => f(g(x));

        // 10. factorial :: Int -> Int
        static int Factorial(int n)
        {
            if (n == 0) return 1;
            else
                return n * Factorial(n - 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine($"Add(5) = {Add(5)}");
            Console.WriteLine($"Multy(2.5, 4) = {Multy(2.5, 4)}");
            Console.WriteLine($"MultyNum(2, 3) = {MultyNum(2, 3)}");
            Console.WriteLine($"MultyMax(2, 5, 10) = {MultyMax(2, 5, 10)}");
            Console.WriteLine($"Max1(7, 3) = {Max1(7, 3)}");
            Console.WriteLine($"Pass3(Add) = {Pass3(Add)}");
            Console.WriteLine($"Add1(9) = {Add1(9)}");
            Console.WriteLine($"Mult2(5) = {Mult2(5)}");
            Console.WriteLine($"Factorial(5) = {Factorial(5)}");
            var f = Pass3(x => (x+1).ToString());
            Console.WriteLine(f);
  
            var composed = Compose<int, int, int>(Add, Mult2);
            Console.WriteLine($"Compose(Add, Mult2)(3) = {composed(3)}");


        }
    }
}
