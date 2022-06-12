

using System.Diagnostics;

class Program
{
    public static void Main()
    {
        Console.WriteLine("main thread " + Thread.CurrentThread.ManagedThreadId);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Thread t1 = new Thread(method1);
        t1.Start();
        Thread t2 = new Thread(method2);
        t2.Start();
        t1.Join();
        t2.Join();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds / 1000);

        //Stopwatch sw = new Stopwatch();
        //sw.Start();
        //method1();
        //method2();
        //sw.Stop();
        //Console.WriteLine(sw.ElapsedMilliseconds/1000);
    }

    public static void method1()
    {
        Console.WriteLine("method1 thread " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("method1 starting");
        Thread.Sleep(3000);
        Console.WriteLine("method1 ending");
    }

    public static void method2()
    {
        Console.WriteLine("method2 thread " + Thread.CurrentThread.ManagedThreadId);
        Console.WriteLine("method2 starting");
        Thread.Sleep(2000);
        Console.WriteLine("method2 ending");
    }
}