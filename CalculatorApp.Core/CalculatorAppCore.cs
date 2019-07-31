using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    public static class CalculatorAppCore
    {

        public static string addnumbers(int i1, int i2)
        {
            int result = i1 + i2;
            if (i1 >= 0 && i2 >= 0 && result <= 0)     // If an overflow happened
            {
                return ((Int64)i1 + (Int64)i2).ToString();      // if i1 and i2 should be changed to int64 too,
                                                                // handle the addition by turning i1 and i2 to strings
                                                                // and do the addition with strings
            }
            else if (i1 <= 0 && i2 <= 0 && result >= 0)
            {
                return ((Int64)i1 + (Int64)i2).ToString();
            }
            else
            {
                return result.ToString();
            }
        }

        public static string subtractnumbers(int i1, int i2)
        {
            int result = i1 - i2;
            if (i1 <= 0 && i2 >= 0 && result >= 0)     // If an overflow happened
            {
                return ((Int64)i1 - (Int64)i2).ToString();      // if i1 and i2 should be changed to int64 too,
                                                                // handle the subtraction by turning i1 and i2 to strings
                                                                // and do the subtraction with strings
            }
            else if (i1 >= 0 && i2 <= 0 && result <= 0)
            {
                return ((Int64)i1 - (Int64)i2).ToString();
            }
            else
            {
                return result.ToString();
            }
        }

        public static string multiplynumbers(int i1, int i2)
        {
            Int64 result = (Int64)i1 * (Int64)i2;

            // two int32 multiplied cant overflow in int64
            // if i1 and i2 changed to int64:
            // TODO: to handle overflow with multiplication, multiply with strings
            /*if ()     
            {
            }
            else
            {
                return result.ToString();
            }*/

            return result.ToString();

        }

        public static string dividenumbers(int i1, int i2)
        {
            if (i2 == 0)
            {
                throw new DivideByZeroException("Can not divide by zero!");
            }
            else                    // There are no overflow in division between integers
            {
                return ((float)i1 / (float)i2).ToString();
            }

        }
    }
}
