using System;
using System.Collections.Concurrent;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Baekjoon
{
    class Program
    {
        static ConcurrentStack<int> stack = new ConcurrentStack<int>();
        static void Main(string[] args)
        {
            Console.WriteLine("1~10,000 까지의 명령 횟수를 입력해주세요");
            string orderCount = NewMethod();
            int intOrder = Int32.Parse(orderCount);

            while (intOrder != 0)
            {
                Console.WriteLine("명령을 하나씩 입력 후 엔터를 눌러주세요");
                var Order = Console.ReadLine();

                switch (Order)
                {
                    case "pop":
                        Task a = Pop();
                        break;
                    case "size":
                        Task b = Size();
                        break;
                    case "empty":
                        Task c = Empty();
                        break;
                    case "top":
                        Task d = Top();
                        break;
                    default:
                        string intString = Regex.Replace(Order, @"\D", "");
                        Task e = Push(Int32.Parse(intString));
                        break;
                }

                intOrder--;
            }
        }

        private static string NewMethod()
        {
            return Console.ReadLine();
        }

        public static async Task Push(int a)
        {
            await Task.Factory.StartNew(() => {
                stack.Push(a);
                Thread.Sleep(100);
            });
        }
        public static async Task Pop()
        {
            await Task.Factory.StartNew(() => {
                int result;
                if (stack.TryPop(out result))
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("-1");
                }
                Thread.Sleep(100);
            });
        }
        public static async Task Size()
        {
            await Task.Factory.StartNew(() => {
                Console.WriteLine(stack.Count);
            });
            Thread.Sleep(100);
        }
        public static async Task Empty()
        {
            await Task.Factory.StartNew(() => {
                if (stack.Count == 0)
                {
                    Console.WriteLine("1");
                }
                else
                {
                    Console.WriteLine("0");
                }
                Thread.Sleep(100);
            });
        }
        public static async Task Top()
        {
            await Task.Factory.StartNew(() => {
                int result;
                if (stack.TryPeek(out result))
                {
                    Console.WriteLine(result);
                }
                else
                {
                    Console.WriteLine("-1");
                }
                Thread.Sleep(100);
            });
        }
    }
}
