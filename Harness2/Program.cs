using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;


namespace Harness2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("\nBegin WPF UIAutomation test run\n");
                Console.WriteLine("Launching CryptoCalc application");
                Process p = null;
                p = Process.Start("..\\..\\..\\CryptoCalc\\bin\\Debug\\CryptoCalc.exe");
                int ct = 0;
                do
                {
                    Console.WriteLine("Looking for CryptoCalc process. . . ");
                    ++ct;
                    Thread.Sleep(100);
                } while (p == null && ct < 50);
                if (p == null)
                    throw new Exception("Failed to find CryptoCalc process");
                else
                    Console.WriteLine("Found CryptoCalc process");

                // Next I fetch a reference to the host machine's Desktop as an
                // AutomationElement object:

                Console.WriteLine("\nGetting Desktop");
                AutomationElement aeDesktop = null;
                aeDesktop = AutomationElement.RootElement;
                if (aeDesktop == null)
                    throw new Exception("Unable to get Desktop");
                else
                    Console.WriteLine("Found Desktop\n");

                AutomationElement aeCryptoCalc = null;
                int numWaits = 0;
                do
                {
                    Console.WriteLine("Looking for CryptoCalc main window. . . ");
                    aeCryptoCalc = aeDesktop.FindFirst(TreeScope.Children,
                      new PropertyCondition(AutomationElement.NameProperty, "CryptoCalc"));
                    ++numWaits;
                    Thread.Sleep(200);
                } while (aeCryptoCalc == null && numWaits < 50);

                if (aeCryptoCalc == null)
                    throw new Exception("Failed to find CryptoCalc main window");
                else
                    Console.WriteLine("Found CryptoCalc main window");

                Console.WriteLine("\nGetting all user controls");
                AutomationElement aeButton = null;
                aeButton = aeCryptoCalc.FindFirst(TreeScope.Children,
                  new PropertyCondition(AutomationElement.NameProperty, "Compute"));
                if (aeButton == null)
                    throw new Exception("No compute button");
                else
                    Console.WriteLine("Got Compute button");
                

                AutomationElementCollection aeAllTextBoxes = null;
                aeAllTextBoxes = aeCryptoCalc.FindAll(TreeScope.Children,
                  new PropertyCondition(AutomationElement.ControlTypeProperty,
                  ControlType.Edit));
                if (aeAllTextBoxes == null)
                    throw new Exception("No textboxes collection");
                else
                    Console.WriteLine("Got textboxes collection");

                AutomationElement aeTextBox1 = null;
                AutomationElement aeTextBox2 = null;
                aeTextBox1 = aeAllTextBoxes[0];
                aeTextBox2 = aeAllTextBoxes[1];
                if (aeTextBox1 == null || aeTextBox2 == null)
                    throw new Exception("TextBox1 or TextBox2 not found");
                else
                    Console.WriteLine("Got TextBox1 and TextBox2");
                AutomationElement aeRadioButton3 = null;
                aeRadioButton3 = aeCryptoCalc.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty,
                   "DES Encrypt"));
                if (aeRadioButton3 == null)
                    throw new Exception("No RadioButton");
                else
                    Console.WriteLine("Got RadioButton3");

                Console.WriteLine("\nSetting input to 'Hello1!'");
                ValuePattern vpTextBox1 =
                  (ValuePattern)aeTextBox1.GetCurrentPattern(ValuePattern.Pattern);
                vpTextBox1.SetValue("Hello!");

                Console.WriteLine("Selecting 'DES Encrypt' ");
                SelectionItemPattern spSelectRadioButton3 =
                  (SelectionItemPattern)aeRadioButton3.GetCurrentPattern(
                    SelectionItemPattern.Pattern);
                spSelectRadioButton3.Select();

                Console.WriteLine("\nClicking on Compute button");
                InvokePattern ipClickButton1 =
                  (InvokePattern)aeButton.GetCurrentPattern(
                    InvokePattern.Pattern);
                ipClickButton1.Invoke();
                Thread.Sleep(1500);

                Console.WriteLine("\nChecking TextBox2 for '91-1E-84-41-67-4B-FF-8F'");
                TextPattern tpTextBox2 =
                  (TextPattern)aeTextBox2.GetCurrentPattern(TextPattern.Pattern);
                string result = tpTextBox2.DocumentRange.GetText(-1);

                if (result == "91-1E-84-41-67-4B-FF-8F")
                {
                    Console.WriteLine("Found it");
                    Console.WriteLine("\nTest scenario: Pass");
                }
                else
                {
                    Console.WriteLine("Did not find it");
                    Console.WriteLine("\nTest scenario: *FAIL*");
                }

                Console.WriteLine("\nClicking on File-Exit item in 5 seconds");
                Thread.Sleep(5000);
                AutomationElement aeFile = null;
                aeFile = aeCryptoCalc.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "File"));
                if (aeFile == null)
                    throw new Exception("Could not find File menu");
                else
                    Console.WriteLine("Got File menu");
                Console.WriteLine("Clicking on 'File'");
                ExpandCollapsePattern expClickFile =
                  (ExpandCollapsePattern)aeFile.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                expClickFile.Expand();

                AutomationElement aeFileExit = null;
                aeFileExit = aeCryptoCalc.FindFirst(TreeScope.Descendants,
                  new PropertyCondition(AutomationElement.NameProperty, "Exit"));
                if (aeFileExit == null)
                    throw new Exception("Could not find File-Exit");
                else
                    Console.WriteLine("Got File-Exit");

                InvokePattern ipFileExit = (InvokePattern)aeFileExit.GetCurrentPattern(InvokePattern.Pattern);
                ipFileExit.Invoke();
                Console.WriteLine("\nEnd automation\n");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal: " + ex.Message);
                Console.ReadKey();
            }
        }
    }
}
