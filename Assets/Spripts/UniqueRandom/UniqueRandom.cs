using System;
using System.Collections.Generic;
using System.Linq;

public static class UniqueRandom
{
    public static IEnumerable<T> GetUniqueRandomItems<T>(this IEnumerable<T> enumerable, int count)
    {
        if (count <= 0)
            throw new ArgumentException("Count must be greater than 0");

        var collection = enumerable.ToList();
        var random = new Random(DateTime.Now.Millisecond);

        if (count > collection.Count)
            count = collection.Count;

        for (int i = 0; i < count; i++)
        {
            var index = random.Next(collection.Count);
            var item = collection[index];
            yield return item;
            collection.RemoveAt(index);
        }
    }
}