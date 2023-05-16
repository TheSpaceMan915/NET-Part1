namespace Test {

    class ProgramDriver
    {
        static string Reverse(string text)
        {
            char[] cArray = text.ToCharArray();
            string reverse = String.Empty;
            for (int i = cArray.Length - 1; i > -1; i--)
            {
                reverse += cArray[i];
            }
            return reverse;
        }
        static double getIntervalLength(double a, double b, int intervalsCount)
        {
            return (b - a) / intervalsCount;
        }

        //Базовая стратегия распараллеливания вычислений выглядит следующим образом:
        //Создание потоков X (тем больше,чем больше ядер в процессоре)
        //Каждый поток будет работать над диапазоном в массиве и суммировать значения
        //Добавление к одной и той же переменной не будет работать из нескольких потоков,
        //Понадобится механизм блокировки, иначе мы получим неверный результат.
        //Нужно использовать переменную localThread,
        //Чтобы сохранить значение iThread в этот момент времени.
        //Иначе это будет захваченная переменная, которая изменяется по мере продвижения цикла for.
        public static double ThreadPoolWithLock(double[] f, int n)
        {
            object locker = new object();//объект заглушка
            double total = 0;
            int threads = 8;
            var partSize = n / threads;
            Task[] tasks = new Task[threads];
            for (int iThread = 0; iThread < threads; iThread++)
            {
                var localThread = iThread;
                //ставим в очередь все что внутри для запуска в пуле потоков
                tasks[localThread] = Task.Run(() =>
                {
                    for (int j = localThread * partSize; j < (localThread + 1) * partSize; j++)
                    {
                        // внутри весь код блокируется и становится недоступным
                        // для других потоков до завершения работы текущего потока
                        lock (locker) // объект locker блокируется
                        {
                            total += f[j];
                        }
                    }
                });
            }

            Task.WaitAll(tasks);//ждем пока потоки завершат свою работу
            return total;
        }
        public static double Rectangle(double[] f, int a, int b)
        {
            int n = f.Length - 1;
            double Integral = 0;
            double h = getIntervalLength(a, b, n);
            Integral = ThreadPoolWithLock(f, n);
            return Integral * h;
        }

        public static void Main(string[] args)
        {
            int a = 0;
            int b = 7;

            int n = 10;

            double length = getIntervalLength(a, b, n);
            double[] f = new double[n + 1];

            double leftX = a;



            for (int k = 0; k <= n; k++, leftX += length)
            {
                Console.WriteLine("{1,20:f15}{0,10:f4}", leftX, leftX);
                Console.WriteLine("------------------------------");
                f[k] = Math.Sin(leftX);
            }
            Console.WriteLine(Rectangle(f, a, b));
            double result = 0;
            Console.WriteLine("Проверка: " + result);
            Console.WriteLine("Разница: " + Math.Abs(result - Rectangle(f, a, b)));
        }
    }

 }