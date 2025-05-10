namespace CalculatorLibrary;

using Newtonsoft.Json;

public class Calculator
{
    JsonWriter writer;

    public Calculator()
    {
        StreamWriter logFile = new StreamWriter("CalculatorLog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();

    }

    public void Finish()
    {
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
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
                writer.WriteValue("Add");
                break;
            case "s":
                result = firstValue - secondValue;
                writer.WriteValue("Subtract");
                break;
            case "m":
                result = firstValue * secondValue;
                writer.WriteValue("Multiply");
                break;
            case "d":
                if (secondValue != 0)
                {
                    result = firstValue / secondValue;
                    writer.WriteValue("Divide");
                }
                break;
            default:
                break;
        }
        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        writer.WriteEndObject();

        return result;
    }
}
