using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2
{
    //public interface IEnumerator
    //{
    //    bool MoveNext();
    //    object Current { get; }
    //}
    //class Countdown : IEnumerator
    //{
    //    private int _count = 11;
    //    public bool MoveNext() => _count-- > 0; // Здесь count-- и сравнение получившегося значения с 0 
    //    public   void   Reset () => _count =  0 ; 
    //    public object Current => _count;
    //}
    //class Program
    //{
    //    static void Main(string[] args)
    //    {

    //        IEnumerator e = new Countdown();
    //        while (e.MoveNext())
    //        {

    //            Console.WriteLine (e.Current);

    //        }
    //        Console.ReadLine();
    //    }
    //}

    //internal interface IExportLocally
    //{ 

    //        void Export();
    //    }
    //internal interface IExportToServer
    //    {
    //        void Export();
    //    }
    //internal class ExportWord : IExportLocally, IExportToServer
    //    {
    //    public void Export()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //internal class Program
    //{
    //    public static void Main()
    //    {
    //        IExportLocally export = new ExportWord();
    //        IExportToServer export2 = new ExportWord();
    //        export.Export();
    //        export2.Export();
    //    }
    //}
    abstract class TableFun
    {
        public abstract double F(double x);
        public void Table(double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x));
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
    }
    class SimpleFun : TableFun { public override double F(double x)
        {
            return x * x;
        }
    }
    class SinFun : TableFun { public override double F(double x)
        {
            return Math.Sin(x);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TableFun a = new SinFun();
            Console.WriteLine("Таблица функции Sin:");
            a.Table(-2, 2);
            a = new SimpleFun();
            Console.WriteLine("Таблица функции Simple:");
            a.Table(0, 3);
            Console.ReadLine();
        }
    }
}
