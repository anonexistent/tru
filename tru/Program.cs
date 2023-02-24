namespace tru
{
    internal class Program
    {

        /*
         На лекции в университете профессор уронил пластиковую хрупкую указку. 
        Она ударилась об пол и раскололась на три части. Жаль конечно, но профессор 
        не растерялся и задал вопрос сколько в среднем потребовалось бы сломать указок, 
        чтобы из кусков от одной получился треугольник?

            1)Обычный 
            2)Прямоугольный
            3)Равнобедренный
         */

        static decimal a = 0, b = 0, c = 0, r = 0, t = 1;

        static void Print(object a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(a.ToString());
            Console.ResetColor();
        }

        public static bool Work(decimal a, decimal b, decimal c, int sizeTr)
        {
            a = uuu.Next(1, sizeTr);
            b = uuu.Next(1, sizeTr);
            c = uuu.Next(1, sizeTr);

            /*Треугольник существует только тогда, когда сумма любых двух его сторон больше третьей.
              Требуется сравнить каждую сторону с суммой двух других.
              Если хотя бы в одном случае сторона окажется больше или равна сумме двух других,
              то треугольника с такими сторонами не существует.*/

            return ((a + b) > c & (a + c) > b & (c + b) > a);   
        }

        public static bool PythagorasIsSleeping(decimal a, decimal b, decimal c)
        {
            return Math.Pow((double)a, 2) == (Math.Pow((double)b,2) + Math.Pow((double)c,2)) ? true : 
                (Math.Pow((double)b, 2) == (Math.Pow((double)a,2)+Math.Pow((double)c,2)) ? true : 
                Math.Pow((double)c, 2) == (Math.Pow((double)b, 2) + Math.Pow((double)a, 2)) ? true : false);
        }
        public static bool IsIsosceles(decimal a, decimal b, decimal c) => a == b ? true : (a == c ? true : (b == c ? true : false));

        public static Random uuu;

        static void Main(string[] args)
        {
            uuu = new Random();
            int countEx = 100;
            int countTr = 2_000_000;
            int maxTrSize = 10;

            
            List<decimal> o = new List<decimal>();
            double countPythagoras = 0.0f;
            double countIsos = 0.0f;

            //for (int i = 0; i < 2000; i++)
            //{
            //    Thread x = new Thread(() => Work(a, b, c));
            //    x.Start();
            //    Thread y = new Thread(() => { if (Work(a, b, c)) r++; });
            //    y.Start();
            //}

            for (int j = 0; j < countEx; j++)
            {
                for (int i = 0; i < countTr; i++)
                {
                    bool temp = Work(a, b, c, maxTrSize);
                    if (temp) r++;
                    if (PythagorasIsSleeping(a, b, c)) countPythagoras += 0.0001f;
                    if (IsIsosceles(a, b, c)) countIsos += 0.0001f;
                }
                o.Add(r / countTr);
                Console.WriteLine($"{j}\t" + $"{o[j]:f10}");
                r *= 0;
            }

            Print($"\n\n\n\n\nпри заданных параметрах:\n\tкол-во треугольников в испытании:\t{countTr}\n\tкол-во испытаний: \t{countEx}\nmin вероятность существования треугольника:\t{o.Where(x => x > 0).Min()}\t ");
            Print($"\n\t\tиз них прямоугольных:\t{countPythagoras*10000:f0};\n\t\tравнобедренных:\t{countIsos*10000:f0};\n\t\tобычных:\t~ {countEx*countTr*o.First():f0}.");

            //Console.WriteLine(PythagorasIsSleeping(decimal.Parse(Console.ReadLine()), decimal.Parse(Console.ReadLine()), decimal.Parse(Console.ReadLine())).ToString());
        }
    }
}