﻿using System;
using System.Linq;

// Задача: реализовать метод SortStringArray, который должен возвращать сортированный массив строк.
//   * Массив должен сортировать строки по количеству символов.
//   * Метод должен выбрасывать ArgumentNullException, если в метод передан null.
//   * В решении разрешается использовать только конструкции языка. Использовать LINQ запрещено. Рекомендуется не использовать любые дополнительные структуры данных.

public class Program
{
    public static string[] SortStringArray(string[] array)
    {
        if (array == null)
        {
            throw new ArgumentNullException();
        }

        string t;
        for (int p = 0; p < array.Length - 1; p++)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].Length > array[i + 1].Length)
                {
                    t = array[i + 1];
                    array[i + 1] = array[i];
                    array[i] = t;
                }
            }
        }
     
        return array;
    }

    // ----- ЗАПРЕЩЕНО ИЗМЕНЯТЬ КОД МЕТОДОВ, КОТОРЫЕ НАХОДЯТСЯ НИЖЕ -----

    public static void Main()
    {
        Console.WriteLine("Task is done when all test cases are correct:");

        int testCaseNumber = 1;

        TestReturnedValues(testCaseNumber++, new string[] { }, new string[] { });
        TestReturnedValues(testCaseNumber++, new string[] { string.Empty }, new string[] { string.Empty });
        TestReturnedValues(testCaseNumber++, new string[] { "abc" }, new string[] { "abc" });
        TestReturnedValues(testCaseNumber++, new string[] { "abc", "abcd" }, new string[] { "abc", "abcd" });
        TestReturnedValues(testCaseNumber++, new string[] { "abcd", "abc" }, new string[] { "abc", "abcd" });
        TestReturnedValues(testCaseNumber++, new string[] { "abc", "abcd", "abcde" }, new string[] { "abc", "abcd", "abcde" });
        TestReturnedValues(testCaseNumber++, new string[] { "abcde", "abcd", "abc" }, new string[] { "abc", "abcd", "abcde" });
        TestReturnedValues(testCaseNumber++, new string[] { "123456", "1", "12345", "12", "1234", "123", "1234567" }, new string[] { "1", "12", "123", "1234", "12345", "123456", "1234567" });
        TestReturnedValues(testCaseNumber++, new string[] { "1234567", "123", "1", "12345678", "12", "1234", "12", "1234", "123", "123456", "12345678", "1234", "12345", "123556" }, new string[] { "1", "12", "12", "123", "123", "1234", "1234", "1234", "12345", "123456", "123556", "1234567", "12345678", "12345678" });

        TestException<ArgumentNullException>(testCaseNumber++, null);

        if (correctTestCaseAmount == testCaseNumber - 1)
        {
            Console.WriteLine("Task is done.");
        }
        else
        {
            Console.WriteLine("TASK IS NOT DONE.");
        }
    }

    private static void TestReturnedValues(int testCaseNumber, string[] array, string[] expectedResult)
    {
        try
        {
            var result = SortStringArray(array);

            if (result.SequenceEqual(expectedResult))
            {
                Console.WriteLine(correctCaseTemplate, testCaseNumber);
                correctTestCaseAmount++;
            }
            else
            {
                Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
            }
        }
        catch (Exception)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
        }
    }

    private static void TestException<T>(int testCaseNumber, string[] array) where T : Exception
    {
        try
        {
            SortStringArray(array);
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
        catch (T)
        {
            Console.WriteLine(correctCaseTemplate, testCaseNumber);
            correctTestCaseAmount++;
        }
        catch (Exception)
        {
            Console.WriteLine(incorrectCaseTemplate, testCaseNumber);
        }
    }

    private static string correctCaseTemplate = "Case #{0} is correct.";
    private static string incorrectCaseTemplate = "Case #{0} IS NOT CORRECT";
    private static int correctTestCaseAmount = 0;
}