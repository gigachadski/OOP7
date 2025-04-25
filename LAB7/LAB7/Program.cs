using System;
using System.Collections;



/// <summary>
/// Двоспрямований список.
/// </summary>
public class DoublyLinkedList<T> : IEnumerable<T> where T : IComparable<T>
{
    private class Node
    {
        public T Value;
        public Node Next;
        public Node Prev;

        public Node(T value)
        {
            Value = value;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    /// <summary>
    /// Додає елемент до початку списку.
    /// </summary>
    public void AddFirst(T value)
    {
        Node node = new Node(value);
        if (head == null)
        {
            head = tail = node;
        }
        else
        {
            node.Next = head;
            head.Prev = node;
            head = node;
        }
        count++;
    }

    /// <summary>
    /// Повертає елемент за індексом.
    /// </summary>
    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException();

            Node current = head;
            for (int i = 0; i < index; i++)
                current = current.Next;

            return current.Value;
        }
    }

    /// <summary>
    /// Видаляє елемент за індексом.
    /// </summary>

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
            throw new IndexOutOfRangeException();

        Node current = head;
        for (int i = 0; i < index; i++)
            current = current.Next;

        if (current.Prev != null)
            current.Prev.Next = current.Next;
        else
            head = current.Next;

        if (current.Next != null)
            current.Next.Prev = current.Prev;
        else
            tail = current.Prev;

        count--;
        
    }

    /// <summary>
    /// Повертає кількість елементів.
    /// </summary>
    public int Count => count;

    /// <summary>
    /// Реалізація foreach.
    /// </summary>
    public IEnumerator<T> GetEnumerator()
    {
        Node current = head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

   

    /// <summary>
    /// Повертає індекс першого елементу, меншого за середнє значення.
    /// </summary>
    public int IndexOfFirstLessThanAverage()
    {
        double sum = 0;
        int total = 0;

        foreach (T value in this)
        {
            sum += Convert.ToDouble(value);
            total++;
        }

        double average = sum / total;
        int index = 0;
        foreach (T value in this)
        {
            if (Convert.ToDouble(value) < average)
                return index;
            index++;
        }
        return -1;
    }

    /// <summary>
    /// Повертає суму елементів після максимального.
    /// </summary>
    public double SumAfterMax()
    {
        Node current = head;
        Node maxNode = head;
        while (current != null)
        {
            if (current.Value.CompareTo(maxNode.Value) > 0)
                maxNode = current;
            current = current.Next;
        }

        double sum = 0;
        current = maxNode.Next;
        while (current != null)
        {
            sum += Convert.ToDouble(current.Value);
            current = current.Next;
        }

        return sum;
    }

    /// <summary>
    /// Повертає новий список з елементів, більших за задане значення.
    /// </summary>
    public DoublyLinkedList<T> GetElementsGreaterThan(T threshold)
    {
        var result = new DoublyLinkedList<T>();
        foreach (T value in this)
        {
            if (value.CompareTo(threshold) > 0)
                result.AddFirst(value);
        }
        return result;
    }

    /// <summary>
    /// Видаляє всі елементи до максимального.
    /// </summary>
    public void RemoveBeforeMax()
    {
        Node current = head;
        Node maxNode = head;

        while (current != null)
        {
            if (current.Value.CompareTo(maxNode.Value) > 0)
                maxNode = current;
            current = current.Next;
        }

        head = maxNode;
        if (head != null)
            head.Prev = null;
    }
}
