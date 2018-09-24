using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace demoClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new demoServiceReference.demoServiceSoapClient();
            int n = 20;
            foreach (int f in client.GetFibonacciSequence(n))
                Console.WriteLine(f);
            Console.ReadLine();
        }
    }
}
