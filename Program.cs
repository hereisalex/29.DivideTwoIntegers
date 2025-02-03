public class Solution
{
    public static void Main(string[] args)
    {
        Solution solution = new Solution();
        var output = solution.Divide(-2147483648, -1);
        Console.WriteLine(output.ToString());
    }

    //Challenge: Given two integers dividend and divisor, divide two integers without using multiplication, division, and mod operator.
    public int Divide(int dividend, int divisor)
    {
        // Handle the special case to prevent overflow when dividend is -2,147,483,648 and divisor is -1
        if (dividend == int.MinValue && divisor == -1)
        {
            return int.MaxValue; // Return the maximum value for a 32-bit signed integer
        }

        // Convert the dividend and divisor to their absolute values
        long absDividend = Math.Abs((long)dividend);
        long absDivisor = Math.Abs((long)divisor);
        int result = 0; // Initialize the result (quotient) to zero

        // Main loop to find the quotient by repeatedly subtracting the divisor from the dividend
        while (absDividend >= absDivisor)
        {
            long tempDivisor = absDivisor, multiple = 1;
            // Double the divisor (tempDivisor) until it exceeds the remaining dividend (absDividend)
            while (absDividend >= (tempDivisor << 1))
            {
                tempDivisor <<= 1; // Shift left to double the value of tempDivisor
                multiple <<= 1; // Shift left to double the value of multiple
            }
            // Subtract the largest possible multiple of the divisor from the dividend
            absDividend -= tempDivisor; // Reduce the remaining dividend
            result += (int)multiple; // Add the multiple to the result
        }

        // Adjust the sign of the result based on the original signs of the dividend and divisor
        return (dividend > 0) == (divisor > 0) ? result : -result; // If signs are different, negate the result
    }
}
