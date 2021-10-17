using System;
public class CpfValidator{

    public static bool validaCPF(string cpf){

        cpf = cpf.Replace(".", string.Empty); // Remove all '.'
        cpf = cpf.Replace("-", string.Empty); // Remove all '-'

        if (cpf.Length != 11) 
            return false;

        byte[] cpfDigits = new byte[11];
        for (var i=0; i < 11; i++)
            cpfDigits[i] = (byte)Char.GetNumericValue(cpf[i]);

        byte checkDigit1 = cpfDigits[cpfDigits.Length-2]; 
        byte checkDigit2 = cpfDigits[cpfDigits.Length-1];
        
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

        return true;

    }
}