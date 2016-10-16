using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;

class Calculator
{
    /** Scanner to get input from the user from the command line. */
    //private Scanner scin = new Scanner( System.in );

    static void Main(string[] args)
    {
        // Instantiate a "Main" object so we don't have to make everything static
        Calculator app = new Calculator();
        bool playAgain = true;
        Console.WriteLine("\nPostfix Calculator. Recognizes these operators: + - * /");

        while (playAgain)
        {
            playAgain = app.doCalculation();
        }
        Console.WriteLine("Bye.");
    }

    /**
    *  Get input string from user and perform calculation, returning true when
    *  finished. If the user wishes to quit this method returns false.
    *
    *@return    true if a calculation succeeded, false if the user wishes to quit
    */
    private bool doCalculation()
    {
        Console.WriteLine("Please enter q to quit\n");
        String input = "2 2 +";
        Console.WriteLine("> ");         // prompt user

        input = Console.ReadLine();
        // looks like nextLine() blocks for input when used on an InputStream (System.in).  Docs don't say that!

        // See if the user wishes to quit
        if ( input.StartsWith( "q" ) || input.StartsWith( "Q" ) )
        {
            return false;
        }

        // Go ahead with calculation
        String output = "4";
        output = EvaluatePostFixInput( input );

        Console.WriteLine("\n\t>>> " + input + " = " + output);

        return true;
    }

    /**
     *  Evaluate an arithmetic expression written in postfix form.
     *
     *@param  input                         Postfix mathematical expression as a String
     *@return                               Answer as a String
     *@exception  IllegalArgumentException  Something went wrong
     */
    public string EvaluatePostFixInput(string input)
    {
        StackADT stack = new LinkedStack();

        if (input == null || input.Equals("") )
        {
            return ("Null or the empty string are not valid postfix expressions.");
        }
        else
        {
            for (int inputIndex = 0; inputIndex < input.Length; inputIndex++)
            {
                int num;
                if (Int32.TryParse(input[inputIndex].ToString(), out num))
                {
                    stack.Push(num);    // if it's a number push it on the stack
                }
                else
                {
                    // Must be an operator or some other character or word.
                    string s = input[inputIndex].ToString();

                    // it may be an operator so pop two values off the stack and perform the indicated operation
                    if (stack.IsEmpty())
                    {
                        return ( "Improper input format. Stack became empty when expecting second operand." );
                    }

                    double b = Convert.ToDouble(stack.Pop());
                    if (stack.IsEmpty())
                    {
                        return ( "Improper input format. Stack became empty when expecting first operand." );
                    }
                    double a = Convert.ToDouble(stack.Pop());

                    // Wrap up all operations in a single method, easy to add other binary operators this way if desired
                    stack.Push(doOperation(a, b, s));
                }
            }// End while
        }

        return (stack.Pop().ToString());
    }

    /**
    *  Perform arithmetic.  Put it here so as not to clutter up the previous method, which is already pretty ugly.
    *
    *@param  a                             First operand
    *@param  b                             Second operand
    *@param  s                             operator
    *@return                               The answer
    *@exception  IllegalArgumentException  Something's fishy here
    */
    public double doOperation(double a, double b, String s)
    {
        double c = 0.0;
        if (s.Equals( "+" ) )      // Can't use a switch-case with Strings, so we do if-else
        {
            c = ( a + b );
        }
        else if (s.Equals( "-" ) )
        {
            c = ( a - b );
        }
        else if (s.Equals( "*" ) )
        {
            c = ( a * b );
        }
        else if (s.Equals( "/" ) )
        {
            c = ( a / b );
            if (c == Double.NegativeInfinity || c == Double.PositiveInfinity)
            {
                Console.WriteLine("Cannot divide by 0");
                return (0);
            }
        }
        else
        {
            Console.WriteLine("Improper operator: " + s + ", is not one of +, -, *, or /" );
            return (0);
        }

        return c;
    }
}
