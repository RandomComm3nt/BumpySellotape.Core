using BumpySellotape.Core.Utilities;
using System;
using System.Collections.Generic;

namespace Assets.Common.Scripts.Utilities
{
    public static class EnumUtils
    {
        public static T PickRandomBit<T>(this T value) where T: Enum
        {
            int i = (int)(object)value;

            var values = Enum.GetValues(typeof(T));
            var powers = new List<int>();
            foreach(var v in values)
            {
                var j = (int)v;
                if ((j & (j - 1)) == 0) // is power of two
                {
                    if ((i & j) == j)
                    {
                        powers.Add(j);
                    }
                }
            }

            return (T)(object)powers.SelectRandomItem();
        }

        public static bool FlagContainsNonFlagValue<T1, T2>(T1 flagEnum, T2 baseEnum)
            where T1 : Enum 
            where T2 : Enum
        {
            return (Convert.ToInt32(flagEnum) & (2 << Convert.ToInt32(baseEnum))) != 0;
        }
    }
}
