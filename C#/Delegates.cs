namespace Example
{
    internal class Program
    {
        static int Function(int x)
        {
            return x * 2;
        }
        static void Main(string[] args)
        {
            //======================================
            //Func<TInput, TOutput>
            //======================================

            //1. Умножение на число
            Func<int, int> f = x => x * 2;
            Console.WriteLine(f(2));
            Console.WriteLine(Function(3));

            //2. Пресмятане на площ на кръг
            Func<double,double> cicleArea = r => Math.PI* r*r;
            Console.WriteLine(cicleArea(3));

            //3. Връщане на дължина на стринг
            Func<string, int> length = str => str.Length;
            Console.WriteLine(length("Hello"));

            //4. От string -> int
            Func<string, int> toInt = text => int.Parse(text);
            Console.WriteLine(toInt("123"));

            //5. Композитна функция
            Func<int, int> square = x => x * x;
            Func<int, int> add5 = x => x + 5;

            Func<int, int> composed = x => add5(square(x));
            Console.WriteLine(composed(3));

            //6.Декларирай Func<int> който връща числото 42.
            Func<int> func42 = () => 42;
            Console.WriteLine(func42());

            //7. Направи Func<string> който връща текущата дата като текст.
            Func<string> today = () => DateTime.Now.ToString();
            Console.WriteLine(today());

            //8. Създай Func<int, int> – върни квадрата на числото
            Func<int, int> square = x => x * x;

            //9. Func<string, int> – върни броя на символите в текста
            Func<string, int> charCount = s => s.Length;
            Console.WriteLine(charCount("Hello"));

            //10. Func<double, double> – преобразувай °C → °F
            Func<double, double> cToF = c => (c * 9 / 5) + 32;
            Console.WriteLine(cToF(0));
            Console.WriteLine(cToF(25));

            //======================================
            //          Predicate<T>
            //======================================

            //1. Проверка дали число е четно
            Predicate<int> isEven = x => x % 2 == 0;
            Console.WriteLine(isEven(3));

            //2. Проверка дали текстът е празен
            Predicate<string> isEmpty = s => string.IsNullOrWhiteSpace(s);
            Console.WriteLine(isEmpty(" "));

            //3.Проверка дали човек е пълнолетен
            Predicate<int> isAdult = age => age >= 18;
            Console.WriteLine(isAdult(20)); // True

            //4. Филтриране на списък
            Predicate<int> greaterThan10 = x => x > 10;
            var nums = new List<int> { 5, 12, 3, 40 };

            var filtered = nums.FindAll(greaterThan10);
            Console.WriteLine(string.Join(", ", filtered));

            //5. Проверка дали дадена дума съдържа буква
            Predicate<string> containsA = s => s.Contains('a');
            Console.WriteLine(containsA("cat")); // True

            //======================================
            // Action<T>
            //======================================

            //1. Принтиране на число
            Action<int> print = x => Console.WriteLine($"Value: {x}");
            print(10);

            //2. Логване на текст
            Action<string> log = msg =>
            {
                Console.WriteLine($"[LOG] {DateTime.Now}: {msg}");
            };
            log("Application started.");

            //3. Добавяне на елемент към списък (страничен ефект)
            var list = new List<int>();
            Action<int> addToList = x => list.Add(x);

            addToList(5);
            addToList(10);

            Console.WriteLine(string.Join(", ", list));

            //4. Увеличаване на външна променлива
            int counter = 0;
            Action inc = () => counter++;
            inc();
            inc();
            Console.WriteLine(counter);

            // 5. Мулти-Action (делегат с няколко функции)
            Action<string> hello = name => Console.WriteLine("Hello " + name);
            Action<string> bye = name => Console.WriteLine("Goodbye " + name);

            Action<string> both = hello + bye;
            both("Ivan");
        }
    }
}
