namespace FilterMapFold
{
    internal class Program
    {
        //рекурсивна идея reduce
        static int Fold(List<int> list, int acc, Func<int, int, int> f)
        {
            if (list.Count == 0)
                return acc;

            return Fold(
                list.Skip(1).ToList(),
                f(acc, list[0]),
                f
            );
        }
        //Рекурсивна идея за map
        static List<R> Map<T, R>(List<T> list, Func<T, R> f)
        {
            if (list.Count == 0)
                return new List<R>();

            return new List<R> { f(list[0]) }
                   .Concat(Map(list.Skip(1).ToList(), f))
                   .ToList();
        }
       
        //Рекурсивна идея за филтър
        static List<int> Filter(List<int> list, Predicate<int> p)
        {
            if (list.Count == 0)
                return new List<int>();

            var head = list[0];
            var tail = list.Skip(1).ToList();

            if (p(head))
                return new List<int> { head }
                       .Concat(Filter(tail, p))
                       .ToList();

            return Filter(tail, p);
        }
        static void Main(string[] args)
        {
            // filter – избира елементи
            // Взима списък и връща нов списък,
            // съдържащ само елементите, които отговарят на условие.

            var nums = new List<int> { 1, 2, 3, 4, 5, 6 };

            var evens = nums.Where(x => x % 2 == 0).ToList();
            Console.WriteLine(string.Join(" ", evens));

            //map – преобразува елементи
            //Взима списък и връща нов списък, като променя всеки елемент.
            //List<T> → Func<T, R> → List<R>

            var doubled = nums.Select(x => x * 2).ToList();
            Console.WriteLine(string.Join(" ", doubled));

            //fold / reduce – свива списъка до една стойност
            //Взима списък и го редуцира до една стойност (сума, минимум, стринг, обект и т.н.).

            var sum = nums.Aggregate(0, (acc, x) => acc + x);
            Console.WriteLine(sum);


            //Функционален pipleline
            var result = nums
                .Where(x => x % 2 == 0)   // filter
                .Select(x => x * 2)       // map
                .Aggregate(0, (a, x) => a + x); // fold

            Console.WriteLine(string.Join(" ", result));


        }
    }
}
