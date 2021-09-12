using System;
using System.Collections.Generic;

namespace Assets.Common.Scripts.Utilities
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
    }
}
