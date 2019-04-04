using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


public class LinkedList<T>: IEnumerable<T> where T:IComparable
{
    public LinkedListNode<T> First { get; set; }
    public LinkedListNode<T> Last { get; set; }
    public int Count { get; set; }

    public LinkedList()
    {
    }

    public LinkedList(IEnumerable<T> values)
    {
        foreach (var value in values)
            this.Add(value);
    }

    public void Add(T value)
    {
        var node = new LinkedListNode<T>(value) { Previous = this.Last };
        
        if (this.Last == null)
            this.First = node;
        else
            this.Last.Next = node;

        this.Last = node;
        this.Count++;
    }

    public LinkedListNode<T> Find(T value)
    {
        var node = this.First;
        
        while (node != null)
        {
            if (node.Value.CompareTo(value) == 0)
                return node;
            else
                node = node.Next;
        }

        return null;
    }

    public void Remove(LinkedListNode<T> node)
    {
        if (node == null)
            throw new InvalidOperationException();

        var previous = node.Previous;

        if (previous != null)
            previous.Next = node.Next;
        else
        {
            this.First = node.Next;
            previous = node;
        }

        if (previous.Next != null)
            previous.Next.Previous = previous;
        else
            this.Last = previous;

        this.Count--;
    }

    public void Remove(T value)
    {
        var node = this.Find(value);

        if (node == null)
            throw new ArgumentException();
        
        this.Remove(node);
    }

    public IEnumerator<T> GetEnumerator()
    {
        var node = this.First;
        while (node != null)
        {
            yield return node.Value;
            node = node.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

public class LinkedListNode<T> where T: IComparable
{
    public LinkedListNode(T value)
    {
        this.Value = value;
    }

    public T Value { get; set; }
    public LinkedListNode<T> Next { get; set; }
    public LinkedListNode<T> Previous { get; set; }
}