using System;
using System.Data;
using System.Globalization;

class Calculator
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Enter an expression (e.g., 10000/10+90*10+5*14) or 'q' to quit:");
            string? input = Console.ReadLine();

            if (input?.ToLower() == "q")
                break;

            try
            {
                if (input != null)
                {
                    double result = EvaluateExpression(input);
                    Console.WriteLine("Result: " + result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine();
        }
    }

    static double EvaluateExpression(string expression)
    {
        DataTable dataTable = new DataTable();
        var expressionValue = dataTable.Compute(expression, "");

        if (expressionValue != null)
        {
            string expressionString = expressionValue.ToString()!;
            if (double.TryParse(expressionString, NumberStyles.Float, CultureInfo.InvariantCulture, out double result))
            {
                return result;
            }
        }

        throw new ArgumentException("Invalid expression: " + expression);
    }
}
