using System;
using System.Collections;
using System.Collections.Generic;

namespace Cards
{
    public static class Extensions
    {
        public static List<T> Shuffle<T>(this List<T> list, Random random = null)
        {
            if (random == null)
            {
                random = new Random();
            }
            for (int i = 0; i < list.Count; i++)
            {
                int j = random.Next(list.Count - i) + i;
                T tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }
            return list;
        }

        public static T Peek<T>(this List<T> list)
        {
            return list[list.Count - 1];
        }
    }
}