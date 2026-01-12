namespace VAT
{
    internal class Program
    {
        // Вход: string – текст от потребител
        // Парсваме го до int
        // Превръщаме числото в double
        // Изчисляваме ДДС(20%)
        // Форматираме резултата като string
        static void Main(string[] args)
        {
            //string → int → double → decimal → string

            Func<string, int> ParseInt = s => int.Parse(s);

            Func<int, double> ToDouble =  i => (double)i;

            Func<double, double> AddVAT =   d => d * 1.20;

            Func<double, string> Format =  d => $"Цена с ДДС: {d:F2} лв.";

            //  ParseInt: string → int
            //  ToDouble : int → double
            //  AddVAT   : double → double
            //  Format   : double → string

            var step1 = Compose(ToDouble, ParseInt);
            // step1 : string → double
            var step2 = Compose(AddVAT, step1);
            // step2 : string → double
            var final = Compose(Format, step2);
            // final : string → string
            Console.WriteLine(final("100"));

            // Това описва цялата верига наведнъж, без междинни стъпки.
            var finalPipeLine =  Compose( Format, Compose(AddVAT, Compose(ToDouble,ParseInt)));
            Console.WriteLine(finalPipeLine("100"));

        }

        // При функционалната композиция могат да се комбинират функции с различни входни и изходни типове.
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
