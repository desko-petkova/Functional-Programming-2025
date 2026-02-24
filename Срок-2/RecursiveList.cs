namespace ExampelRecursiv
{
    internal class Program
    {
        //1. Рекурсивно намиране на минимален елемент
        static int Min(List<int> list, int currentMin)
        {
            if(list.Count == 0) { return currentMin; }
           // int newMin = list[0] < currentMin ? list[0] : currentMin;
            int newMin;
            if (list[0] < currentMin) { newMin = list[0]; }
            else newMin = currentMin;

                return Min(list.Skip(1).ToList(), newMin);
            
        }

        //2. Рекурсивно филтриране (четни числа)
        static List<int> Evens(List<int> list)
        {
           if(list.Count == 0) { return new List<int>(); }

           var head = list[0];
           var tail = Evens(list.Skip(1).ToList());

            if(head % 2 == 0)
            {
                return new List<int>() { head}.Concat(tail).ToList();
            }
            return tail;
        }

        //3. Рекурсивно обръщане на списък
        static List<T> Reverse<T>(List<T> list)
        {
            if (list.Count == 0)
                return new List<T>();

            return Reverse(list.Skip(1).ToList())
                   .Concat(new List<T> { list[0] })
                   .ToList();

        }
        //4. Рекурсивно създаване на списък от 1 до N
        static List<int> InitList(int n)
        {
            if (n == 0)
                return new List<int>();

            return InitList(n - 1)
                   .Concat(new List<int> { n })
                   .ToList();
        }
        //5. Рекурсивна инициализация със стойност (N пъти еднакъв елемент)
        static List<T> InitList<T>(int n, T value)
        {
            if (n == 0)
                return new List<T>();

            return new List<T> { value }
                   .Concat(InitList(n - 1, value))
                   .ToList();
        }
        //6. Рекурсивна инициализация чрез функция (много важно за ФП)
        static List<T> InitList<T>(int n, Func<int, T> f)
        {
            if (n == 0)
                return new List<T>();

            return InitList(n - 1, f)
                   .Concat(new List<T> { f(n) })
                   .ToList();
        }
        //7. Опашкова рекурсия за инициализация чрез функция
        static List<T> InitTail<T>(int n, Func<int, T> f, List<T> acc)
        {
            if (n == 0)
                return acc;

            return InitTail(
                n - 1,
                f,
                new List<T> { f(n) }.Concat(acc).ToList()
            );
        }
        //8. Рекурсивно четене на N елемента от вход
        static List<int> ReadList(int n)
        {
            if (n == 0)
                return new List<int>();

            int x = int.Parse(Console.ReadLine());

            return new List<int> { x }
                   .Concat(ReadList(n - 1))
                   .ToList();
        }

        static void Main(string[] args)
        {
            //1.
            List<int> list = new List<int>() { 3, 4, 5, 6, 7, 8, 9, -1, -4, 33 };
            //Console.WriteLine(Min(list, int.MaxValue));

            ////2.
            var evens = Evens(list);
            Console.WriteLine(string.Join(" ", evens));

            ////3.
            //var revers = Reverse(list);
            //Console.WriteLine(string.Join(" ", revers));

            ////4.
            //var initList = InitList(10);
            //Console.WriteLine(string.Join(" ", initList));

            ////5.
            //var sameElementList = InitList(15, 'A');
            //Console.WriteLine(string.Join(" ", sameElementList));

            ////6. 
            //var initListFunc = InitList(5, x => x * x);
            //var initListFunc2 = InitList(5, x => x*Math.PI);
            //Console.WriteLine(string.Join(" ", initListFunc2));

            ////7.
            //var tailList = InitTail(5, x => x, new List<int>());
            //Console.WriteLine(string.Join(" ", tailList));

            //8. 
            //int n = int.Parse(Console.ReadLine());
            //List<int> initRecurtion = ReadList(n);

            //Console.WriteLine(string.Join(" ",initRecurtion));
        }

    }
}
