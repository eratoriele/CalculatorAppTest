using System;
using CalculatorApp.Core;

namespace CalculatorApp.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine(
                "1. Add two numbers\n" +
                "2. Subtract two numbers\n" +
                "3. Multiply two numbers\n" +
                "4. Divide two numbers\n" +
                "Please select option: ");

            try                                     // Exception catch for parsing from string to int
            {
                string option = Console.ReadLine();
                int intOption = Int32.Parse(option);

                Console.WriteLine("Enter first number:");
                string i1 = Console.ReadLine();
                int inti1 = Int32.Parse(i1);
                Console.WriteLine("Enter second number:");
                string i2 = Console.ReadLine();
                int inti2 = Int32.Parse(i2);

                switch (intOption)
                {
                    case 1:
                        Console.WriteLine(i1 + " + " + i2 + " = " + CalculatorAppCore.addnumbers(inti1, inti2));
                        break;
                    case 2:
                        Console.WriteLine(i1 + " - " + i2 + " = " + CalculatorAppCore.subtractnumbers(inti1, inti2));
                        break;
                    case 3:
                        Console.WriteLine(i1 + " * " + i2 + " = " + CalculatorAppCore.multiplynumbers(inti1, inti2));
                        break;
                    case 4:
                        Console.WriteLine(i1 + " / " + i2 + " = " + CalculatorAppCore.dividenumbers(inti1, inti2));
                        break;
                    default:
                        Console.WriteLine("Please select from given options");
                        break;
                }
                
            }
            catch (ArgumentNullException)        // If input is null
            {
                Console.WriteLine("Please enter a value\n");
            }
            catch (FormatException)              // If input is not in the correct format.
            {
                Console.WriteLine("Please enter a valid value\n");
            }
            catch (OverflowException)            // If input represents a number less than MinValue or greater than MaxValue.
            {
                Console.WriteLine("Please enter a number between " + Int32.MaxValue + " and " + Int32.MinValue + "\n");
            }
            catch (DivideByZeroException)       // If divide is chosen, and i2 is 0
            {
                Console.WriteLine("Please dont divide by 0\n");
            }   
            catch (Exception)                    // If something else happens
            {
                Console.WriteLine("There was an error\n");
            }
                    

        }
    }
}
