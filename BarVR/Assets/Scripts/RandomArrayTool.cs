using System;
using System.Collections.Generic;
using System.Linq;

static class RandomArrayTool
{
    static Random _random = new Random();

    public static T[] Randomize<T>(T[] arr)
    {
        List<KeyValuePair<int, T>> list = new List<KeyValuePair<int, T>>();
        // Add all Ts from array
        // Add new random int each time
        foreach (T s in arr)
        {
            list.Add(new KeyValuePair<int, T>(_random.Next(), s));
        }
        // Sort the list by the random number
        var sorted = from item in list
                     orderby item.Key
                     select item;
        // Allocate new T array
        T[] result = new T[arr.Length];
        // Copy values to array
        int index = 0;
        foreach (KeyValuePair<int, T> pair in sorted)
        {
            result[index] = pair.Value;
            index++;
        }
        // Return copied array
        return result;
    }
}