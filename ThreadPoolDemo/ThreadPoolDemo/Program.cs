using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback item = new WaitCallback(ShowMyText);
            ShowMyText("Single Thread");
            ThreadPool.QueueUserWorkItem(item, "Thread 1");
            ThreadPool.QueueUserWorkItem(item, "Thread 2");
            ThreadPool.QueueUserWorkItem(item, "Thread 3");
            ThreadPool.QueueUserWorkItem(item, "Thread 4");
            ThreadPool.QueueUserWorkItem(item, "Thread 5");
            Console.ReadKey();
        }

        static void ShowMyText(object state)
        {
            string stateDetails = state.ToString();
            string text = $"Thread name: {stateDetails}, Thread ID: {Thread.CurrentThread.ManagedThreadId}";
            Console.WriteLine($"{stateDetails} is loading...");
            Thread.Sleep(5000);
            Console.WriteLine(text);
        }
    }
}
