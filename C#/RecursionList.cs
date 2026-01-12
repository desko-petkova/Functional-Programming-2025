namespace RecursionList
{
    //Функционален подход означава:
    // - рекурсия вместо цикли
    // - функции като аргументи(Func<>)
    // - без странични ефекти
    // - чисти функции
    internal class Program
    {
        //1. Рекурсивно извеждане на елементи на списък
        static void PrintList<T>(List<T> list)
        {
            if(list.Count == 0) return;

            Console.WriteLine(list[0]); // страничен ефект

            PrintList(list.Skip(1).ToList());
        }

        //2. Рекурсивно извеждане на елементи без страничен ефект
        static string ListToString<T>(List<T> list)
        {
            if (list.Count == 0) return "";

            return list[0] + " " + ListToString(list.Skip(1).ToList());
        }
        //3. Рекурсивно умножение на всички елементи по 2
        static List<int> MultiplyByTwo(List<int> list)
        {
            if (list.Count == 0) return new List<int>();

            int head = list[0] * 2;
            List<int> tail = MultiplyByTwo(list.Skip(1).ToList());

            return new List<int> { head }.Concat(tail).ToList();

        }
      
        //4. Брой елементи 
        static int Count<T>(List<T> list)
        {
            if( list.Count == 0) return 0;

            int count = 1 + Count(list.Skip(1).ToList());
            return count;
        }
        // Опашкова рекурсия - брой елементи
        static int Count<T>(List<T> list, int count)
        {
            if (list.Count == 0) return count;

            return Count(list.Skip(1).ToList(), count + 1);
        }
        //5. Рекурсивно сумиране на елементи от списък
        static int Sum(List<int> list)
        {
            if (list.Count == 0) return 0;
            return list[0] + Sum(list.Skip(1).ToList());
        }
        static void Main(string[] args)
        {
            var numbers = new List<int> { 1, 2, 3 };
            //1. Извикване на PrintList
            PrintList(numbers);

            //2. Рекурсивно извеждане на елементи без страничен случай
            string result = ListToString(numbers);
            Console.WriteLine(result);

            //3. Рекурсивно умножение на всички елементи по 2
            var output = MultiplyByTwo(numbers);
            Console.WriteLine(string.Join(", ", output));

            //4. Брой елементи  
            Console.WriteLine(Count(numbers));
            Console.WriteLine(Count(numbers, 0)); // Опашкова рекурсия - брой елементи

            //5. Рекурсивно сумиране на елементи от списък
            Console.WriteLine(Sum(numbers));
           

            
           

            


        }


    }
}
