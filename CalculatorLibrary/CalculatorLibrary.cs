namespace CalculatorLibrary;
using System.Diagnostics;
using Newtonsoft.Json;

public class Calculator
{
    JsonWriter writer;

    public Calculator()
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
    }

    public double DoOperation(double firstValue, double secondValue, string op)
    {
        double result = double.NaN;
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(firstValue);
        writer.WritePropertyName("Operand2");
        writer.WriteValue(secondValue);
        writer.WritePropertyName("Operation");
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
