using System.Numerics;

namespace ComposeFunc
{
    // MET = интензивност на активност
    // weight = тегло в килограми
    // time = време в минути
    // резултат = калории(kcal)

    //  Активност               MET
    //  Покой	                1
    //  Бавно ходене	        3
    //  Бягане(8 km/h)          8
    //  Бягане(12 km/h)         12.5
    //  Колоездене(скоростно)   10
    internal class Program
    {     
        // Императивна реализация на формулата за калории
        // Използва междинни променливи (step1, step2)
        // Това е последователно изчисление, НЕ функционален стил
        static double CalculateCalories(double met, double kg, double time)
        {
            double step1 = met * kg;
            double step2 = step1 * time;
            double result = step2 / 200;
            return result;  
        }
        static void Main(string[] args)
        {
            // Примерни входни данни:
             double met = 8;
             double kg = 70;
             double time = 30;

            // Дефиниране на функции като стойности (first-class functions) - делегати
            // Всяка функция приема едно число и връща едно число
            // Използват се ламбда-изрази
            Func<double, double> MultyTime = t => t * kg;
            Func<double, double> MultyMet = w => w * met;
            Func<double, double> Div200 = x => x / 200;

            // Композитна функция:
            // резултат = MultyTime ∘ ( MultyMet ∘ Div200 )
            // Изходът на една функция е вход за следващата
            Console.WriteLine("=== Композитна функция с именувани функции ===");
            var calories = Compose(MultyTime, Compose(MultyMet, Div200));
            Console.WriteLine(calories(12.5));

            Console.WriteLine("\n=== Композиция с анонимни функции ===");
            // Извикване на Compose с анонимни функции
            var caloriesAnonymous = Compose(
                x => x / 200,
                // Тук е нужно да се уточни, какви данни се приемат и какво се връща
                Compose<double, double, double>( 
                    x => x * time,
                    x => x * kg)
                );
            Console.WriteLine(caloriesAnonymous(8));

            // Карирана функция (curried function) - може да се контролират входните данни
            // Вместо функция с 3 аргумента → верига от функции с по 1 аргумент
            // Тип: double → double → double → double
            Console.WriteLine("\n=== Карирана функция ===");
            Func<double, Func<double, Func<double, double>>> Calories =
                   met => kg => time =>
                   (met * kg * time) / 200;
            Console.WriteLine(Calories(8)(70)(30));

            // Частично прилагане на карирана функция
            // Всяка стъпка връща нова функция
            Console.WriteLine("\n=== Частично прилагане ===");
            var first = Calories(8);
            var second = first(70);
            Console.WriteLine(second(30));

            // Карирана функция, която използва композитни функции
            // Вътрешно се изгражда pipeline от функции:  x → x * kg → x * time → x / 200         
            // Compose създава нова функция без междинни стойности
            Console.WriteLine("\n=== Кариране + композиция ===");
            Func<double, Func<double, Func<double, double>>> CaloriesCompose =
                met => kg => time =>
                Compose(
                    x => x / 200,
                    Compose<double,double,double>
                    (
                        x => x * time,
                        x => x * kg
                    )
                    )(met);

            Console.WriteLine(CaloriesCompose(10)(70)(25));
        
        }
        // Генерична функция за композиция
        // (f ∘ g)(x) = f(g(x))
        //
        // g : T3 → T1
        // f : T1 → T2
        // резултат : T3 → T2
        static Func<T3, T2> Compose<T1, T2, T3> 
            (
            Func<T1, T2> f,
            Func<T3, T1> g
            )
        {
           return x => f(g(x));
        }

        
    }
}
