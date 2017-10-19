// Byte to binary (4: byte, type cast)

using System;
public class Binary4
{
    public static void Main()
    {
        Console.Write("Number to convert?: ");
        byte n = Convert.ToByte(Console.ReadLine());
        Console.Write("In binary is: ");
        
        string binary = "";
        while (n > 0)
        {
            if (n%2 == 0)
                binary = "0"+binary;
            else 
                binary = "1"+binary;
            n = (byte) (n / 2);
        }
        Console.WriteLine(binary);
    }
}
