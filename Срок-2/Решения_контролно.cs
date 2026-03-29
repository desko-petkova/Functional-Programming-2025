using System.Runtime.InteropServices;

namespace Resheniya
{
    internal class Program
    {
        //1.Напишете рекурсивна функция PowersOfTwo(int n), която създава списък:[2⁰, 2¹, 2², ..., 2ⁿ]
        static List<double> PowersOfTwo(int n)
        {
            if (n == 0)
                return new List<Double> { 1 };

            return  PowersOfTwo(n - 1).Concat(new List<double> { Math.Pow(2, n) }).ToList();
        }
        //2.Напишете рекурсивна функция InitRange(int start, int end), която създава списък:[start, start+1, ..., end]
        static List<int> InitRange(int start, int end)
        {
            if (start > end)
                return new List<int>();

            return new List<int> { start }
                .Concat(InitRange(start + 1, end))
                .ToList();
        }

        //3.Напишете рекурсивна функция InitList(int n, Func<int,double> f), която създава списък:[f(n), f(n - 1), f(n - 2), ..., f(1)]
        static List<double> InitList(int n, Func<int, double> f)
        {
            if (n == 0)
                return new List<double>();

            return new List<double> { f(n) }
                .Concat(InitList(n - 1, f))
                .ToList();
        }

        static void Main(string[] args)
        {

            //1
            var result1 = PowersOfTwo(4);
            Console.WriteLine("[" + string.Join(", ", result1) + "]");
            //2
            var result2 = InitRange(3, 7);
            Console.WriteLine("[" + string.Join(", ", result2) + "]");
            //3
            var result3 = InitList(5, x => x + 1);
            Console.WriteLine("[" + string.Join(", ", result3) + "]");


            //1
            var words = new List<string> { "Sofia", "more", "Sun", "sky", "Code" };

            var result =
                Fold(
                    Map(
                        Filter(words, w =>  char.IsUpper(w[0])),
                        w => w.Length
                    ),
                    0,
                    (acc, x) => acc + x
                );

            Console.WriteLine(result); // 12

            //2
            var numbers = new List<int> { 3, 4, 7, 2, 8, 5 };

            var result22 =
                Fold(
                    Map(
                        Filter(numbers, x => x % 2 == 0),
                        x => x * x
                    ),
                    0,
                    (acc, x) => acc + x
                );

            Console.WriteLine(result22); // 84

            //3
            var numbers3 = new List<int> { 2, 3, 4, 5 };

            var result33 =
                Fold(
                    Filter(
                        Map(numbers3, x => x * x),
                        x => x > 20
                    ),
                    0,
                    (acc, x) => acc + 1
                );

            Console.WriteLine(result33); // 1

        }


        static List<TOut> Map<TIn, TOut>(List<TIn> list, Func<TIn, TOut> f)
        {
            if (list.Count == 0)
                return new List<TOut>();
            return new List<TOut> { f(list[0]) }
            .Concat(Map(list.Skip(1).ToList(), f)).ToList();
        }
        static List<T> Filter<T>(List<T> list, Predicate<T> predicate)
        {
            if (list.Count == 0) return new List<T>();
            var head = list[0];
            var tail = Filter(list.Skip(1).ToList(), predicate);
            if (predicate(head)) return new List<T> { head }.Concat(tail).ToList();
            return tail;
        }
        static TAcc Fold<T, TAcc>(List<T> list, TAcc acc, Func<TAcc, T, TAcc> f)
        {
            if (list.Count == 0) return acc;
            return Fold(list.Skip(1).ToList(), f(acc, list[0]), f);
        }
    }
}
