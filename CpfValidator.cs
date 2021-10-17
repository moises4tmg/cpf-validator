using System;

namespace cpf
{
    public class CpfValidator
    {

        public static bool validaCPF(string cpf)
        {

            cpf = cpf.Replace(".", string.Empty); // Remove all '.'
            cpf = cpf.Replace("-", string.Empty); // Remove all '-'

            // CPF number has a fixed size of 11 numeric characters
            if (cpf.Length != 11) 
                return false;

            // Converting string cpf to byte[] cpfDigits
            byte[] cpfDigits = new byte[11];
            for (var i=0; i < 11; i++)
                cpfDigits[i] = (byte)Char.GetNumericValue(cpf[i]); 

            // Loop to check if CPF number has only one repeated value. If so, it's not valid
            for (byte i = 0; i < cpfDigits.Length; i++)
            {
                if (cpfDigits[i] == cpfDigits[0])
                {
                    if (i == cpfDigits.Length-1)
                        return false;
                }
                else
                    break;
            }

            byte checkDigit1 = cpfDigits[cpfDigits.Length-2]; // Taking the first checking digit  (***.***.***-0*)
            byte checkDigit2 = cpfDigits[cpfDigits.Length-1]; // Taking the second checking digit (***.***.***-*0)
            
            // Computing result for the first checking digit using the first 9 digits
            byte multiplyCounter = 10; 
            int firstCheckingValue = 0;
            for (byte i = 0; i < cpfDigits.Length-2; i++)
            {
                firstCheckingValue += cpfDigits[i]*multiplyCounter;
                multiplyCounter--;
            }
            firstCheckingValue *= 10;
            firstCheckingValue %= 11;
            if (firstCheckingValue == 10)
                firstCheckingValue = 0;

            if (firstCheckingValue != checkDigit1)
                return false;

            // Computing result for the second checking digit using the first 10 digits
            multiplyCounter = 11;
            int secondCheckingValue = 0;
            for (byte i = 0; i < cpfDigits.Length-1; i++)
            {
                secondCheckingValue += cpfDigits[i]*multiplyCounter;
                multiplyCounter--;
            }
            secondCheckingValue *= 10;
            secondCheckingValue %= 11;
            if (secondCheckingValue == 10)
                secondCheckingValue = 0;

            if (secondCheckingValue != checkDigit2)
                return false;

            // Function returns true if it passes through all of the tests
            return true;

        }
    }
}