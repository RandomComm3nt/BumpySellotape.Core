using System;
using System.Collections.Generic;
using System.Linq;

namespace BumpySellotape.Core.Utilities
{
    public static class ListExtensions
    {
        public static T SelectRandomItem<T>(this List<T> list)
        {
            if (list.Count == 0)
                return default;
            return list[UnityEngine.Random.Range(0, list.Count)];
        }

        public static float Product<T>(this List<T> list, Func<T, float> map, float valueIfEmpty = 0f)
        {
            if (list.Count == 0)
                return valueIfEmpty;

            float value = map(list[0]);
            for (int i = 1; i < list.Count; i++)
            {
                value *= map(list[i]);
            }

            return value;
        }

        public static List<T> Shuffle<T>(this List<T> list)
        {
            var newList = list.ToList();
            for (int i = 0; i < newList.Count; i++)
            {
                int j = UnityEngine.Random.Range(i, newList.Count);
                (newList[j], newList[i]) = (newList[i], newList[j]);
            }
            return newList;
        }
    }
}
