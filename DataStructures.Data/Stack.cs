using System;

public class Stack<T> where T: IComparable
{
    private T[] _elements;
    private int _head;

    public Stack()
    {
        this._elements = new T[16];
        this._head = -1;
    }

    public void Push(T element)
    {
        if (this._head == this._elements.Length - 1)
            this.IncreaseCapacity();

        this._elements[++this._head] = element;
    }

    public T Pop()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();
        
        return this._elements[this._head--];
    }

    public T Peek()
    {
        if (this.Count == 0)
            throw new InvalidOperationException();

        return this._elements[this._head];
    }

    private void IncreaseCapacity()
    {
        var elements = new T[this._elements.Length * 2];
        Array.Copy(this._elements, elements, this._elements.Length);

        this._elements = elements;
    }

    public int Count { get {return this._head + 1;} private set {} }
}