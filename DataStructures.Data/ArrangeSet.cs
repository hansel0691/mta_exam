using System;
using System.Linq;
using System.Collections.Generic;

public static class ArrangeSet<T> where T: IComparable
{
    public static void BubbleSort(IList<T> elements)
    {
        var swapped = false;
        
        for (int i = 0; i < elements.Count - 1; i++)
            if (elements[i].CompareTo(elements[i + 1]) > 0)
            {
                var temp = elements[i + 1];
                elements[i+ 1] = elements[i];
                elements[i] = temp;
                swapped = true;
            }    
        
        if (swapped)
            BubbleSort(elements);
    }

    public static IList<T> QuickSort(IList<T> elements)
    {
        if (elements.Count <= 1) return elements;

        var pivotIndex = elements.Count/2;
        var pivot = elements[pivotIndex];
        
        var left = elements.Where((m, i) => i != pivotIndex && m.CompareTo(pivot) <= 0);
        var right =  elements.Where((m, i) => i != pivotIndex && m.CompareTo(pivot) > 0);

        var result = new List<T>(QuickSort(left.ToList()));
        result.Add(pivot);
        result.AddRange(QuickSort(right.ToList()));

        return result;
    }
} 