using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();

            sw.Start();
            //MathProxy proxy = new MathProxy();
            Math proxy = new Math();
            Console.WriteLine(proxy.Add(5,6));
            Console.WriteLine(proxy.Sub(11,3));
            Console.WriteLine(proxy.Mul(8,9));
            Console.WriteLine(proxy.Div(44369, 16016));
            sw.Stop();
            Console.WriteLine("Elapsed={0}", sw.Elapsed);
            Console.ReadKey();
        }
    }

    public interface IMath
    {
        double Add(double x, double y);
        double Sub(double x, double y);
        double Div(double x, double y);
        double Mul(double x, double y);
    }

    class Math : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Div(double x, double y)
        {
            return x / y;
        }

        public double Mul(double x, double y)
        {
            return x * y;
        }

        public double Sub(double x, double y)
        {
            return x - y;
        }
    }

    class MathProxy : IMath
    {
        private Math _math = new Math();
        public double Add(double x, double y)
        {
            return _math.Add(x,y);
        }

        public double Div(double x, double y)
        {
            return _math.Div(x, y);
        }

        public double Mul(double x, double y)
        {
           return _math.Mul(x, y);
        }

        public double Sub(double x, double y)
        {
            return _math.Sub(x, y);
        }
    }
}
