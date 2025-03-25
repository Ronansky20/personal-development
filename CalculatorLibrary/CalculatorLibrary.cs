namespace CalculatorLibrary;

using System.Diagnostics;

public class Calculator
{
    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculator.log");
        Trace.Listeners.Add(new TextWriterTraceListener(logFile));
        Trace.AutoFlush = true;
        Trace.WriteLine("Starting Calc log");
        Trace.WriteLine(String.Format("Started {0}", System.DateTime.Now.ToString()));
    }

    public static double DoOperation(double firstValue, double secondValue, string op)
    {
        double result = double.NaN;
        switch (op)
        {
            case "a":
                result = firstValue + secondValue;
                break;
            case "s":
                result = firstValue - secondValue;
                break;
            case "m":
                result = firstValue * secondValue;
                break;
            case "d":
                if (secondValue != 0)
                {
                    result = firstValue / secondValue;
                }
                break;
            default:
                break;
        }
        return result;
    }
}
