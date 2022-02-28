using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

namespace Assets.Common.Scripts.Utilities
{
    public static class ArrayExtensions
    {
        public static T[] Shuffle<T>(this T[] array)
        {
            var newArray = array.ToArray();
            for (int i = 0; i < newArray.Length; i++)
            {
                int j = Random.Range(i, newArray.Length);
                var old = newArray[i];
                newArray[i] = newArray[j];
                newArray[j] = old;
            }
            return newArray;
        }

        public static IEnumerable<T> Where<T>(this T[,] array, Predicate<T> predicate)
        {
            return Enumerable
                .Range(0, array.GetLength(0))
                .SelectMany(i => Enumerable.Range(0, array.GetLength(1)).Select(j => array[i, j]))
                .Where(x => predicate.Invoke(x));
        }
    }
}
