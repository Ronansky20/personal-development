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
                Trace.WriteLine(String.Format("{0} + {1} = {2}"));
                break;
            case "s":
                result = firstValue - secondValue;
                Trace.WriteLine(String.Format("{0} - {1} = {2}"));
                break;
            case "m":
                result = firstValue * secondValue;
                Trace.WriteLine(String.Format("{0} * {1} = {2}"));
                break;
            case "d":
                if (secondValue != 0)
                {
                    result = firstValue / secondValue;
                    Trace.WriteLine(String.Format("{0} / {1} = {2}"));
                }
                break;
            default:
                break;
        }
        return result;
    }
}
