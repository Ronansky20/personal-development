namespace CalculatorLibrary;

public class Calculator
{
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
