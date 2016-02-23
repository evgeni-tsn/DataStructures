﻿namespace _07.ImplementLinkedListT
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public int Count { get; private set; }

        public void Add(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                var newHead = new ListNode<T>(element);
                this.tail.NextNode = newHead;
                this.tail = newHead;
            }
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            T elementToBeRemoved;
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List empty");
            }
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }
            var currentNode = this.head;
            if (index==0)
            {
                elementToBeRemoved = this.head.Value;
                this.head = this.head.NextNode;
                this.Count--;
                return elementToBeRemoved;
            }
            for (int i = 0; i < index; i++)
            {
                if (i!=0)
                {
                    currentNode = currentNode.NextNode;
                }
            }
            if (index == this.Count - 1)
            {
                this.tail = currentNode;
            }
            elementToBeRemoved = currentNode.NextNode.Value;
            currentNode.NextNode = currentNode.NextNode.NextNode;
            this.Count--;
            return elementToBeRemoved;
        }

        public int FirstIndexOf(T item)
        {
            int index = -1;
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    index = i;
                    return index;
                }
                currentNode = currentNode.NextNode;
            }
            return index;
        }

        public int LastIndexOf(T item)
        {
            int index = -1;
            var currentNode = this.head;

            for (int i = 0; i < this.Count; i++)
            {
                if (currentNode.Value.Equals(item))
                {
                    index = i;
                }
                currentNode = currentNode.NextNode;
            }
            return index;
        }

        public void ForEach(Action<T> action)
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                action(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentNode = this.head;
            while (currentNode != null)
            {
                yield return currentNode.Value;
                currentNode = currentNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public T[] ToArray()
        {
            var arr = new T[this.Count];
            int index = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                arr[index] = currentNode.Value;
                currentNode = currentNode.NextNode;
                index++;
            }

            return arr;
        }
    }
}