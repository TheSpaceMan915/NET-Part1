using Lab8;

Func<double, double> function = x => Math.Sin(x);
int n0 = 1, n1 = 0;
double start = 0, end = 7, middle = (end-start)/2;
double eps = 0.0005, error = Double.MaxValue;

int counter = 0;
while (eps<error & counter!=15)
{
    // initialising n on the two intervals
    counter++;
    n0 *= 2;
    n1 = n0 * 2;

    // setting up threads
    ThreadJob job1 = new ThreadJob(start, middle, n0, function);
    ThreadJob job2 = new ThreadJob(middle, end, n1, function);
    Thread thread1 = new Thread(new ThreadStart(job1.calculateSum));
    Thread thread2 = new Thread(new ThreadStart(job2.calculateSum));
    thread1.Start();
    thread2.Start();
    thread1.Join();
    thread2.Join();

    // getting sums on the intervals from the list
    var list1 = job1.getListSums();
    var list2 = job2.getListSums();
    double sum1 = list1.Sum();
    double sum2 = list2.Sum();
    error = Math.Abs(sum2 - sum1);
   
    double res = sum1 + sum2;
    Console.WriteLine("{0}. n0: {1}, n1: {2}, error: {3}, res: {4}", counter, n0, n1, error, res);

    // cleaning the lists containing sums
    list1.Clear();
    list2.Clear();
}

Console.WriteLine("The job's done");