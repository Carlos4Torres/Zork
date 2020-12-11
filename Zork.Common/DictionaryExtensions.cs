using System.Collections.Generic;

namespace Zork
{
    public static class DictionaryExtensions
    {
        public static TValue GetValueOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key, TValue defaultValue = default(TValue))
        {
            return (dictionary != null && key != null && dictionary.TryGetValue(key, out TValue value)) ? value : defaultValue;
        }
    }
}