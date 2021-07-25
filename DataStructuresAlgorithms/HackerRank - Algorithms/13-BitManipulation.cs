using System;
using NUnit.Framework;

namespace Algorithms
{
    // https://www.youtube.com/watch?v=NLKQEOgBAnw&list=PLI1t_8YX-ApvMthLj56t1Rf-Buio5Y8KL&index=13
    // https://www.tutorialspoint.com/csharp/csharp_bitwise_operators.htm
    public class BitManipulationHr {

        // binary representation of positive
        // addition
        // binary negative
        // shifting
        // masking
        
        // todo implement these in CSharp

        [Test]
        public void MainTest()
        {
            int a = 60;            /* 60 = 0011 1100 */ 
            int b = 13;            /* 13 = 0000 1101 */
            int c = 0; 
         
            // Binary AND Operator copies a bit to the result if it exists in both operands.
            c = a & b;             /* 12 = 0000 1100 */ 
            Console.WriteLine("Line 1 - Value of c is {0}", c );
         
            // Binary OR Operator copies a bit if it exists in either operand.
            c = a | b;             /* 61 = 0011 1101 */
            Console.WriteLine("Line 2 - Value of c is {0}", c);
         
            // Binary XOR Operator copies the bit if it is set in one operand but not both.
            c = a ^ b;             /* 49 = 0011 0001 */
            Console.WriteLine("Line 3 - Value of c is {0}", c);
         
            // Binary Ones Complement Operator is unary and has the effect of 'flipping' bits.	
            c = ~a;                /*-61 = 1100 0011 */
            Console.WriteLine("Line 4 - Value of c is {0}", c);
         
            // Binary Left Shift Operator. The left operands value is moved left by the number of bits specified by the right operand.	
            c = a << 2;      /* 240 = 1111 0000 */
            Console.WriteLine("Line 5 - Value of c is {0}", c);
         
            // Binary Right Shift Operator. The left operands value is moved right by the number of bits specified by the right operand.	
            c = a >> 2;      /* 15 = 0000 1111 */
            Console.WriteLine("Line 6 - Value of c is {0}", c);
        }
    }
}