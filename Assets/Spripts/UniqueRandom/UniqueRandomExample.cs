using System.Collections.Generic;
using UnityEngine;

public class UniqueRandomExample : MonoBehaviour
{
    private List<int> _numbers = new() {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    
    private void Start()
    {
        foreach (var number in _numbers.GetUniqueRandomItems(_numbers.Count))
        {
            //    print($"Item: {number}");
        }
    }
}