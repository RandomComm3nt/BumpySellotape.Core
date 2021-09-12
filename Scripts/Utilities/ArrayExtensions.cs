using System.Linq;
using UnityEngine;

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
    }
}
