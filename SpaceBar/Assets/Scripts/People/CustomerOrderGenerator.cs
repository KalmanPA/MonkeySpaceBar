using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerOrderGenerator
{
    public string CustomerOrderID;

    public int[] GenerateOrderNumbers()
    {
        int[] numbers = new int[4];
        //int remainingSum = 4;

        // Generate random numbers
        for (int i = 0; i < numbers.Length; i++)
        {
            int randomNumber = Random.Range(1, 5); // Generate random number within the remaining sum

            

            numbers[i] = randomNumber;
            //remainingSum -= randomNumber;
        }

        // The last number is whatever remains to ensure the sum is exactly 6
        //numbers[numbers.Length - 1] = remainingSum;

        CustomerOrderID = ConvertNumbersToId(numbers);

        return numbers;
    }

    private string ConvertNumbersToId(int[] numbers)
    {
        return string.Join("", numbers);
    }
}
