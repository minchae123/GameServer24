using System;
using System.Threading;

namespace ThreadExample
{
	internal class Program
	{
		static void Main(string[] arg)
		{
			string srcFile = arg[0];

			Action<object>
		}

		/*static void Main(string[] args)
		{
			Counter counter = new Counter();

			Thread incThread = new Thread(new ThreadStart(counter.Increment));
			Thread decThread = new Thread(new ThreadStart(counter.Decrement));

			incThread.Start();
			decThread.Start();

			incThread.Join();
			decThread.Join();

			Console.WriteLine(counter.Count);
		}

		class Counter
		{
			const int LOOP_COUNT = 100;
			readonly object thisLock;

			private int count;
			public int Count { get { return count; } }

			public Counter()
			{
				thisLock = new object();
				count = 0;
			}

			public void Increment()
			{
				int loopCount = LOOP_COUNT;
				while (loopCount-- > 0)
				{
					*//*lock(thisLock)
					{
						count++;
					}
					Thread.Sleep(1);*//*

					Monitor.Enter(thisLock);
					try
					{
						count++;
					}
					finally
					{
						Monitor.Exit(thisLock);
					}
					Thread.Sleep(1);
				}
			}

			public void Decrement()
			{
				int loopCount = LOOP_COUNT;
				while (loopCount-- > 0)
				{
					*//*lock(thisLock)
					{
						count--;
					}
					Thread.Sleep(1);*//*
					Monitor.Enter(thisLock);
					try
					{
						count--;
					}
					finally
					{
						Monitor.Exit(thisLock);
					}
					Thread.Sleep(1);
				}
			}

			static void Func1()
			{
				for (int i = 0; i < 10; i++)
				{
					Console.WriteLine("스레드 1 {0}", i);
					Thread.Sleep(10);
				}
			}

			static void Func2()
			{
				for (int i = 0; i < 10; i++)
				{
					Console.WriteLine("스레드 2 {0}", i);
					Thread.Sleep(10);
				}
			}

			static void Run()
			{
				Console.WriteLine("Run");
			}
		}*/
	}
}