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

        public static List<T> Shuffle<T>(this IEnumerable<T> list)
        {
            var newList = list.ToList();
            for (int i = 0; i < newList.Count; i++)
            {
                int j = UnityEngine.Random.Range(i, newList.Count);
                (newList[j], newList[i]) = (newList[i], newList[j]);
            }
            return newList;
        }

        public static IEnumerable<T2> FilterType<T, T2>(this IEnumerable<T> list)
            where T2 : class
        {
            return list.Where(e => e is T2).Select(e => e as T2);
        }

        public static IEnumerable<(T1, T2)> CartesianJoin<T1, T2>(this IEnumerable<T1> list, IEnumerable<T2> list2) => list.Join(list2, x => 1, x => 1, (x, y) => (x, y));
    }
}
