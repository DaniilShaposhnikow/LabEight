using System;
using System.Diagnostics;
using System.Threading;
using System.Automation;

namespace Harness
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nBegin WPF UIAutomation test run\n");
                // launch CryptoCalc application
                // get reference to main Window control
                // get references to user controls
                // manipulate application
                // check resulting state and determine pass/fail
                Console.WriteLine("\nEnd automation\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal: " + ex.Message);
            }
        }
    }
}
