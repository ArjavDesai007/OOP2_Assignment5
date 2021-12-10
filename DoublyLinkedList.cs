/*
 * Use these method names
 * 
 * front --
 * back --
 * clear --
 * empty -- 
 * indexOf --
 * add --
 * get --
 * addFront --
 * remove --
 * addBack --
 * removeFront --
 * size --
 * removeBack --
 * 
 */

using System;

namespace A5.Task1
{
    public class DoublyLinkedList
    {
        private class Node
        {
            public int data;
            public Node next;
            public Node previous;

            public Node(int data, Node next, Node previous)
            {
                this.data = data;
                this.next = next;
                if (next != null)
                {
                    next.previous = this;
                }

                this.previous = previous;

                if (previous != null)
                {
                    previous.next = this;
                }
            }
            public Node(int data, Node next) : this(data, next, null) { }
            public Node(int data) : this(data, null, null) { }
        }

        private Node head; // Start of the list
        private Node tail; // End of the list

        /// <summary>
        /// Add new node at Front
        /// </summary>
        /// <param name="value">Value in Node</param>
        public void AddFront(int value)
        {
            head = new Node(value, head);
            if (tail == null)
            {
                tail = head;
            }
        }

        /// <summary>
        /// Add new node at Back
        /// </summary>
        /// <param name="value">Value in Node</param>
        public void AddBack(int value)
        {
            tail.next = new Node(value, null, tail);
            tail = tail.next;
            if (head == null)
            {
                head = tail;
            }
        }

        /// <summary>
        /// Remove Front
        /// </summary>
        /// <returns>Value of deleted Node</returns>
        public int RemoveFront()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            int temp = head.data;

            head = head.next;

            if (head != null)
            {
                head.previous = null;
            }
            else
            {
                tail = null;
            }

            return temp;
        }

        /// <summary>
        /// Remove Back
        /// </summary>
        /// <returns>Value of deleted Node</returns>
        public int RemoveBack()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("List is empty");
            }

            int temp = tail.data;

            tail = tail.previous;

            if (tail != null)
            {
                tail.next = null;
            }
            else
            {
                head = null;
            }

            return temp;
        }

        /// <summary>
        /// Add new Node
        /// </summary>
        /// <param name="value">Value of new Node</param>
        /// <param name="index">Index where you want to put the new node</param>
        public void Add(int value, int index)
        {
            int numElems = Size();

            if (index < 0 || index >= numElems)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                AddFront(value);
            }
            else if (index == numElems)
            {
                AddBack(value);
            }
            else
            {
                int count = 0;

                Node temp = head;

                while (count < index)
                {
                    temp = temp.next;
                    ++count;
                }

                temp.next = new Node(value, temp.next, temp);
            }
        }

        /// <summary>
        /// remove node at specific index
        /// </summary>
        /// <param name="index">index which need to be removed</param>
        /// <returns>Value of removed Node</returns>
        public int Remove(int index)
        {
            int numElems = Size();

            if (index < 0 || index >= numElems)
            {
                throw new IndexOutOfRangeException();
            }
            if (index == 0)
            {
                return RemoveFront();
            }
            if (index == numElems - 1)
            {
                return RemoveBack();
            }

            int count = 0;

            Node temp = head;

            while (count < index - 1)
            {
                temp = temp.next;
                ++count;
            }

            int tmp = temp.next.data;
            temp.next = temp.next.next;

            if (temp.next != null)
            {
                temp.next.previous = temp;
            }

            return tmp;
        }

        /// <summary>
        /// Get Size of the list
        /// </summary>
        /// <returns></returns>
        public int Size()
        {
            int count = 0;

            Node temp = head;

            while (temp != null)
            {
                ++count;
                temp = temp.next;
            }

            return count;
        }

        /// <summary>
        /// Find index of specific value
        /// </summary>
        /// <param name="value">Value on specific index</param>
        /// <returns>index</returns>
        public int IndexOf(int value)
        {
            Node temp = head;
            int idx = 0;

            while (temp != null)
            {
                if (temp.data == value)
                {
                    return idx;
                }

                temp = temp.next;
                ++idx;
            }

            return -1;
        }

        /// <summary>
        /// Empty the list
        /// </summary>
        /// <returns>is list is empty</returns>
        public bool Empty()
        {
            return head == null;
        }

        /// <summary>
        /// get value of specific index
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public int Get(int index)
        {
            if (index < 0 || index >= Size())
            {
                throw new IndexOutOfRangeException();
            }

            int count = 0;

            Node temp = head;

            while (count < index)
            {
                temp = temp.next;
                ++count;
            }

            return temp.data;
        }

        /// <summary>
        /// Get data of first node
        /// </summary>
        /// <returns>data in first node</returns>
        public int Front()
        {
            if (head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return head.data;
        }

        /// <summary>
        /// Get data of last node
        /// </summary>
        /// <returns>data in last node</returns>
        public int Back()
        {
            if (tail == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            return tail.data;
        }

        /// <summary>
        /// Clear the list
        /// </summary>
        public void Clear()
        {
            head = null;
            tail = null;
        }
    }
}
