using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace VirtualBroadcastingSystem.DisplayFramework
{
    public static class Expand
    {
        public static T GetRandomItem<T>(this IEnumerable<T> enumerable)
        {
            var array = enumerable.ToArray();
            return array[Random.Range(0, array.Length)];
        }

        public static T GetRandomItem<T>(this IEnumerable<T> enumerable, int seed)
        {
            var array = enumerable.ToArray();
            return array[new System.Random(seed).Next(0, array.Length - 1)];
        }
        
        
        public static float Map(this float value, float inMin, float inMax, float outMin, float outMax)
        {
            return (outMax - outMin) / (inMax - inMin) * (value - inMin) + outMin;
        }

        
        
        
    }
}