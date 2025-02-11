using System;
using System.Collections.Generic;

class Program
{
    static Dictionary<char, int> mapping = new Dictionary<char, int>
    {
        {'A', 0}, {'B', 1}, {'C', 1}, {'D', 1}, {'E', 2}, {'F', 3}, {'G', 3}, {'H', 3},
        {'I', 4}, {'J', 5}, {'K', 5}, {'L', 5}, {'M', 5}, {'N', 5}, {'O', 6}, {'P', 7},
        {'Q', 7}, {'R', 7}, {'S', 7}, {'T', 7}, {'U', 8}, {'V', 9}, {'W', 9}, {'X', 9},
        {'Y', 9}, {'Z', 9},
        {'a', 9}, {'b', 8}, {'c', 8}, {'d', 8}, {'e', 7}, {'f', 6}, {'g', 6}, {'h', 6},
        {'i', 5}, {'j', 4}, {'k', 4}, {'l', 4}, {'m', 4}, {'n', 4}, {'o', 3}, {'p', 2},
        {'q', 2}, {'r', 2}, {'s', 2}, {'t', 2}, {'u', 1}, {'v', 0}, {'w', 0}, {'x', 0},
        {'y', 0}, {'z', 0}, {' ', 0}
    };

    static void ConvertTextToNumbers(string input, List<int> numbers)
    {
        foreach (char c in input)
        {
            if (mapping.ContainsKey(c))
            {
                int value = mapping[c];
                Console.Write(value + " ");
                numbers.Add(value);
            }
        }
        Console.WriteLine();
    }

    static List<char> ConvertNumberToText(int[] arrayNumber)
    {
        var reverseMapping = new Dictionary<int, char>
        {
            { 0, 'A' }, { 1, 'B' }, { 2, 'E' }, { 3, 'F' }, { 4, 'I' },
            { 5, 'J' }, { 6, 'O' }, { 7, 'P' }, { 8, 'U' }, { 9, 'V' }
        };

        var alphabetResult = new List<char>();
        
        foreach (var number in arrayNumber)
        {
            alphabetResult.Add(reverseMapping.TryGetValue(number, out var alphabet) ? alphabet : '?');
        }
        
        return alphabetResult;
    }

    static int CalculateTheIntervals(int[] number) {
        if (number.Length == 0) return 0;
        
        int total = number[0];
        bool sumOperation = true;

        for (int i = 1; i < number.Length; i++) {
            total = sumOperation ? total + number[i] : total - number[i];
            sumOperation = !sumOperation;
        }

        return total;
    }

    static int[] CalculationResultToAlphabet(int total) {
        total = Math.Abs(total);
        List<int> numberList = new List<int>();
        int currentNumber = 0;
        int remaining = total;

        while (remaining > 0) {
            if (remaining >= currentNumber) {
                numberList.Add(currentNumber);
                remaining -= currentNumber;
            } else {
                currentNumber = 0;
                numberList.Add(0);
            }
            currentNumber++; // Menambah nilai angka untuk iterasi berikutnya
        }
        return numberList.ToArray();
    }

    static int[] ResultToSampleOutput(int[] number)
    {
        if (number.Length < 2)
        {
            Console.WriteLine("Arrays cannot have less than two elements.");
            return number;
        }

        number[^2]++;
        number[^1]++;
        return number;
    }

    static int[] OddEvenCalculate(int[] inputArray)
    {
        return inputArray.Select((value, index) => index % 2 == 0 ? value + 1 : value).ToArray();
    }
        
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        List<int> numbers = new List<int>();
        ConvertTextToNumbers(input, numbers);
        
        // Konversi teks ke angka
        int result = CalculateTheIntervals(numbers.ToArray());
        Console.WriteLine("Calculated Interval Sum: " + result);
        
        // Hitung hasil operasi matematika
        int[] resultArray = CalculationResultToAlphabet(result);
        Console.WriteLine("Calculation Result To Alphabet: " + string.Join(", ", resultArray));

        // Konversi hasil perhitungan ke angka yang sesuai dengan alfabet
        List<char> resultChar = ConvertNumberToText(resultArray);
        Console.WriteLine("Convert Number to Text: " + string.Join(", ", resultChar));

        // Konversi angka ke huruf
        int[] modifiedArray = ResultToSampleOutput(resultArray);
        Console.WriteLine("Modified Result Array: " + string.Join(", ", modifiedArray));   

        // Modifikasi hasil sesuai aturan soal
        List<char> modifiedChar = ConvertNumberToText(modifiedArray);
        Console.WriteLine("Convert Modified Number to Text: " + string.Join(", ", modifiedChar));

        // Konversi dengan perhitungan ganjil genap
        int[] transformedArray = OddEvenCalculate(resultArray);
        Console.WriteLine("Odd-Even Calculate: " + string.Join(", ", transformedArray));
    }
}
