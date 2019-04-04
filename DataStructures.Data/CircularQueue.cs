using System;
using System.Linq;

namespace DataStructures.Data
{
    public class CircularQueue<T> where T: IComparable {
        private T[] _elements;
        private int _head;
        private int _tail;

        public CircularQueue()
        {
            this._elements = new T[16];
        }

        public void Enqueue(T element)
        {
            this._elements[this._tail++] = element;
            this.Count++;

            if (this._tail == this._elements.Length)
                this._tail = 0;
            
            if (this._tail == this._head)
                this.IncreaseCapacity();
        }

        public T Pop()
        {
            if (this.Count == 0)
                throw new InvalidOperationException();

            var result = this._elements[this._head++];

            if (this._head == this._elements.Length)
                this._head = 0;

            this.Count--;
            return result;
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

            this._head = 0;
            this._tail = this._elements.Length;
            this._elements = elements;
        }

        public bool Contains(T element)
        {
            return this._elements.Any(m => m.CompareTo(element) == 0);
        }

        public int Count { get; set; }
    }
}
