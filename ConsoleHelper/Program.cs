using SKKConsoleNS.SKKConsolePageConfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHelper
{
    public class Program
    {
        static void Main(string[] args)
        {
            ConsolePageConfigCollection coll1 = new ConsolePageConfigCollection();
            for (int i = 0; i < 50; i++) coll1.Add(new ConsolePageConfig($"Config{i}",Color.FromArgb(100+i, 100+i*2,100+i*3), new Font("Comic Sans MS", 12f)));

            string collString = TypeDescriptor.GetConverter(typeof(ConsolePageConfigCollection)).ConvertToInvariantString(coll1);
            Console.Write(collString);

            ConsolePageConfigCollection coll2 = TypeDescriptor.GetConverter(typeof(ConsolePageConfigCollection)).ConvertFromInvariantString(collString) as ConsolePageConfigCollection;
            foreach (ConsolePageConfig c in coll2) Console.WriteLine(c.ToString());

            ConsolePageConfig cpc = (ConsolePageConfig)TypeDescriptor.GetConverter(typeof(ConsolePageConfig)).ConvertFromInvariantString("");// as ConsolePageConfig;
            ConsolePageConfigCollection coll3 = TypeDescriptor.GetConverter(typeof(ConsolePageConfigCollection)).ConvertFromInvariantString("") as ConsolePageConfigCollection;
            

            Console.ReadLine();
        }
    }
}
